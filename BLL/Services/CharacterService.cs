using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Tools;

namespace BLL.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepo _characterRepo;

        public CharacterService(ICharacterRepo characterRepo)
        {
            _characterRepo = characterRepo;
        }

        public Character Create(Character c)
        {
            int id = _characterRepo.Create(CharGenerator.Generate(c));
            return _characterRepo.GetById(id).ToBll();
        }

        public IEnumerable<Character> GetAll()
        {
            return _characterRepo.GetAll().Select(x => x.ToBll());
        }

        public Character GetById(int id)
        {
            return _characterRepo.GetById(id).ToBll();
        }
    }
}
