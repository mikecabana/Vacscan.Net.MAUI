using System;

namespace Vacscan.Net.Core.Models
{
    public class VaccinationPassportItem
    {
        public VaccinationPassportItem()
        {

        }

        protected VaccinationPassportItem(VaccinationPassportItemType type)
            : this()
        {
            Type = type;
        }

        public VaccinationPassportItemType Type { get; set; }

        public DateTime Timestamp { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Type} {Description}";
        }
    }
}
