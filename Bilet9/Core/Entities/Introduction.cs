using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Introduction : IEntity
{
	public int Id { get; set; }
	[Required,MaxLength(200)]
	public string? Title { get; set; }
	[Required, MaxLength(700)]
	public string? Description { get; set; }
	[Required]
	public string? Icon { get; set; }//css clssslaridi- şəkil yoxdur,icondur
                                     //fa-bicycle
                                     //fa-city
									 //fa-bus
}
