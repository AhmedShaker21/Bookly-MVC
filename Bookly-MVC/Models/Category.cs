﻿using System.ComponentModel.DataAnnotations;

namespace Bookly_MVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
