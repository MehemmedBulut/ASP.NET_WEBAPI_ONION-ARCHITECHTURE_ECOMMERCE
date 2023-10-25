using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance.Repositories
{
    public class FileWriteRepository : WriteRepository<ECommerceAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(AppDbContext db) : base(db)
        {
        }
    }
}
