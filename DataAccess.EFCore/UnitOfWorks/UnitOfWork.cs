using DataAccess.EFCore.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationContext _context;      
        public UnitOfWork(IApplicationContext context, IAlbumRepository albumRepository)
        {
            _context = context;
          
            Albums = albumRepository;
        }
        public IAlbumRepository Albums { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
