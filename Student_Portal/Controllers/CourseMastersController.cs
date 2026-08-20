
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Portal.Models;
using Student_Portal.AppDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;

public class CourseMastersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CourseMastersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: COURSEMASTERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.courseMasters.ToListAsync());
    }

    // GET: courseMasters/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var coursemaster = await _context.courseMasters
            .FirstOrDefaultAsync(m => m.courseID == id);
        if (coursemaster == null)
        {
            return NotFound();
        }

        return View(coursemaster);
    }

    // GET: courseMasters/Create
    public IActionResult Create()
    {
        ViewBag.DepartmentList = new SelectList(_context.departmentMasters, "DepartmentId", "DepartmentName");
        return View();
    }

    // POST: courseMasters/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("courseID,CourseCode,CourseName,DepartmentID,Status")] CourseMaster coursemaster)
    {
        if (ModelState.IsValid)
        {
            _context.Add(coursemaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.DepartmentList = new SelectList( _context.departmentMasters , "DepartmentId", "DepartmentName");
        return View(coursemaster);
    }

    // GET: courseMasters/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var coursemaster = await _context.courseMasters.FindAsync(id);
        if (coursemaster == null)
        {
            return NotFound();
        }
        return View(coursemaster);
    }

    // POST: courseMasters/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("courseID,CourseCode,CourseName,DepartmentID,Status,DepartmentMaster")] CourseMaster coursemaster)
    {
        if (id != coursemaster.courseID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(coursemaster);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseMasterExists(coursemaster.courseID))
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
        return View(coursemaster);
    }

    // GET: courseMasters/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var coursemaster = await _context.courseMasters
            .FirstOrDefaultAsync(m => m.courseID == id);
        if (coursemaster == null)
        {
            return NotFound();
        }

        return View(coursemaster);
    }

    // POST: courseMasters/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var coursemaster = await _context.courseMasters.FindAsync(id);
        if (coursemaster != null)
        {
            _context.courseMasters.Remove(coursemaster);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseMasterExists(int? id)
    {
        return _context.courseMasters.Any(e => e.courseID == id);
    }
}
