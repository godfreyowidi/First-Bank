using System;
using System.ComponentModel.DataAnnotations;

namespace FirstBank.Models
{
  public class Person
  {
    public int UserId { get; set; }

    [Required(ErrorMessage = "Required.")]
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Required(ErrorMessage = "Required.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Required.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
    public bool RememberMe { get; set; }
  }
}