using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Repositories
{
    public class AankondingRepository : IAankondingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Aankonding> _aankondingen;
        public AankondingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _aankondingen = dbContext.Aankonding;
        }
        public IEnumerable<Aankonding> GetAllAlgemene()
        {
            return _aankondingen.OfType<Aankonding>().Where(a => !(a is SessieAankonding)).Include(a => a.Verantwoordelijke).ToList().OrderBy(a=>a.Prioriteit);
        }

        public IEnumerable<SessieAankonding> GetAllSessieAankonding(int sessieId)
        {
            return _aankondingen.OfType<SessieAankonding>().Include(sa=>sa.Sessie).Include(sa => sa.Verantwoordelijke).Where(sa=>sa.SessieId==sessieId)
                .ToList().OrderBy(a => a.Prioriteit);
        }

        public Aankonding GetAankondingById(int id)
        {
            return _aankondingen.OfType<Aankonding>().Include(a => a.Verantwoordelijke).Where(a=>a.AankondingId==id).FirstOrDefault();
        }

        public Aankonding GetSessieAankondingById(int id)
        {
            return _aankondingen.OfType<SessieAankonding>().Include(sa => sa.Verantwoordelijke).Include(sa=>sa.Sessie).Where(sa => sa.AankondingId == id).FirstOrDefault();
        }
    }
}
