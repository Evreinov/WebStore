﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.DTO
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
    }
}
