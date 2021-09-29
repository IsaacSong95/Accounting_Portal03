using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting_Portal03.Models
{
    public class ViewModel
    {
        public Donor donor { get; set; }
        public Donation donation { get; set; }
        public Expenditure expenditure { get; set; }
    }
}