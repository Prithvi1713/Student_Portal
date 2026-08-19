
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Portal.Models;
using Student_Portal.AppDbContext;

public class DepartmentMastersController : Controller
{
    private readonly ApplicationDbContext _context;

    public DepartmentMastersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DEPARTMENTMASTERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.departmentMasters.ToListAsync());
    }

    // GET: DEPARTMENTMASTERS/Details/5
    public async Task<IActionResult> Details(int? departmentid)
    {
        if (departmentid == null)
        {
            return NotFound();
        }

        var departmentmaster = await _context.departmentMasters
            .FirstOrDefaultAsync(m => m.DepartmentId == departmentid);
        if (departmentmaster == null)
        {
            return NotFound();
        }

        return View(departmentmaster);
    }

    // GET: DEPARTMENTMASTERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DEPARTMENTMASTERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName,DepartmentDescription,isActive")] DepartmentMaster departmentmaster)
    {
        if (ModelState.IsValid)
        {
            _context.Add(departmentmaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(departmentmaster);
    }

    // GET: DEPARTMENTMASTERS/Edit/5
    public async Task<IActionResult> Edit(int? departmentid)
    {
        if (departmentid == null)
        {
            return NotFound();
        }

        var departmentmaster = await _context.departmentMasters.FindAsync(departmentid);
        if (departmentmaster == null)
        {
            return NotFound();
        }
        return View(departmentmaster);
    }

    // POST: DEPARTMENTMASTERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? departmentid, [Bind("DepartmentId,DepartmentName,DepartmentDescription,isActive")] DepartmentMaster departmentmaster)
    {
        if (departmentid != departmentmaster.DepartmentId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(departmentmaster);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentMasterExists(departmentmaster.DepartmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(departmentmaster);
    }

    // GET: DEPARTMENTMASTERS/Delete/5
    public async Task<IActionResult> Delete(int? departmentid)
    {
        if (departmentid == null)
        {
            return NotFound();
        }

        var departmentmaster = await _context.departmentMasters
            .FirstOrDefaultAsync(m => m.DepartmentId == departmentid);
        if (departmentmaster == null)
        {
            return NotFound();
        }

        return View(departmentmaster);
    }

    // POST: DEPARTMENTMASTERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? departmentid)
    {
        var departmentmaster = await _context.departmentMasters.FindAsync(departmentid);
        if (departmentmaster != null)
        {
            _context.departmentMasters.Remove(departmentmaster);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DepartmentMasterExists(int? departmentid)
    {
        return _context.departmentMasters.Any(e => e.DepartmentId == departmentid);
    }
}
