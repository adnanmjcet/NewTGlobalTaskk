using System;
using System.Collections.Generic;
using System.Text;

namespace NewTGlobalTask
{
    public class Drink : VendingItem
    {
        public const string Message = "Cool, Cola, Yum!";

        public Drink(
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
