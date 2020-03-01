using System.ComponentModel.DataAnnotations;

namespace SoccerPlayers.Enums
{
    public enum Sex
    {
        [Display(Name = "Мужчина")]
        Male,
        [Display(Name = "Женщина")]
        Female
    }
}
