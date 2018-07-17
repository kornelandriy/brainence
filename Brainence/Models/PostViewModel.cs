using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Brainence.Models
{
    public class PostViewModel
    {
        [Required]
        public string Word { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}