using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grocery.API.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public int ItemListId { get; set; }
    }

}