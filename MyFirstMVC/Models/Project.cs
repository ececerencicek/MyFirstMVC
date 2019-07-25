using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstMVC.Models
{
    public class Project
    {
        //Entityler
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Uygulama Adı")]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Body")]
        [DataType(DataType.Html)]
        public string Body { get; set; }
        public string Photo { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}