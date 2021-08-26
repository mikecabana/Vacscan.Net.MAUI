using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Vacscan.Net.Core.Internal.DependencyInjection
{
    public class SingletonInstanceServiceRegistration<TInstance> : IServiceCollection
        where TInstance : class
    {
        public TInstance Instance { get; }

        public int Count => ((ICollection<ServiceDescriptor>)services).Count;

        public bool IsReadOnly => ((ICollection<ServiceDescriptor>)services).IsReadOnly;

        public ServiceDescriptor this[int index] { get => ((IList<ServiceDescriptor>)services)[index]; set => ((IList<ServiceDescriptor>)services)[index] = value; }

        private readonly IServiceCollection services;

        public SingletonInstanceServiceRegistration(IServiceCollection services, TInstance instance)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this.services = services;
            Instance = instance;
        }

        public int IndexOf(ServiceDescriptor item)
        {
            return ((IList<ServiceDescriptor>)services).IndexOf(item);
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            ((IList<ServiceDescriptor>)services).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<ServiceDescriptor>)services).RemoveAt(index);
        }

        public void Add(ServiceDescriptor item)
        {
            ((ICollection<ServiceDescriptor>)services).Add(item);
        }

        public void Clear()
        {
            ((ICollection<ServiceDescriptor>)services).Clear();
        }

        public bool Contains(ServiceDescriptor item)
        {
            return ((ICollection<ServiceDescriptor>)services).Contains(item);
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            ((ICollection<ServiceDescriptor>)services).CopyTo(array, arrayIndex);
        }

        public bool Remove(ServiceDescriptor item)
        {
            return ((ICollection<ServiceDescriptor>)services).Remove(item);
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return ((IEnumerable<ServiceDescriptor>)services).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)services).GetEnumerator();
        }
    }
}
