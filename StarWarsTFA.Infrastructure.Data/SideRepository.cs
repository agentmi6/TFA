using StarWarsTFA.Domain;
using StarWarsTFA.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTFA.Infrastructure.Data
{
    public class SideRepository : IRepository<Side>
    {
        SWDatabase db = new SWDatabase();
        public List<Side> GetAll()
        {
            return db.Sides.ToList();
        }
        public void Create(Side entity)
        {
            db.Sides.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var side = db.Sides.Find(id);
            db.Sides.Remove(side);
            db.SaveChanges();
        }

    }
}
