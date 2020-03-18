using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DbSet<Feedback> _feedback;
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._feedback = context.Feedback;

        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedback.ToList().OrderBy(f => f.GebruikerUserName);
        }

        public Feedback GetByID(int idNumber)
        {
            return _feedback.Where(f => f.Id == idNumber).FirstOrDefault();
        }

        public void VerwijderFeedback(Feedback feedback)
        {
            _feedback.Remove(feedback);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
