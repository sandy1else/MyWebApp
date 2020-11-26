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
    public class DepartmentManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "DepartmentCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<Department> GetCacheAsList(string rawKey)
        {
            List<Department> list = (List<Department>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static Department GetCacheItem(string rawKey)
        {
            Department item = (Department)HttpRuntime.Cache[GetCacheKey(rawKey)];
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
        

        public static int Insert(Department department)
        {
            int id = RepositoryManager.Department_Repository.Insert(department);
            InvalidateCache();
            return id;
        }

        public static bool Update(Department department)
        {
            bool isExecute = RepositoryManager.Department_Repository.Update(department);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.Department_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static Department GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "DepartmentById" + id;
            Department Department = GetCacheItem(rawKey);

            if (Department == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Department = RepositoryManager.Department_Repository.GetById(id);
                if (Department != null)
                    AddCacheItem(rawKey, Department);
            }

            return Department;
        }
          
        public static List<Department> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "DepartmentGetAll";

            List<Department> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.Department_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }
         
         

    }
}
