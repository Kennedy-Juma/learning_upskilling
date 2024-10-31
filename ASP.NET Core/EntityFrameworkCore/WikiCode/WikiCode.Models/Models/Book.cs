using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiCode.Models.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }
    }
}
