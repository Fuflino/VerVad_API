using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Facade
{
    public class Facade
    {
        private IFrontPageRepository<FrontPage, int> frontPageRepository;
        private IGGAndAVRepository<GlobalGoal, int> globalGoalRepository;
        private ILanguageRepository<Language, string> languagelRepository;
        private IRepository<Artwork, int> artworkRepository;
        private IRepository<ChildrensText, int> childrensTextRepository;
        private IRepository<LandArt, int> landArtRepository;
        private IGGAndAVRepository<AudioVideo, int> audioVideoRepository;

        public IFrontPageRepository<FrontPage, int> GetFrontPageRepository()
        {
            return frontPageRepository ?? (frontPageRepository = new FrontPageRepository(new GlobalGoalContext()));
        }

        public IGGAndAVRepository<GlobalGoal, int> GetGlobalGoalRepository()
        {
            return globalGoalRepository ?? (globalGoalRepository = new GlobalGoalRepository(new GlobalGoalContext()));
        }

        public ILanguageRepository<Language, string> GetLanguageRepository()
        {
            return languagelRepository ?? (languagelRepository = new LanguageRepository(new GlobalGoalContext()));
        }

        public IRepository<Artwork, int> GetArtworkRepository()
        {
            return artworkRepository ?? (artworkRepository = new ArtworkRepository(new GlobalGoalContext()));
        }

        public IRepository<ChildrensText, int> GetChildrensTextRepository()
        {
            return childrensTextRepository ?? (childrensTextRepository = new ChildrensTextRepository(new GlobalGoalContext()));
        }

        public IRepository<LandArt, int> GetLandArtRepository()
        {
            return landArtRepository ?? (landArtRepository = new LandArtRepository(new GlobalGoalContext()));
        }

        public IGGAndAVRepository<AudioVideo, int> GetAudioVideoRepository()
        {
            return audioVideoRepository ?? (audioVideoRepository = new AudioVideoRepository(new GlobalGoalContext()));
        }
    }
}
