using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data
{
    public class InitData
    {
        private readonly ApplicationDbContext _dbContext;

        public InitData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public void InitializeData()
        {
            
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Sessie sessie1 = new Sessie("sessie1", new DateTime(2020, 2, 20, 14, 0, 0), new DateTime(2020, 2, 20, 15, 0, 0), false, 20, 0, "GSCHB4.026");
                Sessie sessie2 = new Sessie("sessie2", new DateTime(2020, 2, 21, 10, 30, 0), new DateTime(2020, 2, 21, 12, 30, 0), false, 10, 0, "GSCHB4.026");
                Sessie sessie3 = new Sessie("sessie3", new DateTime(2020, 2, 22, 16, 0, 0), new DateTime(2020, 2, 22, 17, 0, 0), true, 30, 0, "GSCHB4.026");
                Sessie sessie4 = new Sessie("sessie4", new DateTime(2020, 2, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026");
                Sessie sessie5 = new Sessie("sessie5", new DateTime(2020, 3, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026");

                Sessie[] sessies = { sessie1, sessie2, sessie3, sessie4, sessie5 };
                _dbContext.Sessie.AddRange(sessies);
                _dbContext.SaveChanges();
            }
            
        }
    }
}
