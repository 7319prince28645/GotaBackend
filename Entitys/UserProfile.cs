using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGotadevida.Entitys
{
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? Birth { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        [MaxLength(50)]
        public string? Department { get; set; }

        [MaxLength(50)]
        public string? District { get; set; }

        [MaxLength(10)]
        public string? BloodType { get; set; }

        public bool Tatto { get; set; }

        [Range(0, int.MaxValue)]
        public int MonthsTatto { get; set; }

        public bool Piercing { get; set; }

        [Range(0, int.MaxValue)]
        public int MonthsPiercing { get; set; }

        [MaxLength(100)]
        public string? Disease { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
