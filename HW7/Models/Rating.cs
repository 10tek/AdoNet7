using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Models
{
    public class Rating : Entity
    {
        public User User { get; set; }
        public VideoGame VideoGame { get; set; }
        public int GameRating { get; set; }
    }
}
