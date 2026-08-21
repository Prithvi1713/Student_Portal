
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Portal.Models;
using Student_Portal.AppDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;

public class StudentMastersController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentMastersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: STUDENTMASTERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.studentMasters.ToListAsync());
    }

    // GET: STUDENTMASTERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmaster = await _context.studentMasters
            .FirstOrDefaultAsync(m => m.StudentID == id);
        if (studentmaster == null)
        {
            return NotFound();
        }

        return View(studentmaster);
    }

    // GET: STUDENTMASTERS/Create
    public IActionResult Create()
    {
        ViewBag.DepartmentList = new SelectList(_context.departmentMasters, "DepartmentId", "DepartmentName");
        ViewBag.CourseList = new SelectList(_context.courseMasters, "courseID", "CourseName");
        return View();
    }

    // POST: STUDENTMASTERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StudentID,FirstName,MiddleName,LastName,MobileNo,EmailAddress,BirthDate,DepartmentID,CourseID,Status,Gender,Address")] StudentMaster studentmaster)
    {

        if (ModelState.IsValid)
        {
            _context.Add(studentmaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.DepartmentList = new SelectList(_context.departmentMasters, "DepartmentId", "DepartmentName");
        ViewBag.CourseList = new SelectList(_context.courseMasters, "courseID", "CourseName");
        return View(studentmaster);
    }

    // GET: STUDENTMASTERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        
        ViewBag.DepartmentList = new SelectList ( _context.departmentMasters, "DepartmentId", "DepartmentName");
        ViewBag.CourseList = new SelectList(_context.courseMasters, "courseID", "CourseName");
        if (id == null)
        {
            return NotFound();
        }

        var studentmaster = await _context.studentMasters.FindAsync(id);
        if (studentmaster == null)
        {
            return NotFound();
        }
        return View(studentmaster);
    }

    // POST: STUDENTMASTERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("StudentID,FirstName,MiddleName,LastName,MobileNo,EmailAddress,BirthDate,DepartmentID,CourseID,Status,Gender,Address")] StudentMaster studentmaster)
    {
        if (id != studentmaster.StudentID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(studentmaster);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMasterExists(studentmaster.StudentID))
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
        return View(studentmaster);
    }

    // GET: STUDENTMASTERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id  == null)
        {
            return NotFound();
        }

        var studentmaster = await _context.studentMasters
            .FirstOrDefaultAsync(m => m.StudentID == id);
        if (studentmaster == null)
        {
            return NotFound();
        }

        return View(studentmaster);
    }

    // POST: STUDENTMASTERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var studentmaster = await _context.studentMasters.FindAsync(id);
        if (studentmaster != null)
        {
            _context.studentMasters.Remove(studentmaster);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentMasterExists(int? id)
    {
        return _context.studentMasters.Any(e => e.StudentID == id);
    }
}
