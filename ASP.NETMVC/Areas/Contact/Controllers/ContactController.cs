using  ASP.NETMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETMVC.Areas.Contact.Controllers
{
    [Area("Contact")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("admin/contact")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }
        [HttpGet("admin/contact/details/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if(contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpGet("/contact/")]
        [AllowAnonymous]
        public IActionResult SentContact()
        {
             return View();
        }
        [HttpPost("/contact/")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SentContact(int id, [Bind("Id,FullName,Email,DataSent,Message,Phone")] ASP.NETMVC.Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

            [HttpGet("admin/contact/delete/{id?}")]
        public async Task<IActionResult> Delete( int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost("admin/contact/delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,DataSent,Message,Phone")] ASP.NETMVC.Models.Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            {
                return View();
            }
        }

    }
}
