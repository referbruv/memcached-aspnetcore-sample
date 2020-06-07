using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ReadersMvcApp.Models
{
    public class ReaderModel
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(250)]
        public string EmailAddress { get; set; }
        public IFormFile Work { get; set; }
        public bool IsSuccess { get; set; }
        public string WorkPath { get; set; }
        public string ReaderId { get; set; }
    }
}