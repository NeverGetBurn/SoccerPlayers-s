using System;
using System.ComponentModel.DataAnnotations;
using SoccerPlayers.Enums;

namespace SoccerPlayers.Models
{
    public class Player
    {
        public int Id { get; set; }
        [RegularExpression("@[А-Я][а-я]*")]
        [Required (ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [RegularExpression("@[А-Я][а-я]*")]
        [Required(ErrorMessage = "Не указана фамилия")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        public Sex Sex { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage ="Не указана дата")]
        public DateTime BirthDate { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public Countries Country { get; set; }

    }
}
