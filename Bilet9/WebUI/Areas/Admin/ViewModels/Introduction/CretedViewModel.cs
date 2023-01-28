using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.ViewModels.Introduction;

public class CretedViewModel
{
	public int Id { get; set; }
	[Required(ErrorMessage = "Boş buraxmayın"),MaxLength(200)]
	public string? Title { get; set; }
	[Required(ErrorMessage = "Boş buraxmayın"), MaxLength(700)]
	public string? Description { get; set; }
	public string? Icon { get; set; }
}
