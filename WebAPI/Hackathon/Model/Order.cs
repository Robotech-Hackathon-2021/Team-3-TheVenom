using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Items { get; set; }
        public string Total { get; set; }
        public string PhoneNumber { get; set; }
    }
}
