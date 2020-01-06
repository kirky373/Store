using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ReviewData.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Range(0, 5, ErrorMessage = "A rating must be between 0 and 5.")]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }


        public Product Product { get; set; }

    }
}
