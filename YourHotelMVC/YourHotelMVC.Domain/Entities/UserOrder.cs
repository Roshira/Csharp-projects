using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourHotelMVC.Models.Entities;

namespace YourHotelMVC.Domain.Entities
{
    public class UserOrder
    {
        public User User { get; set; }
        public Room Room { get; set; }

        public bool food { get; set; }
        public DateTime Check_In {  get; set; }
        public DateTime Check_Out { get; set; }

    }
}
