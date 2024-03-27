using System.ComponentModel.DataAnnotations;

namespace ApiGotadevida.DTOS
{
    public class UserListProfileDTO
    {
        public DateTime Birth { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }

        public string District { get; set; }

        public string BloodType { get; set; }

        public bool Tatto { get; set; }

        public int MonthsTatto { get; set; }

        public bool Piercing { get; set; }

        public int MonthsPiercing { get; set; }

        public string Disease { get; set; }
    }
}
