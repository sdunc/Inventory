﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.models
{
    public class Note
    {
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Decimal Cost { get; set; }
    }
}
