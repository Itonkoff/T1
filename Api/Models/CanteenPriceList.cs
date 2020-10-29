using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class CanteenPriceList
    {
        public int Id { get; set; }
        public string Meal { get; set; }
        public string Price { get; set; }
    }
}
