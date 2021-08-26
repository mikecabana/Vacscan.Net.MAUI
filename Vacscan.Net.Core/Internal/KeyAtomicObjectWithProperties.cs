using System.Collections.Generic;

namespace Vacscan.Net.Core.Internal
{
    public abstract class KeyAtomicObjectWithProperties : KeyAtomicObject
    {
        protected KeyAtomicObjectWithProperties()
            : base() { }

        protected KeyAtomicObjectWithProperties(string key)
            : base(key) { }

        public IDictionary<object, object> Properties { get; } = new Dictionary<object, object>();

        public TValue GetProperty<TValue>(object key)
        {
            var oValue = GetProperty(key);
            return oValue is TValue tValue ? tValue : default(TValue); 
        }

        public object GetProperty(object key)
        {
            Properties.TryGetValue(key, out var value);
            return value;
        }

        public void SetProperty(object key, object value)
        {
            Properties[key] = value;
        }
    }
}
