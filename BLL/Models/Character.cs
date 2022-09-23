using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Race { get; set; }
        public int Force { get; set; }
        public int Endurance { get; set; }
        public int PV { get; set; }
    }
}
