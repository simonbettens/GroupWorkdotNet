using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        Feedback GetByID(int idNumber);
        void VerwijderFeedback(Feedback feedback);
        void SaveChanges();
    }
}
