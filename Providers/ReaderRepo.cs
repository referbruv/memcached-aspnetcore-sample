using System;
using System.Collections.Generic;
using System.Linq;
using ReadersMvcApp.Models.Entities;

namespace ReadersMvcApp.Providers.Repositories
{
    public interface IReaderRepo
    {
        IQueryable<Reader> Readers { get; }

        Reader GetReader(Guid id);

        Reader AddReader(Reader reader);
    }

    public class ReaderRepo : IReaderRepo
    {
        private List<Reader> _readers;

        public ReaderRepo()
        {
            _readers = this.Seed().ToList();
        }

        private IEnumerable<Reader> Seed()
        {
            int id;
            for (int i = 1; i <= 10; i++)
            {
                id = 1000 + i;
                yield return new Reader()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Reader#{id}",
                    EmailAddress = $"reader.{id}@abc.com",
                    AddedOn = DateTime.Now
                };
            }
        }

        public Reader AddReader(Reader reader)
        {
            reader.Id = Guid.NewGuid();
            reader.AddedOn = DateTime.Now;
            _readers.Add(reader);
            return reader;
        }

        public Reader GetReader(Guid id)
        {
            return _readers.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Reader> Readers => _readers.AsQueryable();
    }
}