using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Contexts
{
    public class GlobalGoalContext : DbContext
    {
        public GlobalGoalContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DbInit());
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

        //All properties are required in order to create a Global Goal       
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

            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.ChildrensTexts).WithRequired();
            
            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.LandArts).WithRequired();
            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.Artworks).WithRequired();
            modelBuilder.Entity<GlobalGoal>().HasOptional(x => x.AudioVideo).WithRequired();

            //Childrens Text
            modelBuilder.Entity<ChildrensText>().HasRequired(x => x.Translation).WithMany().WillCascadeOnDelete(false);

            //Global Goal Image            
            modelBuilder.Entity<Artwork>().Property(x => x.ImgUrl).IsRequired();
            modelBuilder.Entity<LandArt>().Property(x => x.ImgUrl).IsRequired();

            modelBuilder.Entity<Language>().HasKey(l => l.ISO);
            modelBuilder.Entity<Translation>().HasMany(t => t.TranslatedTexts).WithRequired(tl => tl.Translation);
            modelBuilder.Entity<Language>().HasMany(l => l.Translations).WithRequired(tl => tl.Language);
            modelBuilder.Entity<TranslationLanguage>().HasKey(tl => new { tl.LanguageISO, tl.TranslationId });

            base.OnModelCreating(modelBuilder);
        }        
    }
}
