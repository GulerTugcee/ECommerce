using ECommerce.Business.Abstract;
using System.Linq;
using Microsoft.Extensions.Caching;
using System;
using Microsoft.Extensions.Caching.Memory;//IMemoryCache
using System.Collections.Concurrent;//ConcurrentBag
using System.Collections.Generic;

namespace ECommerce.Business.Caching
{
    public class MemoryCacheManager : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;// _ ekledik
         public static ConcurrentBag<string> keys = new ConcurrentBag<string>();
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache; // ctor
        }
        public void Clear()
        {
            foreach (var item in keys.ToList())
            {
                Delete(item);
                RemoveKey(item);
            }
        }

        public void Clear(string header)
        {
            // product_1
            var list = keys.AsQueryable().Where(x => x.StartsWith(header)).ToList();
            foreach (var item in list)
            {
                Delete(item);
                RemoveKey(item);//---
            }
        }

        public void Delete(string key)
        {
            _memoryCache.Remove(key);
            RemoveKey(key);
        }

        public T Get<T>(string key, Func<T> act)
        {
            var result = _memoryCache.Get<T>(key);
            if (result == null)
            {
                Delete(key);
            }
            return result;
        }

        public void Set(string key, object data)
        {
            _memoryCache.Set(key, data);
        }
        private void AddKey(string key)
        {
            keys.Add(key);
        }
        private void RemoveKey(string key)
        {
            var data = keys.AsQueryable().Where(x => x == key).FirstOrDefault();
            if (data != null)
            {
                data = null;
            }
            keys.ToList().Remove(key);
        }
    }
}
