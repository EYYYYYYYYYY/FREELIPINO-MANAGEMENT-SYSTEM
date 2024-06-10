// Controllers/FreelancersController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

public class FreelancersController : Controller
{
    private readonly ApplicationDbContext _context;

    public FreelancersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Freelancers.ToList());
    }

    public IActionResult Details(int id)
    {
        var freelancer = _context.Freelancers
            .Include(f => f.Projects)
            .ThenInclude(p => p.Activities)
            .FirstOrDefault(f => f.FreelancerId == id);
        if (freelancer == null)
        {
            return NotFound();
        }
        return View(freelancer);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Freelancer freelancer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(freelancer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(freelancer);
    }

    public IActionResult Edit(int id)
    {
        var freelancer = _context.Freelancers.Find(id);
        if (freelancer == null)
        {
            return NotFound();
        }
        return View(freelancer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Freelancer freelancer)
    {
        if (ModelState.IsValid)
        {
            _context.Update(freelancer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(freelancer);
    }

    public IActionResult Delete(int id)
    {
        var freelancer = _context.Freelancers.Find(id);
        if (freelancer == null)
        {
            return NotFound();
        }
        return View(freelancer);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var freelancer = _context.Freelancers.Find(id);
        _context.Freelancers.Remove(freelancer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

// Similar controllers should be created for Projects and Activities.
