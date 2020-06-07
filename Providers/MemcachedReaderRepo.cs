using System;
using System.Linq;
using Enyim.Caching;
using ReadersMvcApp.Models.Entities;

namespace ReadersMvcApp.Providers.Repositories
{
    public class MemcachedReaderRepo : IReaderRepo
    {
        private readonly IReaderRepo repo;
        private readonly IMemcachedClient cache;
        private const int cacheSeconds = 600;

        public MemcachedReaderRepo(IReaderRepo repo, IMemcachedClient cache)
        {
            this.repo = repo;
            this.cache = cache;
        }

        public IQueryable<Reader> Readers => this.repo.Readers;

        public Reader AddReader(Reader reader)
        {
            var record = this.repo.AddReader(reader);

            if (this.cache.Add(record.Id.ToString(), record, cacheSeconds))
            {
                Console.WriteLine("Added Record to Cache");
            }

            return record;
        }

        public Reader GetReader(Guid id)
        {
            Reader record = this.cache.Get<Reader>(id.ToString());

            if (record == null)
            {
                record = this.repo.GetReader(id);
                this.cache.Add(record.Id.ToString(), record, cacheSeconds);
            }

            return record;
        }
    }
}