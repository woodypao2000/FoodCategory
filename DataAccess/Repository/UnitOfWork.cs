using MVC8.DataAccess.Data;
using MVC8.DataAccess.Repository.IRepository;
using MVC8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC8.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository CategoryRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db=db;
            CategoryRepository = new CategoryRepository(_db);
        }
        public void Save()
        {
          _db.SaveChanges();
        }
    }
}
