using System;
using HealthCare.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HealthCare.Data
{
    // Autogeneration script
    // Scaffold-DbContext "Server=.\SQLExpress;Database=HealthCare;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -f


    public partial class HealthCareContext : DbContext
    {
        IConfiguration _configuration;


        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(
                builder =>
                {
                    builder
                      .AddFilter((category, level) =>
                                  category == DbLoggerCategory.Database.Command.Name
                                  && level == LogLevel.Information)
                      .AddDebug();
                });

        internal HealthCareContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HealthCareContext(DbContextOptions<HealthCareContext> options)
            : base(options)
        {

        }

        public virtual DbSet<ContactForm> ContactForm { get; set; }
        public virtual DbSet<Translation> Translation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder
                    .UseSqlServer(_configuration["HealthCareDBConnectionString"])
                    .UseLoggerFactory(MyLoggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactForm>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Translation>(entity =>
            {
                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("Message")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
