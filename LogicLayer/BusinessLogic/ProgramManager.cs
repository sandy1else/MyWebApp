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
    public class ProgramManager
    {
        #region Cache

        public static readonly string[] MasterCacheKeyArray = { "ProgramCache" };
        const double CacheDuration = 5.0;

        public static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }

        public static List<Program> GetCacheAsList(string rawKey)
        {
            List<Program> list = (List<Program>)HttpRuntime.Cache[GetCacheKey(rawKey)];
            return list;
        }

        public static Program GetCacheItem(string rawKey)
        {
            Program item = (Program)HttpRuntime.Cache[GetCacheKey(rawKey)];
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
        

        public static int Insert(Program program)
        {
            int id = RepositoryManager.Program_Repository.Insert(program);
            InvalidateCache();
            return id;
        }

        public static bool Update(Program program)
        {
            bool isExecute = RepositoryManager.Program_Repository.Update(program);
            InvalidateCache();
            return isExecute;
        }

        public static bool Delete(int id)
        {
            bool isExecute = RepositoryManager.Program_Repository.Delete(id);
            InvalidateCache();
            return isExecute;
        }

        public static Program GetById(int? id)
        {
            // return RepositoryAdmission.Program_Repository.GetById(id);

            string rawKey = "ProgramById" + id;
            Program program = GetCacheItem(rawKey);

            if (program == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                program = RepositoryManager.Program_Repository.GetById(id);
                if (program != null)
                    AddCacheItem(rawKey, program);
            }

            return program;
        }
          
        public static List<Program> GetAll()
        {
            // return RepositoryAdmission.Program_Repository.GetAll();

            const string rawKey = "ProgramGetAll";

            List<Program> list = GetCacheAsList(rawKey);

            if (list == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                list = RepositoryManager.Program_Repository.GetAll();
                if (list != null)
                    AddCacheItem(rawKey, list);
            }

            return list;
        }
         

    }
}
