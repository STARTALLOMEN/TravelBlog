using API.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogDestination> BlogDestination { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // public DbSet<Dictrict> Dictricts { get; set; }

        public DbSet<ImageBlog> ImageBlogs { get; set; }

        public DbSet<ImageQuestion> ImageQuestions { get; set; }

        public DbSet<ImageReview> ImageReviews { get; set; }

        public DbSet<ImageShare> ImageShares { get; set; }

        public DbSet<ImageShareDetail> ImageShareDetails { get; set; }
        public DbSet<ImageShareDestination> ImageShareDestinations { get; set; }

        public DbSet<ImageDestination> ImageDestinations { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<News> News { get; set; }
        public DbSet<MarkDestination> MarkDestinations { get; set; }

        public DbSet<Plan> Plans { get; set; }
        // public DbSet<PlanDate> PlanDates { get; set; }
        public DbSet<PlanDestination> PlanDestinations { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ReviewDestination> ReviewDestinations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TypeDestination> TypeDestinations { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<Ward> Wards { get; set; }
        public DbSet<QuestionDestination> QuestionDestinations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionDestination>()
            .HasKey(ru => new { ru.DestinationId, ru.QuestionId });
            modelBuilder.Entity<BlogDestination>()
                .HasKey(ru => new { ru.BlogId, ru.DestinationId });
            modelBuilder.Entity<ImageShareDestination>()
                .HasKey(ru => new { ru.ImageShareId, ru.DestinationId });
            // modelBuilder.Entity<PlanDateDestination>()
            //     .HasKey(ru => new { ru.PlanDateId, ru.DestinationId });
            modelBuilder.Entity<PlanDestination>()
                .HasKey(ru => new { ru.PlanId, ru.DestinationId });
            modelBuilder.Entity<ReviewDestination>()
                        .HasOne(r => r.User)
                        .WithMany(c => c.ReviewDestinations)
                        .HasForeignKey(r => r.UserId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Comment>()
                        .HasOne(r => r.User)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(r => r.UserId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Destination>()
                        .HasOne(r => r.User)
                        .WithMany(c => c.Destinations)
                        .HasForeignKey(r => r.UserId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Blog>()
                        .HasOne(r => r.User)
                        .WithMany(c => c.Blogs)
                        .HasForeignKey(r => r.UserId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Question>()
                        .HasOne(r => r.User)
                        .WithMany(c => c.Questions)
                        .HasForeignKey(r => r.UserId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<BlogDestination>()
                        .HasOne<Blog>(r => r.Blog)
                        .WithMany(c => c.BlogDestinations)
                        .HasForeignKey(sc => sc.BlogId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<BlogDestination>()
                        .HasOne<Destination>(r => r.Destination)
                        .WithMany(c => c.BlogDestinations)
                        .HasForeignKey(sc => sc.DestinationId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Like>()
                        .HasOne(r => r.Blog)
                        .WithMany(c => c.Likes)
                        .HasForeignKey(r => r.BlogId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<ImageReview>()
                        .HasOne(r => r.ReviewDestination)
                        .WithMany(c => c.ImageReviews)
                        .HasForeignKey(r => r.ReviewDestinationId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Comment>()
                        .HasOne(r => r.News)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(r => r.NewId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Comment>()
                        .HasOne(r => r.Question)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(r => r.QuestionId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Comment>()
                        .HasOne(r => r.ReviewDestination)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(r => r.ReviewDestinationId)
                        .OnDelete(DeleteBehavior.ClientCascade);
            base.OnModelCreating(modelBuilder);
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        // //string connectionString = "Server=serverhaiyen.mysql.database.azure.com; Port=3306; Database=RentalCarDatabase; Uid=haiyen@serverhaiyen; Pwd=#Hthy01042001; SslMode=Preferred;";
        // //var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        // ////var serverVersion = new MySqlServerVersion(new Version(5, 7, 0));
        // //optionsBuilder
        // //    .UseMySql(connectionString, serverVersion)
        // //    .LogTo(Console.WriteLine, LogLevel.Information)
        // //    .EnableSensitiveDataLogging()
        // //    .EnableDetailedErrors();

        //    string connectionString = "Server=localhost; Database=DestinationBlog;Trusted_Connection=True;TrustServerCertificate=True;User ID=sa; Password=01042001";
        //    optionsBuilder.UseSqlServer(connectionString);
        // }
    }
}