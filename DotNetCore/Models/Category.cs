using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; }
        
       

    }
}
