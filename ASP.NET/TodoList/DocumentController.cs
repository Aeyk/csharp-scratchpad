using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DocumentService _documentService;

        public DocumentController(ApplicationDbContext context, DocumentService documentService)
        {
            _context = context;
            _documentService = documentService;
        }

        // GET: Document
        public IActionResult Index()
        {
            // return View(_context.Document);
            return View(_documentService.ListDocuments());
        }

        // GET: Document/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _context.Document
                .Include(d => d.Parts)
                .FirstOrDefault(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Document/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm][Bind("Id,Owner,Parts")] CreateDocumentCommand document, [Bind("Parts")] Part[] parts)
        {
            return RedirectToAction("Edit", await _documentService.CreateDocument(document, parts));
        }

        // GET: Document/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _context.Document
                .Include(d => d.Parts)
                .FirstOrDefault(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm][Bind("Id,Owner,Parts")] CreateDocumentCommand document, [Bind("Parts")] Part[] parts)
        {
            var updatedDocument = _context.Document
                .Include(d => d.Parts)
                .Include(d => d.Owner)
                .FirstOrDefault(m => m.Id == id);
            
            if (updatedDocument == null)
            {
                return NotFound();
            }

            try
            {
                updatedDocument = await _documentService.EditDocument(id, document);
                _context.Update(updatedDocument);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                if (!DocumentExists(document.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            } else {
                return View(updatedDocument);
            }
            
        }

        // GET: Document/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _context.Document
                .Include(d => d.Parts)
                .FirstOrDefault(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = _context.Document
                .Include(d => d.Parts)
                .FirstOrDefault(m => m.Id == id);
            if (document != null)
            {
                _context.Document.Remove(document);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Document.Any(e => e.Id == id);
        }
    }
}
