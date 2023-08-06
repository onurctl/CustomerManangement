using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManangementService.Entities.Abstract;

namespace CustomerManangementService.Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }

        [ForeignKey("Admin")]
        public int adminId { get; set; }

        [Required]
        public string nameSurname { get; set; }

        [Required]
        [Phone]
        public string phone { get; set; }

        [Required]
        public string adress { get; set; }

        public Admin Admin { get; set; }
    }
}
