using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    internal class CharGenerator
    {
        internal static DAL.Models.Character Generate(BLL.Models.Character c)
        {
            DAL.Models.Character newChar = new DAL.Models.Character();
            newChar.Nom = c.Nom;
            newChar.Race = c.Race;

            newChar.Force = (c.Race == "Humain") ? c.Force + 1 : c.Force;
            newChar.Endurance = (c.Race == "Humain") ? c.Endurance + 1 : c.Endurance + 2;

            newChar.PV = newChar.Endurance + CalculBonus(newChar.Endurance);
            return newChar;
        }

        internal static int CalculBonus(int c)
        {
            if (c < 5) return -1;
            if (c < 10) return 0;
            if (c < 15) return 1;
            return 2;
        }
    }
}
//si la caractéristique est inférieure à 5 on ajoute -1, sinon si elle est inférieure à 10 alors on ajoute 0,
//sinon si elle est inférieure à 15 alors on ajoute +1, sinon on ajoute +2.