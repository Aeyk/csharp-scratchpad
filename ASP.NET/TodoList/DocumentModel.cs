using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Duende.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Models;


public class Document
{
    public int Id { get; set; }    
    public IdentityUser Owner { get; set; }
    public List<Part> Parts { get; set; } = new();
}
    
public class Part
{
    
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public string Content { get; set; }
}
public class CreateDocumentCommand
{
    public int DocumentId { get; set; }
    public IdentityUser Owner { get; set; }
    public ICollection<Part> Parts { get; set; }
    public int Id { get; internal set; }
}
