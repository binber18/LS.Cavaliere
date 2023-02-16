using LS.Cavaliere.AspNetCore.ViewModels.Admin;
using LS.Cavaliere.AspNetCore.ViewModels.Dogs;
using LS.Cavaliere.Models.Requests.Dogs;
using LS.Cavaliere.Models.Requests.Files;
using LS.Cavaliere.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LS.Cavaliere.AspNetCore.Controllers;

[Route("Hunde"), Authorize(Roles = "Admin")]
public class DogsController : Controller
{
    private readonly IDogService _dogService;
    private readonly ILogger<DogsController> _logger;
    public DogsController(IDogService dogService, ILogger<DogsController> logger)
    {
        _dogService = dogService;
        _logger = logger;

    }

    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
        var dogs = (await _dogService.GetAllDogsAsync()).ToList();
        var dogList = new List<DogViewModel>();
        foreach (var dog in dogs)
        {
            var fileName = await _dogService.GetTitleImageForDogAsync(dog.Id);
            dogList.Add(new(dog, fileName));
        }
        return View(dogList);
    }

    [HttpGet("{id:guid}"), AllowAnonymous]
    public async Task<ActionResult> Details(Guid id)
    {
        _logger.LogTrace("Getting dog with id {Id}", id);
        var dog = await _dogService.GetByIdAsync(id);
        if (dog is null)
            return NotFound();
        var images = await _dogService.GetImagesForDogAsync(id);
        return View(new DogDetailViewModel(dog, images));
    }

    [HttpGet("Neu")]
    public IActionResult Create()
    {
        return View(new CreateDogViewModel());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateDogViewModel createDogVm)
    {
        if (!ModelState.IsValid)
            return View(createDogVm);

        var createDogRequest = new CreateDogRequest(createDogVm.Name,
                                                    createDogVm.Birthday,
                                                    createDogVm.Mother,
                                                    createDogVm.Father,
                                                    createDogVm.Description,
                                                    new FileRequest(FileRequest.GetSafeFileName(createDogVm.Image.FileName),
                                                                    createDogVm.Image.OpenReadStream(),
                                                                    createDogVm.Image.ContentType));

        _logger.LogTrace("Creating dog with name {Name}", createDogRequest.Name);
        var dogId = await _dogService.CreateDogAsync(createDogRequest);
        if (dogId == Guid.Empty)
            return View(createDogVm);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Edit/{id:guid}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var dog = await _dogService.GetByIdAsync(id);
        if (dog is null)
            return NotFound();
        var images = await _dogService.GetImagesForDogAsync(dog.Id);
        var titleImage = await _dogService.GetTitleImageForDogAsync(dog.Id);
        return View(UpdateDogRequest.FromDog(dog, titleImage, images));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, UpdateDogRequest updateDogRequest)
    {
        _logger.LogTrace("Updating dog with id {Id}", id);
        await _dogService.UpdateDogAsync(id, updateDogRequest);
        return RedirectToAction(nameof(Edit), new { id });
    }

    [HttpPost("{dogId:guid}/Bild")]
    public async Task<IActionResult> AddImageToDog(Guid dogId, IFormCollection form)
    {
        var image = form.Files.FirstOrDefault();
        if (image is null)
            return RedirectToAction(nameof(Edit), new { id = dogId });

        _logger.LogTrace("Adding image to dog with id {DogId}", dogId);

        await _dogService.AddImageToDogAsync(dogId, FileRequest.FromFormFile(image));

        return RedirectToAction(nameof(Edit), new { id = dogId });
    }

    [HttpPost("{dogId:guid}/Bild/Löschen/{fileName}")]
    public async Task<IActionResult> DeleteImageFromDog(Guid dogId, string fileName)
    {
        await _dogService.RemoveImageFromDogAsync(dogId, fileName).ConfigureAwait(false);

        return RedirectToAction(nameof(Edit), new { id = dogId });
    }
    
    [HttpPost("{dogId:guid}/Bild/AlsTitelbildSetzen/{fileName}")]
    public async Task<IActionResult> SetTitleImageForDog(Guid dogId, string fileName)
    {
        await _dogService.SetTitleImageForDogAsync(dogId, fileName).ConfigureAwait(false);
        return RedirectToAction(nameof(Edit), new { id = dogId });
    }
}