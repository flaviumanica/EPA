    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
namespace Stiri
{

    public interface IFake
    {
        DbSet<Articol> Articol { get; set; }
        DbSet<Categorii> Categorii { get; set; }
        DbSet<Comentarii> Comentarii { get; set; }
        DbSet<Imagine> Imagine { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Stiri_Propuse> Stiri_Propuse { get; set; }
        DbSet<Table> Table { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserInRoles> UserInRoles { get; set; }

        int SaveChanges();
    }

    public class StiriFakeDb : DbContext, IFake
    {
        public StiriFakeDb()
        {
            Articol = new TestDbSet<Articol>();
            Categorii = new TestDbSet<Categorii>();
            Comentarii = new TestDbSet<Comentarii>();
            Imagine = new TestDbSet<Imagine>();
            Roles = new TestDbSet<Roles>();
            Stiri_Propuse = new TestDbSet<Stiri_Propuse>();
            Table = new TestDbSet<Table>();
            User = new TestDbSet<User>();
            UserInRoles = new TestDbSet<UserInRoles>();
            CreateFakeData();
        }

        private void CreateFakeData()
        {
            User.Add(new User()
            {
                Id = 1,
                Nume = "Unu",
                Prenume = "User",
                Email = "user1@email.test",
                Username = "User1",
                Parola = "parola"
            });

            Categorii.Add(new Categorii()
            {
                Id = 1,
                Nume = "Articole sportive"
            });

            Articol.Add(new Articol()
            {
                Id = 1,
                Id_User = 1,
                Titlu = "Articol 1",
                Descriere = "Descriere articol 1",
                Continut = "Articol 1 continut: Stirea zilei este:...",
                Categorie = 1
            });

            Articol.Add(new Articol()
            {
                Id = 2,
                Id_User = 1,
                Titlu = "Articol 2",
                Descriere = "Descriere articol 2",
                Continut = "Articol 2 continut: Stirea zilei este:...",
                Categorie = 1
            });
        }

        public int SaveChangesCount { get; private set; }

        public virtual DbSet<Articol> Articol { get; set; }
        public virtual DbSet<Categorii> Categorii { get; set; }
        public virtual DbSet<Comentarii> Comentarii { get; set; }
        public virtual DbSet<Imagine> Imagine { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Stiri_Propuse> Stiri_Propuse { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInRoles> UserInRoles { get; set; }

        public override int SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        }
    }

    public partial class StiriDb : DbContext, IFake
    {
        public StiriDb()
            : base("name=StiriDB")
        {
        }

        public virtual DbSet<Articol> Articol { get; set; }
        public virtual DbSet<Categorii> Categorii { get; set; }
        public virtual DbSet<Comentarii> Comentarii { get; set; }
        public virtual DbSet<Imagine> Imagine { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Stiri_Propuse> Stiri_Propuse { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInRoles> UserInRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articol>()
                .Property(e => e.Titlu)
                .IsUnicode(false);

            modelBuilder.Entity<Articol>()
                .Property(e => e.Continut)
                .IsUnicode(false);

            modelBuilder.Entity<Articol>()
                .Property(e => e.Descriere)
                .IsUnicode(false);

            modelBuilder.Entity<Articol>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Articol>()
                .HasMany(e => e.Imagine)
                .WithRequired(e => e.Articol)
                .HasForeignKey(e => e.Id_Articol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Articol>()
                .HasMany(e => e.Comentarii)
                .WithRequired(e => e.Articol)
                .HasForeignKey(e => e.Id_Articol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categorii>()
                .Property(e => e.Nume)
                .IsUnicode(false);

            modelBuilder.Entity<Categorii>()
                .HasMany(e => e.Articol)
                .WithRequired(e => e.Categorii)
                .HasForeignKey(e => e.Categorie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categorii>()
                .HasMany(e => e.Table)
                .WithRequired(e => e.Categorii)
                .HasForeignKey(e => e.Categorie_propunere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categorii>()
                .HasMany(e => e.Stiri_Propuse)
                .WithRequired(e => e.Categorii)
                .HasForeignKey(e => e.Categorie_propunere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comentarii>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Imagine>()
                .Property(e => e.Cale)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.UserInRoles)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.Id_Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stiri_Propuse>()
                .Property(e => e.Titlu_propunere)
                .IsUnicode(false);

            modelBuilder.Entity<Stiri_Propuse>()
                .Property(e => e.Continut_propunere)
                .IsUnicode(false);

            modelBuilder.Entity<Stiri_Propuse>()
                .Property(e => e.Imagine_propunere)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Titlu_propunere)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Continut_propunere)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Imagine_propunere)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Parola)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Articol)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Id_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comentarii)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Id_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Stiri_Propuse)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_propunere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserInRoles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Id_User)
                .WillCascadeOnDelete(false);
        }
    }
}