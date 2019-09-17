using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Streams.Dtos
{
    public class NewRentalDto
    {
        public byte CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}