using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Auth;

public class ForgotPasswordViewModel
{

	[Required, MaxLength(256), DataType(DataType.EmailAddress)]
	public string? YourEmail { get; set; }

	[Required, MaxLength(256), DataType(DataType.Password)]
	public string? NewPassword { get; set; }

	[Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
	public string? ConfirmPassword { get; set; }
}
