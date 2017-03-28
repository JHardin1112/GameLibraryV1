using System;
using System.Collections.Generic;

namespace GameLibraryV1.Models
{
    public partial class Games
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }
        public bool? Owned { get; set; }
    }
}
