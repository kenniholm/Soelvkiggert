using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLogin.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public string ImagePath { get; set; }


        ICollection<PaymentInterval> PaymentIntervals { get; set; }
    }
}
