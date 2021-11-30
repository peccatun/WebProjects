using System;
using System.ComponentModel.DataAnnotations;

namespace MotMaintOnline4.InputModels.Motorcycles
{
    public class MotorcycleInputModel
    {
        [Required]
        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Display(Name = "Година")]
        public DateTime ProductionDate { get; set; }

        [Display(Name = "Начални километри")]
        public int StartKilometers { get; set; }

        public int ApplicationUserId { get; set; }
    }
}
