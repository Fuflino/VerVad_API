using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class GlobalGoalContext : IdentityDbContext<ApplicationUser>
    {
        public GlobalGoalContext() : base("DefaultConnection", false)
        {            
            Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer(new DbInit());
        }

        public static GlobalGoalContext Create()
        {
            return new GlobalGoalContext();
        }

        public virtual DbSet<GlobalGoal> Global_Goals { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<FrontPage> FrontPage { get; set; }
        public virtual DbSet<Translation> Texts { get; set; }
        public virtual DbSet<ChildrensText> ChildrensTexts { get; set; }
        public virtual DbSet<TranslationLanguage> Translations { get; set; }
        public virtual DbSet<Artwork> Artworks { get; set; }
        public virtual DbSet<LandArt> LandArts { get; set; }
        public virtual DbSet<AudioVideo> AudioVideos { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Front Page
            modelBuilder.Entity<FrontPage>().ToTable("FrontPage");
            modelBuilder.Entity<FrontPage>().Property(x => x.ImgURL).IsRequired();

            //Global Goal            
            modelBuilder.Entity<GlobalGoal>().Property(x => x.Longitude).IsRequired();
            modelBuilder.Entity<GlobalGoal>().Property(x => x.Latitude).IsRequired();
            modelBuilder.Entity<GlobalGoal>().Property(x => x.ImgURL).IsRequired();
            modelBuilder.Entity<GlobalGoal>().Property(x => x.CloudinaryFolderPath);
            
            //Global Goal Image
            modelBuilder.Entity<Artwork>().HasRequired(x => x.Translation).WithMany();
            modelBuilder.Entity<Artwork>().Property(x => x.ImgUrl).IsRequired();
            modelBuilder.Entity<LandArt>().HasRequired(x => x.Translation).WithMany();
            modelBuilder.Entity<LandArt>().Property(x => x.ImgUrl).IsRequired();

            //Childrens Texts
            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.ChildrensTexts)
                .WithRequired(x => x.GlobalGoal)
                .HasForeignKey(x => x.GlobalGoalId);

            //Land Art
            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.LandArts)
                .WithRequired(x => x.GlobalGoal)
                .HasForeignKey(x => x.GlobalGoalId);

            //Artwork
            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.Artworks)
                .WithRequired(x => x.GlobalGoal)
                .HasForeignKey(x => x.GlobalGoalId);

            //Audio Video
            modelBuilder.Entity<GlobalGoal>().HasOptional(x => x.AudioVideo)
                .WithRequired(x => x.GlobalGoal);

            //Childrens Text
            modelBuilder.Entity<ChildrensText>().HasRequired(x => x.Translation).WithMany();      

            //AudioVideo
            modelBuilder.Entity<AudioVideo>().HasRequired(x => x.Translation).WithMany();
            modelBuilder.Entity<TranslationLanguage>().HasRequired(x => x.Translation).WithMany();        
            modelBuilder.Entity<Language>().HasKey(l => l.ISO);
            modelBuilder.Entity<Language>().HasMany(l => l.Translations).WithRequired(tl => tl.Language);
            modelBuilder.Entity<TranslationLanguage>().HasKey(tl => new { tl.LanguageISO, tl.TranslationId });

            //Translations
            modelBuilder.Entity<Translation>().HasMany(t => t.TranslatedTexts).WithRequired(tl => tl.Translation);

            base.OnModelCreating(modelBuilder);
        }
    }
}
