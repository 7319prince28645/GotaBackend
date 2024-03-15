using System.ComponentModel.DataAnnotations;

namespace ApiGotadevida.Entitys
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public DateOnly Birth { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(50)] 
        public string Department { get; set; } = null!;

        [Required]
        [MaxLength(50)] 
        public string District { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string BloodType { get; set; } = null!;

        public bool Tatto { get; set; }

        [Range(0, int.MaxValue)] 
        public int MonthsTatto { get; set; }

        public bool Piercing { get; set; }

        [Range(0, int.MaxValue)] 
        public int MonthsPiercing { get; set; }

        [MaxLength(100)] 
        public string Disease { get; set; } = null!;
    }
}
