using System.Collections.Generic;
using VotR.Db.Entities;

namespace VotR.Services.Interfaces
{
    public interface IBeerService
    {
        Beer Get(int id);

        List<Beer> GetAll();

        void Remove(int id);

        int Save(Beer b);
    }
}
