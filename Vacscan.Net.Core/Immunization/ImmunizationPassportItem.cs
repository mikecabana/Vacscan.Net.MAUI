using System;

namespace Vacscan.Net.Core.Immunization
{
    public class ImmunizationPassportItem
    {
        public ImmunizationPassportItem()
        {

        }

        protected ImmunizationPassportItem(ImmunizationPassportItemType type)
            : this()
        {
            Type = type;
        }

        public ImmunizationPassportItemType Type { get; set; }

        public DateTime Timestamp { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Type} {Description}";
        }
    }
}
