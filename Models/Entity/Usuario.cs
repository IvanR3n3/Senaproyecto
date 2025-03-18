using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pet_World.Models.Entity
{
    [Table("users")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(180)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255)]
        public string? Direccion { get; set; }  // Es opcional (NULL en BD)

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }


}
