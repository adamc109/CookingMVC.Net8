using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooking.Models
{
    public class Recipie
    {
        [Key]
        public int Id { get; set; }
        [Required]
 
        public string Title { get; set; }
        [Display (Name ="List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        public string Ingredients { get; set; }

        [Display(Name = "Price 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Display(Name = "Price 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Display(Name = "Price 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }
    }
}
