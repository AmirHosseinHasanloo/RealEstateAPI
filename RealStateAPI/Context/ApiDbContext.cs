using Microsoft.EntityFrameworkCore;
using RealStateAPI.Models;

namespace RealStateAPI.Context;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options){}

    public DbSet<Category> Category { get; set; }
}