using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManangementService.Entities.DTOs
{
    public class CustomerDTO
    {
        public int customerId { get; set; }
        public string Admin { get; set; }

        public string nameSurname { get; set; }

        public string phone { get; set; }

        public string adress { get; set; }
    }
}
