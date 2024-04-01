using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGotadevida.Entitys
{
    public class PostUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;

        // Clave foránea para la relación con Users
        public int UserId { get; set; }
        public Users User { get; set; }

    }
}
