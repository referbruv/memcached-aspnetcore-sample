using System;

namespace ReadersMvcApp.Models.Entities
{
    public class Reader
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string WorkPath { get; set; }
        public DateTime AddedOn { get; set; }
    }
}