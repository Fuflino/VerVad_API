using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        //All properties are required in order to create a Global Goal       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Front Page
            modelBuilder.Entity<FrontPage>().ToTable("FrontPage");
            modelBuilder.Entity<FrontPage>().Property(x => x.ImgURL).IsRequired();
            modelBuilder.Entity<FrontPage>().HasRequired(x => x.Title).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<FrontPage>().HasRequired(x => x.Description).WithMany().WillCascadeOnDelete(false);

            //Global Goal            
            modelBuilder.Entity<GlobalGoal>().Property(x => x.Longitude).IsRequired();
            modelBuilder.Entity<GlobalGoal>().Property(x => x.Latitude).IsRequired();
            modelBuilder.Entity<GlobalGoal>().Property(x => x.ImgURL).IsRequired();
            modelBuilder.Entity<GlobalGoal>().Property(x => x.VideoURL).IsRequired();
            modelBuilder.Entity<GlobalGoal>().Property(x => x.AudioURL).IsRequired();

            modelBuilder.Entity<GlobalGoal>().HasRequired(x => x.Title).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<GlobalGoal>().HasRequired(x => x.Description).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.Sculptures).WithRequired();
            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.LandArts).WithRequired();
            modelBuilder.Entity<GlobalGoal>().HasMany(x => x.Artworks).WithRequired();

            //Global Goal Image
            modelBuilder.Entity<Sculpture>().Property(x => x.ImageUrl).IsRequired();
            modelBuilder.Entity<Artwork>().Property(x => x.ImageUrl).IsRequired();
            modelBuilder.Entity<LandArt>().Property(x => x.ImageUrl).IsRequired();

            //Text Translation
            modelBuilder.Entity<Translation>().HasMany(x => x.Texts).WithRequired();

            //Text
            modelBuilder.Entity<Text>().Property(x => x.TranslatedText).IsRequired();

            //Language
            modelBuilder.Entity<Language>().Property(x => x.Lang).IsRequired();
            modelBuilder.Entity<Language>().Property(x => x.Name).IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
