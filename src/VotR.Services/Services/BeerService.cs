using System.Collections.Generic;
using VotR.Services.Interfaces;
using VotR.Db.VotRDbContext;
using System.Linq;
using VotR.Db.Entities;
using System;

namespace VotR.Services.Services
{
    public class BeerService : IBeerService, IBaseService
    {
        private VotRDbContext _context;

        public BeerService(VotRDbContext context)
        {
            _context = context;
        }

        public Beer Get(int id)
        {
            return _context.Beer.First(b => b.Id == id);
        }

        public List<Beer> GetAll()
        {
            return _context.Beer.ToList();
        }

        public void Remove(int id)
        {
            var b = Get(id);
            _context.Beer.Remove(b);

            _context.SaveChanges();
        }

        public int Save(Beer b)
        {
            _context.Beer.Add(b);
            _context.SaveChanges();

            return 1;
        }
    }
}
