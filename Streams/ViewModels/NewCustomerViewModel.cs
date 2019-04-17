using Streams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Streams.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }//Table
        public Customer Customer { get; set; }//Object Type
    }
}