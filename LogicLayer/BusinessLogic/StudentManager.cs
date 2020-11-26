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
    public class StudentManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "StudentCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<Student> GetCacheAsList(string rawKey)
        {
            List<Student> list = (List<Student>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static Student GetCacheItem(string rawKey)
        {
            Student item = (Student)HttpRuntime.Cache[GetCacheKey(rawKey)];
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
        

        public static int Insert(Student student)
        {
            int id = RepositoryManager.Student_Repository.Insert(student);
            InvalidateCache();
            return id;
        }

        public static bool Update(Student student)
        {
            bool isExecute = RepositoryManager.Student_Repository.Update(student);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.Student_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static Student GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "StudentById" + id;
            Student Student = GetCacheItem(rawKey);

            if (Student == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Student = RepositoryManager.Student_Repository.GetById(id);
                if (Student != null)
                    AddCacheItem(rawKey, Student);
            }

            return Student;
        }
          
        public static List<Student> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "StudentGetAll";

            List<Student> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.Student_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }
 

    }
}
