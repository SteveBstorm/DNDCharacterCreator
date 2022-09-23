using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = DAL.Models;
using bll = BLL.Models;

namespace BLL.Tools
{
    public static class Mappers
    {
        public static bll.Character ToBll(this dal.Character c) 
        {
            return new bll.Character
            {
                Id = c.Id,
                Nom = c.Nom,
                Race = c.Race,
                Force = c.Force,
                Endurance = c.Endurance,
                PV = c.PV
            };
        }

        public static dal.Character ToDAL(this bll.Character c)
        {
            return new dal.Character
            {
                Id = c.Id,
                Nom = c.Nom,
                Race = c.Race,
                Force = c.Force,
                Endurance = c.Endurance,
                PV = c.PV
            };
        }
    }
}
