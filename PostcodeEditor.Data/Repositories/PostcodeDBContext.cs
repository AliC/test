using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostcodeEditor.Data.Repositories
{
    public class PostcodeDbContext : DbContext
    {
        public DbSet<PostcodeDetails> Postcodes { get; set; }

    }
}
