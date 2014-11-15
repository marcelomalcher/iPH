using System;
using System.Runtime.InteropServices;
using CompactFormatter.Attributes;
using System.Collections;

namespace CCXP.Utils.Collections
{
    // Summary:
    //     Provides the abstract base class for a strongly typed collection of key/value
    //     pairs.
    [CompactFormatter.Attributes.Serializable]
    [ComVisible(true)]
    public abstract class DictionaryBase : IDictionary, ICollection, IEnumerable
    {

        Hashtable hashtable;

        protected DictionaryBase()
        {
            hashtable = new Hashtable();
        }

        public void Clear()
        {
            OnClear();
            hashtable.Clear();
            OnClearComplete();
        }

        public int Count
        {
            get
            {
                return hashtable.Count;
            }
        }

        protected IDictionary Dictionary
        {
            get
            {
                return this;
            }
        }

        protected Hashtable InnerHashtable
        {
            get
            {
                return hashtable;
            }
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (index < 0)
                throw new ArgumentOutOfRangeException("index must be possitive");
            if (array.Rank > 1)
                throw new ArgumentException("array is multidimensional");
            int size = array.Length;
            if (index > size)
                throw new ArgumentException("index is larger than array size");
            if (index + Count > size)
                throw new ArgumentException("Copy will overlflow array");

            DoCopy(array, index);
        }

        private void DoCopy(Array array, int index)
        {
            foreach (DictionaryEntry de in hashtable)
                array.SetValue(de, index++);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return hashtable.GetEnumerator();
        }

        protected virtual void OnClear()
        {
        }

        protected virtual void OnClearComplete()
        {
        }

        protected virtual object OnGet(object key, object current_value)
        {
            return current_value;
        }

        protected virtual void OnInsert(object key, object current_value)
        {
        }

        protected virtual void OnInsertComplete(object key, object current_value)
        {
        }

        protected virtual void OnSet(object key, object current_value, object new_value)
        {
        }

        protected virtual void OnSetComplete(object key, object current_value, object new_value)
        {
        }

        protected virtual void OnRemove(object key, object current_value)
        {
        }

        protected virtual void OnRemoveComplete(object key, object current_value)
        {
        }

        protected virtual void OnValidate(object key, object current_value)
        {
        }

        bool IDictionary.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool IDictionary.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IDictionary.this[object key]
        {
            get
            {
                OnGet(key, hashtable[key]);
                object value = hashtable[key];
                return value;
            }

            set
            {
                OnValidate(key, value);
                object current_value = hashtable[key];
                OnSet(key, current_value, value);
                hashtable[key] = value;
                try
                {
                    OnSetComplete(key, current_value, value);
                }
                catch
                {
                    hashtable[key] = current_value;
                    throw;
                }
            }
        }

        ICollection IDictionary.Keys
        {
            get
            {
                return hashtable.Keys;
            }
        }

        ICollection IDictionary.Values
        {
            get
            {
                return hashtable.Values;
            }
        }

        void IDictionary.Add(object key, object value)
        {
            OnValidate(key, value);
            OnInsert(key, value);
            hashtable.Add(key, value);
            try
            {
                OnInsertComplete(key, value);
            }
            catch
            {
                hashtable.Remove(key);
                throw;
            }
        }

        void IDictionary.Remove(object key)
        {
            object value = hashtable[key];
            OnValidate(key, value);
            OnRemove(key, value);
            hashtable.Remove(key);
            OnRemoveComplete(key, value);
        }

        bool IDictionary.Contains(object key)
        {
            return hashtable.Contains(key);
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return hashtable.IsSynchronized;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return hashtable.SyncRoot;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return hashtable.GetEnumerator();
        }
    }
}
