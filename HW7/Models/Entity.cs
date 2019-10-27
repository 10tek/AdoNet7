using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        //public int Id { get; set; }
    }
}
