using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Controllers
{
    public class ServiceController : Controller
    {
        private readonly SpaContext _context;

        public ServiceController(SpaContext context)
        {
            _context = context;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }
        //GET
        public IActionResult Descriptions()
        {
            ViewBag.Classifications = _context.Services.ToList();
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Descriptions(Services model)
        {
            var viewName = "";
            switch(model.Classification)
            {
                case "Full":
                    viewName = "full";
                    break;
                case "Half":
                    viewName = "half";
                    break;
                case "Two":
                    viewName = "two";
                    break;
                case "One":
                    viewName = "one";
                    break;
                default:
                    viewName = "other";
                    break;
            }
            return View(viewName,model);
        }
        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .FirstOrDefaultAsync(m => m.ID == id);
            if (services == null)
            {
                return NotFound();
            }
            ViewBag.fee = services.Fee;
            return View(services);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Classification,Fee")] Services services)
        {
            if (ModelState.IsValid)
            {
                _context.Add(services);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }

        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Classification,Fee")] Services services)
        {
            if (id != services.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(services);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesExists(services.ID))
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
            return View(services);
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .FirstOrDefaultAsync(m => m.ID == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var services = await _context.Services.FindAsync(id);
            _context.Services.Remove(services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult all()
        {
            return View();
        }

        private bool ServicesExists(int id)
        {
            return _context.Services.Any(e => e.ID == id);
        }
    }
}
