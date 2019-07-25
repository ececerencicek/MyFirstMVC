using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Kategori Adı")]

        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}