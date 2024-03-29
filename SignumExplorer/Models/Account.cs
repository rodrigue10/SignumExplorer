﻿using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class Account
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public int CreationHeight { get; set; }
        public byte[]? PublicKey { get; set; }
        public int? KeyHeight { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Height { get; set; }
        public bool? Latest { get; set; }
    }
}
