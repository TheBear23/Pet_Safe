

using Microsoft.EntityFrameworkCore;

namespace Pet_Safe.Models
{
    public class Plants
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Type { get; set; }
        public  string ToxicTo { get; set; }

        DbSet<Plants> Plant { get; set; }
    }
}
