using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BITS.Data;
using BITS.Models;

namespace BITS.Controllers
{
    public class IssueDescriptionItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssueDescriptionItemsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: IssueDescriptionItems
        public async Task<IActionResult> Index(int? id)
        {
            var applicationDbContext = _context.IssueDescriptionItem.Include(i => i.Parent);

            var idi = from i in _context.IssueDescriptionItem
                      select i;

            idi = idi.Where(i => i.ParentID == id);

            if (id != null)
            {
                var issueDescriptionItem = await _context.IssueDescriptionItem.SingleOrDefaultAsync(m => m.ID == id);
                if (issueDescriptionItem == null)
                {
                    return NotFound();
                }

                issueDescriptionItem.Parent = await _context.IssueDescriptionItem.SingleOrDefaultAsync(m => m.ID == issueDescriptionItem.ParentID);

                ViewData["Self"] = issueDescriptionItem;
            }

            ViewData["ID"] = id;

            return View(await idi.ToListAsync());
        }

        // GET: IssueDescriptionItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueDescriptionItem = await _context.IssueDescriptionItem.SingleOrDefaultAsync(m => m.ID == id);
            if (issueDescriptionItem == null)
            {
                return NotFound();
            }

            return View(issueDescriptionItem);
        }

        // GET: IssueDescriptionItems/Create
        public IActionResult Create(int? id)
        {
            //ViewData["ParentID"] = new SelectList(_context.IssueDescriptionItem, "ID", "ID");
            ViewData["ParentID"] = id;
            return View();
        }

        // POST: IssueDescriptionItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Enabled,Name,ParentID")] IssueDescriptionItem issueDescriptionItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issueDescriptionItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewData["ParentID"] = issueDescriptionItem.ParentID;
            ViewData["ParentID"] = new SelectList(_context.IssueDescriptionItem, "ID", "Name", issueDescriptionItem.ParentID);
            return View(issueDescriptionItem);
        }

        // GET: IssueDescriptionItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueDescriptionItem = await _context.IssueDescriptionItem.SingleOrDefaultAsync(m => m.ID == id);
            if (issueDescriptionItem == null)
            {
                return NotFound();
            }
            ViewData["ParentID"] = new SelectList(_context.IssueDescriptionItem, "ID", "Name", issueDescriptionItem.ParentID);
            return View(issueDescriptionItem);
        }

        // POST: IssueDescriptionItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Enabled,Name,ParentID")] IssueDescriptionItem issueDescriptionItem)
        {
            if (id != issueDescriptionItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issueDescriptionItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueDescriptionItemExists(issueDescriptionItem.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ParentID"] = new SelectList(_context.IssueDescriptionItem, "ID", "ID", issueDescriptionItem.ParentID);
            return View(issueDescriptionItem);
        }

        // GET: IssueDescriptionItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueDescriptionItem = await _context.IssueDescriptionItem.SingleOrDefaultAsync(m => m.ID == id);
            if (issueDescriptionItem == null)
            {
                return NotFound();
            }

            return View(issueDescriptionItem);
        }

        // POST: IssueDescriptionItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issueDescriptionItem = await _context.IssueDescriptionItem.SingleOrDefaultAsync(m => m.ID == id);
            _context.IssueDescriptionItem.Remove(issueDescriptionItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IssueDescriptionItemExists(int id)
        {
            return _context.IssueDescriptionItem.Any(e => e.ID == id);
        }
    }
}
