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
    public class GenderManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "GenderCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<Gender> GetCacheAsList(string rawKey)
        {
            List<Gender> list = (List<Gender>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static Gender GetCacheItem(string rawKey)
        {
            Gender item = (Gender)HttpRuntime.Cache[GetCacheKey(rawKey)];
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
        

        public static int Insert(Gender Gender)
        {
            int id = RepositoryManager.Gender_Repository.Insert(Gender);
            InvalidateCache();
            return id;
        }

        public static bool Update(Gender Gender)
        {
            bool isExecute = RepositoryManager.Gender_Repository.Update(Gender);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.Gender_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static Gender GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "GenderById" + id;
            Gender Gender = GetCacheItem(rawKey);

            if (Gender == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Gender = RepositoryManager.Gender_Repository.GetById(id);
                if (Gender != null)
                    AddCacheItem(rawKey, Gender);
            }

            return Gender;
        }
          
        public static List<Gender> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "GenderGetAll";

            List<Gender> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.Gender_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }

        public static List<Gender> GetAllAsync()
        { 
            List<Gender> list = RepositoryManager.Gender_Repository.GetAll();
                
            return list;
        }



    }
}
