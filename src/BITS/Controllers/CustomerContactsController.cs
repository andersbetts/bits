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
    public class CustomerContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerContactsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CustomerContacts
        public async Task<IActionResult> Index(int? id)
        {
            var customerContacts = from cc in _context.CustomerContact
                                   select cc;

            customerContacts = customerContacts.Where(cc => cc.CustomerID == id).Include(c => c.Customer);

            ViewData["Customer"] = await _context.Customer.Where(c => c.ID == id).SingleAsync();

            return View(await customerContacts.ToListAsync());
        }

        // GET: CustomerContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact.SingleOrDefaultAsync(m => m.ID == id);
            if (customerContact == null)
            {
                return NotFound();
            }

            return View(customerContact);
        }

        // GET: CustomerContacts/Create
        public async Task<IActionResult> Create(int id)
        {
            //ViewData["CustomerID"] = HtmlHelperInputExtensions.Hidden()
            //new HiddenInputAttribute(_context.Customer, );
            //new SelectList(_context.Customer, "ID", "Name");
            ViewData["Customer"] = await _context.Customer.Where(c => c.ID == id).FirstAsync();
            return View();
        }

        // POST: CustomerContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,EmailAddress_1,EmailAddress_2,Enabled,Name,PhoneNumber_1,PhoneNumber_2")] CustomerContact customerContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerContact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = customerContact.CustomerID });
            }
            ViewData["CustomerID"] = customerContact.CustomerID;
            return View(customerContact);
        }

        // GET: CustomerContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact.SingleOrDefaultAsync(m => m.ID == id);
            if (customerContact == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "Name", customerContact.CustomerID);

            ViewData["Customer"] = await _context.Customer.Where(c => c.ID == customerContact.CustomerID).SingleAsync();

            return View(customerContact);
        }

        // POST: CustomerContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CustomerID,EmailAddress_1,EmailAddress_2,Enabled,Name,PhoneNumber_1,PhoneNumber_2")] CustomerContact customerContact)
        {
            if (id != customerContact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerContactExists(customerContact.ID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "Name", customerContact.CustomerID);
            return View(customerContact);
        }

        // GET: CustomerContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact.SingleOrDefaultAsync(m => m.ID == id);
            if (customerContact == null)
            {
                return NotFound();
            }

            return View(customerContact);
        }

        // POST: CustomerContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerContact = await _context.CustomerContact.SingleOrDefaultAsync(m => m.ID == id);
            _context.CustomerContact.Remove(customerContact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomerContactExists(int id)
        {
            return _context.CustomerContact.Any(e => e.ID == id);
        }
    }
}
