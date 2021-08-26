using System;

namespace Vacscan.Net.Core.Miscellaneous
{
    public class Error
    {
        public string Key { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public Exception Exception {  get; set; }

        public override string ToString()
        {
            return $"{Key} {Label}";
        }
    }
}
