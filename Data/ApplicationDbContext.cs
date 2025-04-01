using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MYDIARY.Models;

namespace MyDiary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet <DiaryEntry> DiaryEntries {get; set;} 

        //add seed into db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { 
                    Id = 1, 
                    Title = "Went on a walk", 
                    Content = "Went on a long walk with Jenn.", 
                    CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00)
                    },

                new DiaryEntry { 
                    Id = 2, 
                    Title = "Baked brownies", 
                    Content = "Bake some double chocolate brownies.", 
                    CreatedAt = new DateTime(2024, 03, 25, 10, 00, 00)
                    },

                new DiaryEntry { 
                    Id = 3, 
                    Title = "Went for movies", 
                    Content = "Went for movies with Jenn.", 
                    CreatedAt = new DateTime(2024, 04, 01, 12, 00, 00)
                    }

            );
        }     
        
    }
}