using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTS.Shared;

namespace ProjetoTS.Server
{
    public class ApplicationDBContext : DbContext
    {
        

        
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Desenvolvedora> Desenvolvedoraes { get; set; }
        public DbSet<TagGame> TagGames { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DetalheGame> DetalheGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//criando a chave composta com fluent API
        {
            //modelBuilder.Entity<Desenvolvedora>().HasNoKey();
              
            modelBuilder.Entity<Desenvolvedora>().HasKey(x => new { x.IdDesenvolvedora});


            //------------------------------------------ Um pra um
            modelBuilder.Entity<DetalheGame>().HasKey(x => new { x.IdGame});

            modelBuilder.Entity<Game>()
            .HasOne(a => a.DetalheGame)
            .WithOne(a => a.Game)
            .HasForeignKey<DetalheGame>(c => c.IdGame);//Fazendo a ligação de um pra um

            //------------------------------------------ Muitos Pra Muitos
            modelBuilder.Entity<TagGame>().HasKey(x => new { x.TagId, x.Id });//Ele recebe as "primary key" das tabelas Tag e game 


            modelBuilder.Entity<TagGame>().HasOne(xy => xy.tag)//TagGame tem 1 tag
                .WithMany(x => x.TagGame)//Com muitos TagGames
                .HasForeignKey(xy => xy.TagId);//Com foreign key de tag

            modelBuilder.Entity<TagGame>().HasOne(xy => xy.game)
                .WithMany(y => y.TagGame)
                .HasForeignKey(xy => xy.Id);
        }
    }
}