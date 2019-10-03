using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Streams.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }

        //[Required]//Change default settings for Name in entiity framework
        //[StringLength(255)]
        public string Name { get; set; }
    }
}