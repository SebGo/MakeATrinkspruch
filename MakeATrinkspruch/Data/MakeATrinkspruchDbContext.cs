using MakeATrinkspruch.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MakeATrinkspruch.Data
{
    public class MakeATrinkspruchDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string sqliteFileName = "MakeATrinkspruch.db3";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); //Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "MakeATrinkspruch");
            string path = Path.Combine(documentsDirectoryPath, sqliteFileName);

            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toast>().HasKey(t => t.Id);
            modelBuilder.Entity<Toast>().Property(o => o.Id).HasDefaultValueSql("newid()");
            modelBuilder.Entity<Toast>().HasIndex(x => x.ToastText).IsUnique();
            modelBuilder.Entity<Toast>()
                           .Property(s => s.ToastText)
                           .IsRequired();

            modelBuilder.Entity<Keyword>().HasKey(t => t.Id);
            modelBuilder.Entity<Keyword>().Property(o => o.Id).HasDefaultValueSql("newid()");
            modelBuilder.Entity<Keyword>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Keyword>()
                           .Property(s => s.Name)
                           .IsRequired();

            modelBuilder.Entity<ToastKeyword>().HasKey(tk => new { tk.ToastId, tk.KeywordId });
            modelBuilder.Entity<ToastKeyword>()
                .HasOne<Toast>(sc => sc.Toast)
                .WithMany(s => s.ToastKeywords)
                .HasForeignKey(sc => sc.ToastId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ToastKeyword>()
                .HasOne<Keyword>(sc => sc.Keyword)
                .WithMany(s => s.ToastKeywords)
                .HasForeignKey(sc => sc.KeywordId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Toast> Toasts { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<ToastKeyword> ToastKeywords { get; set; }
    }
}