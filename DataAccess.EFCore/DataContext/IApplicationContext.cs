using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore
{
    public interface IApplicationContext
    {
        DbSet<Album> Albums { get; set; }

        int SaveChanges();

        void Dispose();
    }
}
