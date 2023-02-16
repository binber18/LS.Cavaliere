using LS.Cavaliere.AspNetCore.ViewModels.Litters;
using LS.Cavaliere.Models.Requests.Files;
using LS.Cavaliere.Models.Requests.Litters;
using LS.Cavaliere.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LS.Cavaliere.AspNetCore.Controllers;

[Route("Würfe"), Authorize(Roles = "Admin")]
public class LittersController : Controller
{
    private readonly ILitterService _litterService;
    private readonly ILogger<LittersController> _logger;
    public LittersController(ILitterService litterService, ILogger<LittersController> logger)
    {
        _litterService = litterService;
        _logger = logger;
    }

    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
        var litters = await _litterService.GetAllLittersAsync();
        return View(litters);
    }

    [HttpGet("Details"), AllowAnonymous]
    public async Task<ActionResult> Details(Guid id)
    {
        var litter = await _litterService.GetByIdAsync(id);
        if (litter is null)
            return NotFound();
        return View(litter);
    }

    [HttpGet("Create")]
    public async Task<ActionResult> Create()
    {
        var letter = await _litterService.GetNextLitterLetterAsync();
        var validLetters = await _litterService.GetValidLitterLettersAsync();

        var viewModel = new CreateLitterViewModel
        {
            Letter = letter,
            ValidLetters = validLetters,
        };

        return View(viewModel);
    }

    [HttpPost("Create"), ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateLitterViewModel vm)
    {
        var request = new CreateLitterRequest(vm.Letter, vm.Father, vm.Mother, FileRequest.FromFormFile(vm.ParentImage!));
        await _litterService.CreateAsync(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Edit")]
    public async Task<ActionResult> Edit(Guid id)
    {
        var litter = await _litterService.GetByIdAsync(id);
        if (litter is null)
            return NotFound();
        var vm = EditLitterViewModel.FromLitter(litter);
        return View(vm);
    }

    [HttpPost("Edit"), ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, EditLitterViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var updateRequest = vm.ToUpdateLitterRequest();

        await _litterService.UpdateAsync(id, updateRequest);

        return View(vm);
    }

    [HttpPost("{id:guid}/Welpen")]
    public async Task<IActionResult> AddPuppyToLitter(Guid id, AddPuppyToLitterViewModel model)
    {
        _logger.LogInformation("Add Puppy to Litter {Id}", id);

        if (model.Image is null)
            return RedirectToAction(nameof(Details), new { id });

        var fileRequest = FileRequest.FromFormFile(model.Image);
        var request = new AddPuppyToLitterRequest(model.Name, fileRequest);

        await _litterService.AddPuppyToLitterAsync(id, request);

        return RedirectToAction(nameof(Details), new { id });
    }
}