using BLL.Models;
using DNDCharacterCreator.Models;

namespace DNDCharacterCreator.Mappers
{
    public static class Mappers
    {
        public static Character ToBll(this CharacterForm c)
        {
            return new Character
            {
                Nom = c.Nom,
                Race = c.Race,
                Force = c.Force,
                Endurance = c.Endurance
            };
        }
    }
}
