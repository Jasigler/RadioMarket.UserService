using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class User
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string email { get; set; }

        [Required]
        [MaxLength(20)]
        public string first_name { get; set; }

        [Required]
        [MaxLength(20)]
        public string last_name { get; set; }

        [Required]
        [MaxLength(250)]
        public string password_hash { get; set; }
    }
}
