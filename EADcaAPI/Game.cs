using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADcaAPI
{
    public class Game
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public string Developer { get; set; }
        public DateTime releaseDate {  get; set; }
        public string platform { get; set; }
    }
}
