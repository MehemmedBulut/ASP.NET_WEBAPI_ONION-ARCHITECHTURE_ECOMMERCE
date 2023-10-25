using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance.Repositories
{
    public class FileReadRepository : ReadRepository<ECommerceAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(AppDbContext db) : base(db)
        {
        }
    }
}
