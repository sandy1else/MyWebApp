using LogicLayer.BusinessObject;
using LogicLayer.DataLogic.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LogicLayer.BusinessLogic
{
    public class ReligionManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "ReligionCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<Religion> GetCacheAsList(string rawKey)
        {
            List<Religion> list = (List<Religion>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static Religion GetCacheItem(string rawKey)
        {
            Religion item = (Religion)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return item;
        }

        public static void AddCacheItem(string rawKey, object value)
        {
            System.Web.Caching.Cache DataCache = HttpRuntime.Cache;

            // Make sure MasterCacheKeyArray[0] is in the cache - if not, add it
            if (DataCache[MasterCacheKeyArray[0]] == null)
                DataCache[MasterCacheKeyArray[0]] = DateTime.Now;

            // Add a CacheDependency
            System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(null, MasterCacheKeyArray);
            DataCache.Insert(GetCacheKey(rawKey), value, dependency, DateTime.Now.AddMinutes(CacheDuration), System.Web.Caching.Cache.NoSlidingExpiration);
        }



        public static void InvalidateCache()
        {
            // Remove the cache dependency
            HttpRuntime.Cache.Remove(MasterCacheKeyArray[0]);
        }

        #endregion
        

        public static int Insert(Religion religion)
        {
            int id = RepositoryManager.Religion_Repository.Insert(religion);
            InvalidateCache();
            return id;
        }

        public static bool Update(Religion religion)
        {
            bool isExecute = RepositoryManager.Religion_Repository.Update(religion);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.Religion_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static Religion GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "ReligionById" + id;
            Religion Religion = GetCacheItem(rawKey);

            if (Religion == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Religion = RepositoryManager.Religion_Repository.GetById(id);
                if (Religion != null)
                    AddCacheItem(rawKey, Religion);
            }

            return Religion;
        }
          
        public static List<Religion> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "ReligionGetAll";

            List<Religion> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.Religion_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }

        public static List<Religion> GetAllAsync()
        { 
            List<Religion> list  = RepositoryManager.Religion_Repository.GetAll();
                
            return list;
        }

    }
}
