﻿using System;
using System.Collections.Generic;

namespace SignumExplorer.Models
{
    public partial class MultiOutTransactionAttach
    {
        public long DbId { get; set; }
        public long Id { get; set; }
        public long SenderId { get; set; }
        public byte[]? AttachmentBytes { get; set; }
        public sbyte Type { get; set; }
        public sbyte Subtype { get; set; }
        public long Amount { get; set; }
        public long Fee { get; set; }
        public int Timestamp { get; set; }
        public string? SenderName { get; set; }
    }
}
