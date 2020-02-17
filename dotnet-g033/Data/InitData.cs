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
               
                _dbContext.SaveChanges();
            }
        }
    }
}
