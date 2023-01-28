using Core.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Contexts;

public class IntroductionRepository : Reposiyory<Introduction>, IIntroductionRepository
{
	public IntroductionRepository(AppDbContext context) : base(context)
	{
	}
}
