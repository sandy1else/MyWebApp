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
    public class AcademicSessionManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "AcademicSessionCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<AcademicSession> GetCacheAsList(string rawKey)
        {
            List<AcademicSession> list = (List<AcademicSession>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static AcademicSession GetCacheItem(string rawKey)
        {
            AcademicSession item = (AcademicSession)HttpRuntime.Cache[GetCacheKey(rawKey)];
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
        

        public static int Insert(AcademicSession AcademicSession)
        {
            int id = RepositoryManager.AcademicSession_Repository.Insert(AcademicSession);
            InvalidateCache();
            return id;
        }

        public static bool Update(AcademicSession AcademicSession)
        {
            bool isExecute = RepositoryManager.AcademicSession_Repository.Update(AcademicSession);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.AcademicSession_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static AcademicSession GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "AcademicSessionById" + id;
            AcademicSession AcademicSession = GetCacheItem(rawKey);

            if (AcademicSession == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                AcademicSession = RepositoryManager.AcademicSession_Repository.GetById(id);
                if (AcademicSession != null)
                    AddCacheItem(rawKey, AcademicSession);
            }

            return AcademicSession;
        }
          
        public static List<AcademicSession> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "AcademicSessionGetAll";

            List<AcademicSession> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.AcademicSession_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }
         
    }
}
