using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grocery.API.Models
{
    public class ItemList
    {
        public int Id { get; set; }
        [Required]
        public string ListName { get; set; }

        public virtual List<Item> Items { get; set; }

    }
}