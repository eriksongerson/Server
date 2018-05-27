using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class CustomList<T> : List<T>
    {
        public event EventHandler OnAdd;
        public event EventHandler OnRemove;
        public event EventHandler OnLengthChanged;
        public new void Add(T item)
        {
            base.Add(item);
            OnAdd?.Invoke(this, null);
            OnLengthChanged?.Invoke(this, null);
        }
        public new void Remove(T item)
        {
            base.Remove(item);
            OnRemove?.Invoke(this, null);
            OnLengthChanged?.Invoke(this, null);
        }
    }
}
