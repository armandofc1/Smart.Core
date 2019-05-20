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
        public DbSet<Postagem> Postagem { get; set; }
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
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            //optionsBuilder.UseOracle(configuration.GetConnectionString("Oracle"));
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            //optionsBuilder.UseLazyLoadingProxies(); na api carrega dados desnecessarios
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

            PopularDados(builder);
        }

        private void PopularDados(ModelBuilder builder)
        {
            #region Categorias
            builder.Entity<Categoria>().HasData(new Categoria
            {
                Codigo = 1,
                Nome = "Artesenato",
                Descricao = "Para se fazer em casa"
            }, new Categoria
            {
                Codigo = 2,
                Nome = "Tutorials",
                Descricao = "Guia passo a passo"
            }, new Categoria
            {
                Codigo = 3,
                Nome = "JavaScript",
                Descricao = "JavaScript"
            }, new Categoria
            {
                Codigo = 4,
                Nome = "HTML",
                Descricao = "HTML"
            }, new Categoria
            {
                Codigo = 5,
                Nome = "CSS",
                Descricao = "CSS"
            }, new Categoria
            {
                Codigo = 6,
                Nome = "Web Design",
                Descricao = "Web Design"
            }, new Categoria
            {
                Codigo = 7,
                Nome = "Freebies",
                Descricao = "Freebies"
            });
            #endregion Categorias

            #region TipoUsuario
            builder.Entity<TipoUsuario>().HasData(new TipoUsuario
            {
                Codigo = 1,
                Tipo = "Administrador"
            }, new TipoUsuario
            {
                Codigo = 2,
                Tipo = "Moderador"
            }, new TipoUsuario
            {
                Codigo = 3,
                Tipo = "Usuário"
            });
            #endregion TipoUsuario

            #region Usuarios
            builder.Entity<Usuario>().HasData(new Usuario
            {
                Codigo = 1,
                DataCadastro = DateTime.Now,
                TipoUsuarioCodigo = 1,
                Nome = "Armando",
                SobreNome = "Costa",
                Sexo = "M",
                Login = "admin",
                Senha = "admin",
                Email = "armandofc1@gmail.com",
                Foto = String.Empty,
                Status = 1
            }, new Usuario
            {
                Codigo = 2,
                DataCadastro = DateTime.Now,
                TipoUsuarioCodigo = 3,
                Nome = "João",
                SobreNome = "da Silva",
                Sexo = "M",
                Login = "jpsilva",
                Senha = "123",
                Email = "joao@site.com.br",
                Foto = "images/usuarios/rotating_card_profile3.png",
                Status = 1
            }, new Usuario
            {
                Codigo = 3,
                DataCadastro = DateTime.Now,
                TipoUsuarioCodigo = 3,
                Nome = "André",
                SobreNome = "Oswaldo",
                Sexo = "M",
                Login = "andreow",
                Senha = "123",
                Email = "andreow@site.com.br",
                Foto = "images/usuarios/rotating_card_profile2.png",
                Status = 1
            }, new Usuario
            {
                Codigo = 4,
                DataCadastro = DateTime.Now,
                TipoUsuarioCodigo = 3,
                Nome = "Maria",
                SobreNome = "das Dores",
                Sexo = "F",
                Login = "mdores",
                Senha = "123",
                Email = "mdores@site.com.br",
                Foto = "images/usuarios/rotating_card_profile.png",
                Status = 1
            }, new Usuario
            {
                Codigo = 5,
                DataCadastro = DateTime.Now,
                TipoUsuarioCodigo = 3,
                Nome = "Martino",
                SobreNome = "Mont",
                Sexo = "M",
                Login = "MartinoMont",
                Senha = "123",
                Email = "martinomont@site.com.br",
                Foto = "images/usuarios/user_1.jpg",
                Status = 1
            }, new Usuario
            {
                Codigo = 6,
                DataCadastro = DateTime.Now,
                TipoUsuarioCodigo = 3,
                Nome = "Laurence",
                SobreNome = "Correil",
                Sexo = "F",
                Login = "LaurenceCorreil",
                Senha = "123",
                Email = "laurencecorreil@site.com.br",
                Foto = "images/usuarios/user_2.jpg",
                Status = 1
            }, new Usuario
            {
                Codigo = 7,
                DataCadastro = DateTime.Now,
                TipoUsuarioCodigo = 3,
                Nome = "John",
                SobreNome = "Nida",
                Sexo = "M",
                Login = "JohnNida",
                Senha = "123",
                Email = "johnnida@site.com.br",
                Foto = "images/usuarios/user_3.jpg",
                Status = 1
            });
            #endregion Usuarios
            
            #region Postagens
            builder.Entity<Postagem>().HasData(new Postagem
            {
                Codigo = 1,
                UsuarioCodigo = 2,
                DataCriacao = DateTime.Now,
                Titulo = "Qual a melhor divisão de treino?",
                Subtitulo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Resumo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Conteudo = @"<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>",
                Foto = "images/postagens/blog-5.jpg",
                DataInicial = new DateTime(2019, 05, 1),
                DataFinal = new DateTime(2019, 12, 31),
                Status = 1
            }, new Postagem
            {
                Codigo = 2,
                UsuarioCodigo = 3,
                DataCriacao = DateTime.Now,
                Titulo = "Como obter fotos profissionais usando o celular",
                Subtitulo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Resumo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Conteudo = @"<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>",
                Foto = "images/postagens/fotos_com_celular.jpg",
                DataInicial = new DateTime(2019, 05, 1),
                DataFinal = new DateTime(2019, 12, 31),
                Status = 1
            }, new Postagem
            {
                Codigo = 3,
                UsuarioCodigo = 4,
                DataCriacao = DateTime.Now,
                Titulo = "Aprenda a tingir o cabelo sozinho",
                Subtitulo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Resumo = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
Lorem ipsum dolor sit amet, consectetur adipiscing",
                Conteudo = @"<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>",
                Foto = "images/postagens/cortar_cabelo.jpg",
                DataInicial = new DateTime(2019, 05, 1),
                DataFinal = new DateTime(2019, 12, 31),
                Status = 1
            });
            #endregion Postagens

            #region PostagemCategoria
            builder.Entity<PostagemCategoria>().HasData(new PostagemCategoria
            {
                PostagemCodigo = 1,
                CategoriaCodigo = 1
            }, new PostagemCategoria
            {
                PostagemCodigo = 1,
                CategoriaCodigo = 2
            }, new PostagemCategoria
            {
                PostagemCodigo = 1,
                CategoriaCodigo = 3
            }, new PostagemCategoria
            {
                PostagemCodigo = 2,
                CategoriaCodigo = 3
            }, new PostagemCategoria
            {
                PostagemCodigo = 2,
                CategoriaCodigo = 4
            }, new PostagemCategoria
            {
                PostagemCodigo = 3,
                CategoriaCodigo = 2
            });
            #endregion PostagemCategoria

            #region TipoMovimentacao
            builder.Entity<TipoMovimentacao>().HasData(new TipoMovimentacao
            {
                Codigo = 1,
                Tipo = "Crédito"
            }, new TipoMovimentacao
            {
                Codigo = 2,
                Tipo = "Débito"
            });
            #endregion TipoMovimentacao

            #region UsuarioPontuacao
            builder.Entity<UsuarioPontuacao>().HasData(new UsuarioPontuacao
            {
                UsuarioCodigo = 1,
                PontosSaldo = 1500
            }, new UsuarioPontuacao
            {
                UsuarioCodigo = 2,
                PontosSaldo = 500
            }, new UsuarioPontuacao
            {
                UsuarioCodigo = 3,
                PontosSaldo = 400
            }, new UsuarioPontuacao
            {
                UsuarioCodigo = 4,
                PontosSaldo = 300
            });
            #endregion TipoMovimentacao

            #region Perfil
            builder.Entity<Perfil>().HasData(new Perfil
            {
                Codigo = 1,
                Nome = "Administrador"
            }, new Perfil
            {
                Codigo = 2,
                Nome = "Moderador"
            }, new Perfil
            {
                Codigo = 3,
                Nome = "Usuário"
            });
            #endregion Perfil

            #region PerfilUsuario
            builder.Entity<PerfilUsuario>().HasData(new PerfilUsuario
            {
                UsuarioCodigo = 1,
                PerfilCodigo = 1
            }, new PerfilUsuario
            {
                UsuarioCodigo = 2,
                PerfilCodigo = 2
            }, new PerfilUsuario
            {
                UsuarioCodigo = 3,
                PerfilCodigo = 3
            }, new PerfilUsuario
            {
                UsuarioCodigo = 4,
                PerfilCodigo = 3
            });
            #endregion PerfilUsuario

            #region UsuarioInteresseCategoria
            builder.Entity<UsuarioInteresseCategoria>().HasData(new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 1,
                CategoriaCodigo = 1
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 1,
                CategoriaCodigo = 2
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 1,
                CategoriaCodigo = 3
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 1,
                CategoriaCodigo = 4
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 2,
                CategoriaCodigo = 1
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 3,
                CategoriaCodigo = 2
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 4,
                CategoriaCodigo = 3
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 5,
                CategoriaCodigo = 4
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 6,
                CategoriaCodigo = 5
            }, new UsuarioInteresseCategoria
            {
                UsuarioCodigo = 7,
                CategoriaCodigo = 6
            });
            #endregion UsuarioInteresseCategoria

            #region Comentario
            builder.Entity<Comentario>().HasData(new Comentario
            {
                Codigo = 1,
                UsuarioCodigo = 5,
                PostagemCodigo = 1,
                DataCriacao = DateTime.Now,
                Conteudo = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, <a href=""#"">#consecteturadipiscing</a>",
                Status = 1
            }, new Comentario
            {
                Codigo = 2,
                UsuarioCodigo = 6,
                PostagemCodigo = 1,
                DataCriacao = DateTime.Now,
                Conteudo = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor <a href=""#"">#ipsumdolor</a> adipiscing elit.",
                Status = 1
            }, new Comentario
            {
                Codigo = 3,
                UsuarioCodigo = 7,
                PostagemCodigo = 1,
                DataCriacao = DateTime.Now,
                Conteudo = @"Lorem ipsum dolor <a href=""#"">#ipsumdolor</a> sit amet, consectetur adipiscing elit.",
                Status = 1
            }, new Comentario
            {
                Codigo = 4,
                UsuarioCodigo = 6,
                PostagemCodigo = 2,
                DataCriacao = DateTime.Now,
                Conteudo = @"Lorem ipsum dolor <a href=""#"">#ipsumdolor</a> sit amet, consectetur adipiscing elit.",
                Status = 1
            });
            #endregion Comentario

            #region UsuarioMovimentacao
            builder.Entity<UsuarioMovimentacao>().HasData(new UsuarioMovimentacao
            {
                Codigo = 1,
                TipoMovimentacaoCodigo = 1,
                DataCadastro = DateTime.Now,
                UsuarioOrigemCodigo = 3,
                UsuarioDestinoCodigo = 2,
                PostagemCodigo = 1,
                Pontos = 10
            }, new UsuarioMovimentacao
            {
                Codigo = 2,
                TipoMovimentacaoCodigo = 1,
                DataCadastro = DateTime.Now,
                UsuarioOrigemCodigo = 4,
                UsuarioDestinoCodigo = 2,
                PostagemCodigo = 1,
                Pontos = 20
            }, new UsuarioMovimentacao
            {
                Codigo = 3,
                TipoMovimentacaoCodigo = 2,
                DataCadastro = DateTime.Now,
                UsuarioOrigemCodigo = 2,
                UsuarioDestinoCodigo = 3,
                PostagemCodigo = 2,
                Pontos = 15
            }, new UsuarioMovimentacao
            {
                Codigo = 4,
                TipoMovimentacaoCodigo = 1,
                DataCadastro = DateTime.Now,
                UsuarioOrigemCodigo = 2,
                UsuarioDestinoCodigo = 4,
                PostagemCodigo = 1,
                Pontos = 40
            });
            #endregion UsuarioMovimentacao

        }


    }
}
