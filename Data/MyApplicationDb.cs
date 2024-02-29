using Microsoft.EntityFrameworkCore;
using Sportrs_Streaming_platform.Models;

namespace Sportrs_Streaming_platform.Data
{
    public class MyApplicationDb:DbContext
    {
        public MyApplicationDb(DbContextOptions options) : base(options)
        {
                    
        }

        public DbSet<User> Admin { get; set;}
        public object Users { get; internal set; }
    }
}
