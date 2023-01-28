using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class AppUser : IdentityUser
{
	[Required,MaxLength(100)]
	public string? Fullname { get; set; }
	public bool? IsActive { get; set; }
}
