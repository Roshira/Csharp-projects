using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourHotelMVC.Models.Entities;

namespace YourHotelMVC.Models
{
    public class YourHotelMVCDbContext : IdentityDbContext<User>
    {
        public YourHotelMVCDbContext(DbContextOptions<YourHotelMVCDbContext> options)
        : base(options) 
        {
        }
    }
}
