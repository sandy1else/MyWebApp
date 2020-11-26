﻿using LogicLayer.BusinessObject;
using LogicLayer.DataLogic.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LogicLayer.BusinessLogic
{
    public class SessionManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "SessionCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<Session> GetCacheAsList(string rawKey)
        {
            List<Session> list = (List<Session>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static Session GetCacheItem(string rawKey)
        {
            Session item = (Session)HttpRuntime.Cache[GetCacheKey(rawKey)];
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
        

        public static int Insert(Session session)
        {
            int id = RepositoryManager.Session_Repository.Insert(session);
            InvalidateCache();
            return id;
        }

        public static bool Update(Session session)
        {
            bool isExecute = RepositoryManager.Session_Repository.Update(session);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.Session_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static Session GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "SessionById" + id;
            Session Session = GetCacheItem(rawKey);

            if (Session == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Session = RepositoryManager.Session_Repository.GetById(id);
                if (Session != null)
                    AddCacheItem(rawKey, Session);
            }

            return Session;
        }
          
        public static List<Session> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "SessionGetAll";

            List<Session> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.Session_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }
         
    }
}
