using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Auth;

public class LoginViewModel
{
	[Required(ErrorMessage ="Boş buraxma")]
	public string? UsernameOrEmail { get; set;}


	[Required, DataType(DataType.Password)]
	public string? Password { get; set; }

	public bool RememberMe { get; set; }

}
