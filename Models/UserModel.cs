using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    public string? Direccion { get; set; } // Esto acepta nulos

    [Required]
    public required string Phone { get; set; }

    [Required]
    public required string Password { get; set; }
}
