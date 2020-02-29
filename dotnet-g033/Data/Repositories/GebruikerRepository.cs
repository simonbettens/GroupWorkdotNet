﻿using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly DbSet<Gebruiker> _gebruikers;
        private readonly ApplicationDbContext _context;

        public GebruikerRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._gebruikers = context.Gebruiker;
        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikers.ToList();
        }

        public IEnumerable<Gebruiker> GetByID(int idNumber)
        {
            return _gebruikers.Where(g => g.IdNumber == idNumber).OrderBy(g => g.Achternaam).ToList();
        }

        public Gebruiker GetById(int idNumber)
        {
            return _gebruikers.Where(g => g.IdNumber == idNumber).FirstOrDefault();
        }

        public Gebruiker GetByUsername(string username)
        {
            return _gebruikers.Where(g => g.UserName == username).FirstOrDefault();
        }

        public Gebruiker GetByEmail(string email)
        {
            return _gebruikers.Where(g => g.Email == email).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}
