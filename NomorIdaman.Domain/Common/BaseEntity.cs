﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Domain.Common {
    public class BaseEntity {

        [Required]
        public int Id { get; set; }
    }
}
