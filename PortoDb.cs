using Microsoft.EntityFrameworkCore;

namespace porto_back
{
    public class PortoDb : DbContext
    {
        public PortoDb(DbContextOptions<PortoDb> options)
            : base(options) { }
    }
}
