using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICharacterRepo
    {
        int Create(Character c);
        Character GetById(int id);
        IEnumerable<Character> GetAll();
    }
}
