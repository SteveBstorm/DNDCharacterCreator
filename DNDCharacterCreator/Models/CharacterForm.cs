using System.ComponentModel.DataAnnotations;

namespace DNDCharacterCreator.Models
{
    public class CharacterForm
    {
        [Required]
        public string Nom { get; set; }
        [Range(3,18)]
        public int Force { get; set; }
        [Range(3,18)]
        public int Endurance { get; set; }
        [Required]
        public string Race { get; set; }
    }
}
