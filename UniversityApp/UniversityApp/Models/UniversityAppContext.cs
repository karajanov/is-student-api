using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UniversityApp.Models
{
    public class UniversityAppContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public UniversityAppContext(DbContextOptions<UniversityAppContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }

        public virtual DbSet<Transcript> Transcripts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

    }
}
