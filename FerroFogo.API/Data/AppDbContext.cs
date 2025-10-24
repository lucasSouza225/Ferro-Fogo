using FerroFogo.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FerroFogo.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Usuário",
               NormalizedName = "USUÁRIO"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "gallojunior@gmail.com",
                NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
                UserName = "gallouunior@gmail.com",
                NormalizedUserName = "GALLOJUNIOR@GMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "José Antonio Gallo Junior",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)

    // Criar seus produtos
    {
        var categorias = new[]
        {
        new Categoria { Id = 1, Nome = "Armas de Fogo" },
        new Categoria { Id = 2, Nome = "Carabinas de PCP" },
        new Categoria { Id = 3, Nome = "Carabinas de Preção" },
        new Categoria { Id = 4, Nome = "Airsoft" },
        new Categoria { Id = 5, Nome = "Camping" },
        new Categoria { Id = 6, Nome = "Chumbinhos" },
        new Categoria { Id = 7, Nome = "Acessórios" }
    };

        builder.Entity<Categoria>().HasData(categorias);
    }

  private static void SeedProdutoPadrao(ModelBuilder builder)
{
    var produtos = new List<Produto>
    {
        // Categoria 1 - Armas de Fogo (exemplo genérico e fictício)
        new Produto { Id = 1, Nome = "Simulador de Treino Tático X1", Descricao = "Equipamento fictício usado para simulações de treino.", Preco = 2500.00m, CategoriaId = 1, ImagemUrl = "simulador-tatico-x1.jpg" },
        new Produto { Id = 2, Nome = "Replica Decorativa Winchester 73", Descricao = "Réplica histórica não funcional para decoração.", Preco = 1200.00m, CategoriaId = 1, ImagemUrl = "winchester-replica.jpg" },
        new Produto { Id = 3, Nome = "Kit de Treinamento de Segurança", Descricao = "Conjunto para aulas teóricas e práticas seguras.", Preco = 890.00m, CategoriaId = 1, ImagemUrl = "kit-treinamento.jpg" },

        // Categoria 2 - Carabinas de PCP (simulações seguras)
        new Produto { Id = 4, Nome = "Carabina PCP Falcon 5.5mm", Descricao = "Equipamento esportivo de ar comprimido para uso controlado.", Preco = 3200.00m, CategoriaId = 2, ImagemUrl = "carabina-pcp-falcon.jpg" },
        new Produto { Id = 5, Nome = "Reservatório de Ar PCP 300bar", Descricao = "Tanque auxiliar para recarga de carabinas PCP.", Preco = 1500.00m, CategoriaId = 2, ImagemUrl = "reservatorio-pcp.jpg" },
        new Produto { Id = 6, Nome = "Bomba Manual PCP 4500psi", Descricao = "Bomba de alta pressão para recarregar reservatórios de PCP.", Preco = 980.00m, CategoriaId = 2, ImagemUrl = "bomba-pcp.jpg" },

        // Categoria 3 - Carabinas de Pressão
        new Produto { Id = 7, Nome = "Carabina de Pressão Thunder 4.5mm", Descricao = "Equipamento esportivo de ar comprimido com mira ajustável.", Preco = 1600.00m, CategoriaId = 3, ImagemUrl = "carabina-thunder.jpg" },
        new Produto { Id = 8, Nome = "Mira Óptica 4x32", Descricao = "Mira telescópica para equipamentos esportivos de precisão.", Preco = 430.00m, CategoriaId = 3, ImagemUrl = "mira-optica.jpg" },
        new Produto { Id = 9, Nome = "Suporte de Carabina Universal", Descricao = "Apoio ajustável para prática esportiva segura.", Preco = 250.00m, CategoriaId = 3, ImagemUrl = "suporte-carabina.jpg" },

        // Categoria 4 - Airsoft
        new Produto { Id = 10, Nome = "Réplica Airsoft M4 AEG", Descricao = "Réplica elétrica para jogos de airsoft.", Preco = 1800.00m, CategoriaId = 4, ImagemUrl = "airsoft-m4.jpg" },
        new Produto { Id = 11, Nome = "Pistola Airsoft Spring G17", Descricao = "Réplica com mola para prática de airsoft.", Preco = 450.00m, CategoriaId = 4, ImagemUrl = "airsoft-g17.jpg" },
        new Produto { Id = 12, Nome = "Esferas BBs 0.25g - 5000 unidades", Descricao = "Munição plástica para uso em réplicas de airsoft.", Preco = 80.00m, CategoriaId = 4, ImagemUrl = "bbs-025.jpg" },

        // Categoria 5 - Camping
        new Produto { Id = 13, Nome = "Barraca Tática 2 Pessoas", Descricao = "Barraca leve e resistente para acampamentos.", Preco = 600.00m, CategoriaId = 5, ImagemUrl = "barraca-2p.jpg" },
        new Produto { Id = 14, Nome = "Canivete Multiuso Explorer", Descricao = "Canivete multifunção ideal para camping e trilhas.", Preco = 120.00m, CategoriaId = 5, ImagemUrl = "canivete-explorer.jpg" },
        new Produto { Id = 15, Nome = "Lanterna Tática LED 2000lm", Descricao = "Lanterna recarregável de alto brilho.", Preco = 180.00m, CategoriaId = 5, ImagemUrl = "lanterna-led.jpg" },

        // Categoria 6 - Chumbinhos
        new Produto { Id = 16, Nome = "Chumbinho 4.5mm Premium (500 un)", Descricao = "Munição para carabinas de pressão esportivas.", Preco = 55.00m, CategoriaId = 6, ImagemUrl = "chumbinho-premium.jpg" },
        new Produto { Id = 17, Nome = "Chumbinho 5.5mm Expansivo (400 un)", Descricao = "Munição de alta precisão para prática esportiva.", Preco = 70.00m, CategoriaId = 6, ImagemUrl = "chumbinho-expansivo.jpg" },
        new Produto { Id = 18, Nome = "Chumbinho de Treino Econômico (500 un)", Descricao = "Opção de baixo custo para treinos frequentes.", Preco = 40.00m, CategoriaId = 6, ImagemUrl = "chumbinho-treino.jpg" },

        // Categoria 7 - Acessórios
        new Produto { Id = 19, Nome = "Capa de Transporte Almofadada", Descricao = "Capa resistente para transporte seguro de equipamentos esportivos.", Preco = 250.00m, CategoriaId = 7, ImagemUrl = "capa-transporte.jpg" },
        new Produto { Id = 20, Nome = "Kit de Limpeza Universal", Descricao = "Kit com escovas e hastes para manutenção de equipamentos esportivos.", Preco = 120.00m, CategoriaId = 7, ImagemUrl = "kit-limpeza.jpg" },
        new Produto { Id = 21, Nome = "Mochila de Campo Tática", Descricao = "Mochila reforçada com múltiplos compartimentos.", Preco = 350.00m, CategoriaId = 7, ImagemUrl = "mochila-tatica.jpg" }
    };

    builder.Entity<Produto>().HasData(produtos);
}

}
