using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Repositories
{
    public class AankondingRepository : IAankondigingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Aankondiging> _aankondigingen;
        public AankondingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _aankondigingen = dbContext.Aankondiging;
        }
        public IEnumerable<Aankondiging> GetAllAlgemene()
        {
            return _aankondigingen.OfType<Aankondiging>().Where(a => !(a is SessieAankondiging)).Include(a => a.Verantwoordelijke).ToList().OrderBy(a=>a.Prioriteit);
        }

        public IEnumerable<SessieAankondiging> GetAllSessieAankonding(int sessieId)
        {
            return _aankondigingen.OfType<SessieAankondiging>().Include(sa=>sa.Sessie).Include(sa => sa.Verantwoordelijke).Where(sa=>sa.SessieId==sessieId)
                .ToList().OrderBy(a => a.Prioriteit);
        }

        public Aankondiging GetAankondingById(int id)
        {
            return _aankondigingen.OfType<Aankondiging>().Include(a => a.Verantwoordelijke).Where(a=>a.AankondingId==id).FirstOrDefault();
        }

        public Aankondiging GetSessieAankondingById(int id)
        {
            return _aankondigingen.OfType<SessieAankondiging>().Include(sa => sa.Verantwoordelijke).Include(sa=>sa.Sessie).Where(sa => sa.AankondingId == id).FirstOrDefault();
        }
    }
}
