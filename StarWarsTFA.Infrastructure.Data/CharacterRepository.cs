using StarWarsTFA.Domain;
using StarWarsTFA.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTFA.Infrastructure.Data
{
    public class CharacterRepository : IRepository<Character>
    {

        SWDatabase db = new SWDatabase();

        public List<Character> GetAll()
        {
            return db.Characters.ToList();
        }
        public void Create(Character entity)
        {
            db.Characters.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var character = db.Characters.Find(id);
            db.Characters.Remove(character);
            db.SaveChanges();
           
        }

    }
}
