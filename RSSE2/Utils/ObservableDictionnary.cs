using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ObservableDictionnary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged
    {
        Dictionary<TKey, TValue> data;

        public ObservableDictionnary()
        {
            data = new Dictionary<TKey, TValue>();
        }


        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }

        public TValue this[TKey key]
        {
            get => (data[key]);
            set
            {

                data[key] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, key,key));
            }
        }

        public ICollection<TKey> Keys => ((IDictionary<TKey, TValue>)data).Keys;

        public ICollection<TValue> Values => ((IDictionary<TKey, TValue>)data).Values;

        public int Count => ((IDictionary<TKey, TValue>)data).Count;

        public bool IsReadOnly => ((IDictionary<TKey, TValue>)data).IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            data.Add(key, value);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, key));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            data.Add(item.Key,item.Value);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item.Key));
        }

        public void Clear()
        {
            data.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return data.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return data.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)data).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)data).GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            bool result = data.Remove(key);
            if (result)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, key));
            }
            return result;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool result = ((IDictionary<TKey, TValue>)data).Remove(item);
            if (result)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item.Key));
            }
            return result;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return ((IDictionary<TKey, TValue>)data).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)data).GetEnumerator();
        }
    }
}
