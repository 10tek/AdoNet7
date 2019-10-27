using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Models
{
    public class VideoGame : Entity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public double AvgRating { get; set; }
    }
}
