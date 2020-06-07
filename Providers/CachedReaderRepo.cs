using Microsoft.Extensions.Caching.Memory;
using ReadersMvcApp.Models.Entities;
using System;
using System.Linq;

namespace ReadersMvcApp.Providers.Repositories
{
    public class CachedReaderRepo : IReaderRepo
    {
        private readonly IReaderRepo repo;
        private readonly IMemoryCache cache;

        public CachedReaderRepo(IReaderRepo repo, IMemoryCache cache)
        {
            this.repo = repo;
            this.cache = cache;
        }

        public Reader AddReader(Reader reader)
        {
            var result = repo.AddReader(reader);

            return cache.Set(result.Id, result);
        }

        public Reader GetReader(Guid id)
        {
            Reader reader;

            if (!cache.TryGetValue(id, out reader))
            {
                var record = repo.GetReader(id);

                if (record != null)
                {
                    return cache.Set(record.Id, record);
                }
            }
            
            return reader;
        }

        public IQueryable<Reader> Readers => repo.Readers;
    }
}