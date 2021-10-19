namespace SignumExplorer.Models
{
    public partial class MultiOutTransaction
    {


            public long DbId { get; set; }
            public long Id { get; set; }
            public long Amount { get; set; }
            public long TotalAmount { get; set; }
            public long Fee { get; set; }
            public int Height { get; set; }
            public int Timestamp { get; set; }
            public sbyte Type { get; set; }
            public sbyte Subtype { get; set; }
            public long SenderId { get; set; }
            public long RecipientId { get; set; }




    }
}