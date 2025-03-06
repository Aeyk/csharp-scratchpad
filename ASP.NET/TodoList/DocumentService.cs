
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services;

public class DocumentService {
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DocumentService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }

    public async Task<Document> EditDocument(int DocumentId, CreateDocumentCommand cmd) {
        var document = _context.Document
            .Include(d => d.Parts)
            .Include(d => d.Owner)
            .FirstOrDefault(m => m.Id == DocumentId);
        var email = _httpContextAccessor.HttpContext.User.Identity.Name;
        var owner = _context.User
            .Where(u => u.Email == email)
            .FirstOrDefault();
        cmd.Id = DocumentId;
        cmd.Owner = owner;
        document.Parts = cmd.Parts.ToList();
        _context.Update(document);
        await _context.SaveChangesAsync();
        return document;
    }

    public async Task<Document> CreateDocument(CreateDocumentCommand cmd, Part[] parts) {
        var email = _httpContextAccessor.HttpContext.User.Identity.Name;
        var owner = _context.User
                .Where(u => u.Email == email)
                .FirstOrDefault();
        var document = new Document() {
            Owner = owner,
            Parts = new List<Part>()    
        };
        // if(cmd.Parts != null && cmd.Parts.Count > 0) 
            foreach (var part in parts) {
                document.Parts.Add(part);
            }
        
        _context.Add(document);
        await _context.SaveChangesAsync();
        return document;
    }
    public ICollection<Document> ListDocuments() {
        var email = _httpContextAccessor.HttpContext.User.Identity.Name;
        var owner = _context.Users
            .Where(u => u.Email == email)
            .FirstOrDefault();
        
        var documents = _context.Document.Where(d => d.Owner == owner).ToList();
        
        foreach(var document in documents) {
            var parts = _context.Part.Where(p => p.DocumentId == document.Id).ToList();
            document.Parts = parts;
        }
        return documents;
    }
}