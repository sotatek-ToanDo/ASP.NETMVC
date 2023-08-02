using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETMVC.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Required]
        public string FullName { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        public DateTime ? DateSent { get; set; }

        public string Message { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
    }
}
