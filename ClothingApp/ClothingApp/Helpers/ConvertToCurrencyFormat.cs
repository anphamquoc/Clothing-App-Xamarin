using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Helpers
{
    class ConvertToCurrencyFormat
    {
        public string Result { get; set; }
        public ConvertToCurrencyFormat(string value)
        {
            this.Result = string.Format("{0:#,0.#}", Convert.ToDecimal(value));
        }
    }
}
