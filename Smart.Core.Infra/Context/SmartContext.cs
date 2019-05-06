using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Smart.Core.Domain;
using Smart.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Proxies;
using Smart.Core.Infra.Mapping;

namespace Smart.Core.Infra.Context
{
    public class SmartContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<PostagemCategoria> PostagemCategoria { get; set; }
        public DbSet<TipoMovimentacao> TipoMovimentacao { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<UsuarioInteresseCategoria> UsuarioInteresseCategoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioMovimentacao> UsuarioMovimentacao { get; set; }
        public DbSet<UsuarioPontuacao> UsuarioPontuacao { get; set; }

        public SmartContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
 
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoriaMap());
            builder.ApplyConfiguration(new ComentarioMap());
            builder.ApplyConfiguration(new PerfilMap());
            builder.ApplyConfiguration(new PerfilUsuarioMap());
            builder.ApplyConfiguration(new PostagemCategoriaMap());
            builder.ApplyConfiguration(new PostagemMap());
            builder.ApplyConfiguration(new TipoMovimentacaoMap());
            builder.ApplyConfiguration(new TipoUsuarioMap());
            builder.ApplyConfiguration(new UsuarioInteresseCategoriaMap());
            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new UsuarioMovimentacaoMap());
            builder.ApplyConfiguration(new UsuarioPontuacaoMap());
        }
    }
}
