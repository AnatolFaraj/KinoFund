using Core.Models;
using DAL.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.data
{
    public class MyContext : DbContext
    {
        

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CollectionModel> Collections { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        public DbSet<CredentialModel> Credentials { get; set; }
        public DbSet<MovieModel> Movies { get; set; }

        public DbSet<MovieDetailModel> MovieDetails { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CollectionConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CredentialConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieDetailConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            



        }
    }
}
