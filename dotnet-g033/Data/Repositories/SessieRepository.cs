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
            return _sessies.ToList();
        }

        public IEnumerable<Sessie> GetByMaand(int maand)
        {
            return _sessies.Where(s => s.StartDatum.Month == maand).OrderBy(s => s.StartDatum).ToList();
        }

        public Sessie GetById(int id)
        {
            return _sessies.Where(s => s.SessieId == id).Include(s => s.Media).Include(s => s.Media.Afbeeldingen)
                .Include(s => s.Media.Videos).Include(s => s.Media.Documenten).Include(s => s.Media.Linken).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
