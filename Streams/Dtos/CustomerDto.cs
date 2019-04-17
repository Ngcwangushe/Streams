using Streams.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Streams.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]//Change default settings for Name in entiity framework
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
    
        public byte MembershipTypeId { get; set; }

       // [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}