using Microsoft.EntityFrameworkCore;
using MyAwesomeBlog.Core.Models;

namespace MyAwesomeBlog.Core;

public class MyAwesomeBlogContext : DbContext
{
	public MyAwesomeBlogContext(DbContextOptions<MyAwesomeBlogContext> options)
		: base(options)
	{
	}

    public DbSet<Post> Posts { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Rate> Rates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>(p =>
        {
            p.HasKey(p => p.Id);
            
            p.Property(p => p.Title).HasMaxLength(100).IsRequired();
            p.HasIndex(p => p.Title).IsUnique();

            p.Property(p => p.Slug).HasMaxLength(50).IsRequired();
            p.HasIndex(p => p.Slug).IsUnique();
        });

        modelBuilder.Entity<Comment>(c =>
        {
            c.HasKey(c => c.Id);

            c.Property(c => c.Author).HasMaxLength(50).IsRequired();

            c.Property(c => c.Content).HasMaxLength(255).IsRequired();
            c.HasIndex(c => c.Content);

            c.HasOne(c => c.Post).WithMany().HasForeignKey(c => c.PostId);
        });

        modelBuilder.Entity<Rate>(r =>
        {
            r.HasKey(r => r.Id);
            r.HasOne(r => r.Post).WithMany().HasForeignKey(r => r.PostId);
        });
    }
}
