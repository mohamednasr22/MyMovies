using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribToNewsLetter { get; set; }
        public byte MemberShipTypeId { get; set; }

        public MembershipTypeDto MemberShipType { get; set; }

        //[Min18YearsIfAmember]
        public DateTime? Birthdate { get; set; }
    }
}