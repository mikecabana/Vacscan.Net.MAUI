using System;

namespace Vacscan.Net.SHC.Models
{
    public class SmartHealthCard
    {
        public Uri Iss { get; set; }

        public decimal Iat { get; set; }
        
        public Vc Vc { get; set; }

        public string Raw { get; set; }
    }

    public class Vc
    {
        public string[] Context { get; set; }

        public string[] Type { get; set; }
        
        public Credentialsubject CredentialSubject { get; set; }
    }

    public class Credentialsubject
    {
        public string FhirVersion { get; set; }

        public Fhirbundle FhirBundle { get; set; }
    }

    public class Fhirbundle
    {
        public string ResourceType { get; set; }

        public string Type { get; set; }
        
        public Entry[] Entry { get; set; }
    }

    public class Entry
    {
        public Resource Resource { get; set; }
    }

    public class Resource
    {
        public string ResourceType { get; set; }
        
        public Name[] Name { get; set; }
        
        public string BirthDate { get; set; }
        
        public string Gender { get; set; }
        
        public Vaccinecode VaccineCode { get; set; }
        
        public Patient Patient { get; set; }
        
        public string LotNumber { get; set; }
        
        public string Status { get; set; }
        
        public DateTime OccurrenceDateTime { get; set; }
        
        public Location Location { get; set; }
        
        public Protocolapplied ProtocolApplied { get; set; }
        
        public Note[] Note { get; set; }
        
        public bool Reported { get; set; }
        
        public bool WasNotGiven { get; set; }
    }

    public class Vaccinecode
    {
        public Coding[] Coding { get; set; }
    }

    public class Coding
    {
        public string System { get; set; }
        
        public string Code { get; set; }
    }

    public class Patient
    {
        public string Reference { get; set; }
    }

    public class Location
    {
        public string Reference { get; set; }
        
        public string Display { get; set; }
    }

    public class Protocolapplied
    {
        public decimal DoseNumber { get; set; }
        
        public Targetdisease TargetDisease { get; set; }
    }

    public class Targetdisease
    {
        public Coding1[] Coding { get; set; }
    }

    public class Coding1
    {
        public string System { get; set; }
        
        public string Code { get; set; }
    }

    public class Name
    {
        public string[] Family { get; set; }

        public string[] Given { get; set; }
    }

    public class Note
    {
        public string Text { get; set; }
    }

}
