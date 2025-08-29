using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.EntityLayer.Concerte
{
    public class Process
    {
        public int ProcessID { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public decimal Amount { get; set; }
    }
}
