﻿using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Persistence.Context
{
    public class MovieContext :DbContext
    {
        //public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=Server=SELIMBAYINDIR\\SUPERHERO;Initial Catalog=MovieDb;Integrated Security=true");

            optionsBuilder.UseSqlServer("Server=SELIMBAYINDIR\\SUPERHERO;Database=ApiMovieDb;User Id=dw;Password=0000;TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer("Server=SELIM\\BYNDR;Database=ApiMovieDb;User Id=dw;Password=0000;TrustServerCertificate=True;");


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cast> Casts { get; set; }

    }
}
