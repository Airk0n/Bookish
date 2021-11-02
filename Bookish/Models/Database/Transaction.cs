using System;

namespace Bookish.Models.Database
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BookCollectionId { get; set; }
        public int Member { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}