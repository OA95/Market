using Market.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Infrastructure.Data
{
    public class MarketDBContext : DbContext
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MarketDBContext(DbContextOptions<MarketDBContext> options) : base(options)
        {
        
        }

        public MarketDBContext(DbContextOptions<MarketDBContext> options,IMediator mediator,IHttpContextAccessor httpContextAccessor) : base(options) 
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(entity => entity.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Description)
                       .IsRequired()
                       .HasMaxLength (1000);
                
                entity.Property(e=>  e.Price)
                        .HasColumnType("decimal(18,2)")
                        .IsRequired();

                // Index pour améliorer les performances de recherche
                entity.HasIndex(e => e.Name);
            });


            // Données de test (optionnel)
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop Dell XPS 13",
                    Description = "Ordinateur portable ultrabook 13 pouces",
                    Price = 1299.99m
                },
                new Product
                {
                    Id = 2,
                    Name = "iPhone 15 Pro",
                    Description = "Smartphone Apple dernière génération",
                    Price = 999.99m
                },
                new Product
                {
                    Id = 3,
                    Name = "Casque Sony WH-1000XM4",
                    Description = "Casque audio sans fil à réduction de bruit",
                    Price = 299.99m
                }
            );
        }
    }
}
