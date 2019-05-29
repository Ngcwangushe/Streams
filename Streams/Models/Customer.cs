using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Streams.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]//Change default settings for Name in entiity framework
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        
        public MembershipType MembershipType { get; set; }//Navigation Property
        //Allows navigation from one type to another
        //lode an object and its related object from the databasex
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }//Mind convension/Foreign key

        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}
