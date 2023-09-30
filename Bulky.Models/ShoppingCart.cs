using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models
{
    public class ShoppingCart
    {
        //public int Id { get; set; }
        //public int RecipeId { get; set; }
        //[ForeignKey("RecipieId")]
        //[ValidateNever]
        //public Recipie Recipie { get; set; }
        //[Range(1,1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        //public int Count { get; set; }
        //public string ApplicationUserId { get; set; }
        //[ForeignKey("ApplicationUserId")]
        //[ValidateNever]
        //public ApplicationUser ApplicationUser { get; set; }
        public int Id { get; set; }

        public int RecipieId { get; set; }
        [ForeignKey("RecipieId")]
        [ValidateNever]
        public Recipie Recipie { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
