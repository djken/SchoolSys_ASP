using Microsoft.EntityFrameworkCore;

public class SchoolSysMoContext : DbContext
{
    public SchoolSysMoContext(DbContextOptions<SchoolSysMoContext> options)
        : base(options)
    {
    }

    public DbSet<SchoolSysMo.Models.Classroom> Classroom { get; set; } = default!;

    public DbSet<SchoolSysMo.Models.Course> Course { get; set; } = default!;

    public DbSet<SchoolSysMo.Models.Student> Student { get; set; } = default!;

    public DbSet<SchoolSysMo.Models.Grade> Grade { get; set; } = default!;
}
