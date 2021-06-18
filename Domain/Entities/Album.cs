using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Rating { get; set; }
    }
}
