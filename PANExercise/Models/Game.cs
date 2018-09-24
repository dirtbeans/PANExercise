using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PANExercise.Models
{
    public class Game
    {
        public int GameCode { get; set; }
        public string GameName { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public List<SelectListItem> GameList { get; set; }

    }
}