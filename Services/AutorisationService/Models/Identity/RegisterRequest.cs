using System.ComponentModel.DataAnnotations;

namespace AutorisationService.Models.Identity;

public class RegisterRequest
{
    [Required] 
    [Display(Name = "Email")] 
    public string Email { get; set; } = null!;
 
    [Required]
    [Display(Name = "Дата рождения")]
    public DateTime BirthDate { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердить пароль")]
    public string PasswordConfirm { get; set; } = null!;

    [Required]
    [Display(Name = "Имя Пользователя")]
    public string UserName { get; set; } = null!;
    

}