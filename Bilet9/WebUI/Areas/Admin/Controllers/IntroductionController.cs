using Core.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.Introduction;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class IntroductionController : Controller
{
	private readonly IIntroductionRepository _repository;
	private readonly IWebHostEnvironment _env;


	public IntroductionController(IIntroductionRepository repository, IWebHostEnvironment env)
	{
		_repository = repository;
		_env = env;
	}

	public async Task<IActionResult> Index()
	{
		var model = await _repository.GetAllAsync();
		return View(model);
	}

	#region Create
	public IActionResult Created()
	{
		return View();
	}
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Created(CretedViewModel model)
	{
		if (model.Icon == null)
		{
			ModelState.AddModelError("Icon", "Bir İcon Seçin");
			return View(model);
		}
		if (!ModelState.IsValid)
		{
			return View(model);
		}
		Introduction ıntroduction = new()
		{
			Title = model.Title,
			Description = model.Description,
			Icon = model.Icon
		};
		await _repository.CretedAsync(ıntroduction);
		await _repository.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion

	#region Update
	public async Task<IActionResult> Update(int id)
	{
		var model = await _repository.GetAsync(id);
		if (model == null)
		{
			return NotFound();
		}
		UpdateViewModel updateVM = new()
		{
			Title = model.Title,
			Description = model.Description,
			Icon = model.Icon
		};
		model.Title = model.Title;
		return View(updateVM);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]

	public async Task<IActionResult> Update(int id, UpdateViewModel model)
	{
		var ıntroduct = await _repository.GetAsync(id);
		if (ıntroduct == null)
		{
			return NotFound();
		}
		if (id != model.Id) { return BadRequest(); }

		if (model.Icon == null)
		{
			ModelState.AddModelError("Icon", "Bir İcon Seçin");
			return View(model);
		}
		if (!ModelState.IsValid)
		{
			return View(model);
		}
		Introduction ıntroduction = new()
		{ Id = id,
			Title = model.Title,
			Description = model.Description,
			Icon = model.Icon
		};
		_repository.Update(ıntroduction);
		await _repository.SaveAsync();
		return RedirectToAction(nameof(Index));
	}
	#endregion

	#region Detail
	public async Task<IActionResult> Detail(int id)
	{
		var model = await _repository.GetAsync(id);
		if (model == null) { return NotFound(); }

		return View(model);
	}
    #endregion

    #region Delete
    public async Task<IActionResult> Delete(int id)
    {
        var model = await _repository.GetAsync(id);
        if (model == null) { return NotFound(); }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeletedPost(int id)
    {
        var model = await _repository.GetAsync(id);
        if (model == null) { return NotFound(); }
        _repository.Delete(model);
        await _repository.SaveAsync();
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
