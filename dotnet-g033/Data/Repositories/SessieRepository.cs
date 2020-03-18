using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly DbSet<Sessie> _sessies;
        private readonly ApplicationDbContext _context;
        public SessieRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._sessies = context.Sessie;
            
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.Include(s => s.Verantwoordelijke).ToList().OrderBy(s => s.StartDatum).ThenBy(s => s.Naam);
        }

        public IEnumerable<Sessie> GetByMaand(int maand)
        {
            return _sessies.Where(s => s.StartDatum.Month == maand && s.EindDatum>DateTime.Today && s.Gesloten == false)
                .Include(s => s.Verantwoordelijke).Include(s=>s.GebruikersIngeschreven)
                .OrderBy(s => s.StartDatum).ThenBy(s=>s.Naam).ToList();
        }
        public IEnumerable<Sessie> GetAfgelopenByMaand(int maand)
        {
            return _sessies.Where(s => s.StartDatum.Month == maand && s.EindDatum < DateTime.Today && s.Gesloten == true)
                .Include(s => s.Verantwoordelijke).Include(s => s.GebruikersIngeschreven)
                .OrderBy(s => s.StartDatum).ThenBy(s => s.Naam).ToList();
        }
        public IEnumerable<Sessie> GetByMaandVerantwoordelijke(int maand)
        {
            return _sessies.Where(s => s.StartDatum.Month == maand &&  s.StaatOpen == false)
                .Include(s => s.Verantwoordelijke).Include(s => s.GebruikersIngeschreven)
                .OrderBy(s => s.StartDatum).ThenBy(s => s.Naam).ToList();
        }

        public Sessie GetById(int id)
        {
            return _sessies.Where(s => s.SessieId == id).Include(s => s.Media).Include(s => s.Feedback).Include(s => s.Verantwoordelijke)
                .Include(s => s.GebruikersIngeschreven).Include(s => s.Aankondingen).FirstOrDefault();
        }

        public IEnumerable<Sessie> GetSessieVerantwoordelijkeNogTeOpenen(Gebruiker g, int maandId)
        {
            return _sessies.Where(s => s.StartDatum.Month == maandId && s.Verantwoordelijke.UserName.Equals(g.UserName))
                .Include(s => s.Verantwoordelijke).Include(s => s.GebruikersIngeschreven)
                .OrderBy(s => s.Gesloten).ThenBy(s => s.StartDatum).ToList();
        }

        public IEnumerable<Sessie> GetSessieHoofdVerantwoordelijkeNogTeOpenen(Gebruiker g, int maandId)
        {
            return _sessies.Where(s => s.StartDatum.Month == maandId)
                .Include(s => s.Verantwoordelijke).Include(s => s.GebruikersIngeschreven)
                .OrderBy(s => s.Gesloten).ThenBy(s=>s.StartDatum).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
