using System;

namespace Vacscan.Net.Core.Internal
{
    public abstract class KeyAtomicObject
    {
        private string key;

        public string Key { 
            get => key;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                key = value;
            }
        }

        protected KeyAtomicObject()
        {

        }

        protected KeyAtomicObject(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            Key = key;
        }

        public override bool Equals(object obj)
        {
            return obj is KeyAtomicObject o && o.Key == Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
