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
    public class UserManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "UserCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<User> GetCacheAsList(string rawKey)
        {
            List<User> list = (List<User>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static User GetCacheItem(string rawKey)
        {
            User item = (User)HttpRuntime.Cache[GetCacheKey(rawKey)];
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


        public static int Insert(User User)
        {
            int id = RepositoryManager.User_Repository.Insert(User);
            InvalidateCache();
            return id;
        }

        public static bool Update(User User)
        {
            bool isExecute = RepositoryManager.User_Repository.Update(User);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.User_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static User GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "UserById" + id;
            User User = GetCacheItem(rawKey);

            if (User == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                User = RepositoryManager.User_Repository.GetById(id);
                if (User != null)
                    AddCacheItem(rawKey, User);
            }

            return User;
        }

        public static List<User> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "UserGetAll";

            List<User> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.User_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }

        public static List<User> GetAllAsync()
        {
            List<User> list = RepositoryManager.User_Repository.GetAll();

            return list;
        }


        public static User UserGetByLoginId(string LoginId)
        {
            User user = RepositoryManager.User_Repository.UserGetByLoginId(LoginId);
            return user;

        }


    }
}
