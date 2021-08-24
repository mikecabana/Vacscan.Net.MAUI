using System;
using System.Collections.Generic;
using System.Text;

namespace Vacscan.Net.Core.Models
{
    public class Error
    {
        public string Label { get; set; }

        public string Description { get; set; }

        public Exception Exception {  get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
