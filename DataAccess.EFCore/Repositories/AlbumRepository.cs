using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataAccess.EFCore.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        protected readonly IGenericRepository<Album> _context;
        public AlbumRepository(IGenericRepository<Album> context ) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Album> Get(string titlesearch)
        {
            if(string.IsNullOrEmpty(titlesearch) || string.IsNullOrWhiteSpace(titlesearch))
                throw new ArgumentNullException(nameof(titlesearch));

            var response = _context.Get(s => s.Title.Contains(titlesearch)).ToList();
            string replacement = "<b>" + titlesearch + "</b>";
            foreach (var item in response)
            {
                item.Title = item.Title.Replace(titlesearch, replacement,StringComparison.OrdinalIgnoreCase);
            }

            return response;
        }


    }
}
