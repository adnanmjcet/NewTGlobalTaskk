using System;
using System.Collections.Generic;
using System.Text;

namespace NewTGlobalTask
{
    public class Chip : VendingItem
    {
        public const string Message = "Crunch, Crunch, Yum!";

        public Chip(
            string productName,
            decimal price,
            int itemsRemaining)
                : base(
                productName,
                price,
                itemsRemaining,
                Message)
        {
        }
    }
}
