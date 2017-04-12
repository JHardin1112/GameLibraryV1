using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameLibraryV1.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Fill this in!")]
        public string GameId { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }
        public bool Owned { get; set; }

          }
}
