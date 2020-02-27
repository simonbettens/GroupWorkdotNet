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
        private readonly Gebruiker _gebruiker;

        public SessieRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._sessies = context.Sessie;
            
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();
        }

        public IEnumerable<Sessie> GetByMaand(int maand)
        {
            return _sessies.Where(s => s.StartDatum.Month == maand).Include(s => s.Verantwoordelijke).OrderBy(s => s.StartDatum).ToList();
        }

        public Sessie GetById(int id)
        {
            return _sessies.Where(s => s.SessieId == id).Include(s => s.Media).Include(s => s.Verantwoordelijke).FirstOrDefault();
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Sessie> GetAllGeslotenSessies()
        {
           return  _sessies.Where(s => s.StaatOpen == true && s.OoitGeopend == false).ToList(); 
        }

        public IEnumerable<Sessie> GetGeslotenSessiesGebruiker()
        {
            return _sessies.Where(s => s.StaatOpen == true && s.OoitGeopend == false && s.Verantwoordelijke.Equals(_gebruiker.UserName)).ToList();
        }
    }
}
