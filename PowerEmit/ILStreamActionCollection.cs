using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerEmit
{
    public class ILStreamActionCollection : IList<IILStreamAction>
    {
        private readonly List<IILStreamAction> _actions = new List<IILStreamAction>();

        public IILStreamAction this[int index]
        {
            get => _actions[index];
            set => _actions[index] = value;
        }
        public int Count => _actions.Count;
        public bool IsReadOnly => false;

        public void Add(IILStreamAction item)
        {
            _actions.Add(item);
        }

        public void AddRange(IEnumerable<IILStreamAction> items)
            => _actions.AddRange(items);

        public void AddRange(params IILStreamAction[] items)
            => _actions.AddRange(items);

        public void Clear()
            => _actions.Clear();

        public bool Contains(IILStreamAction item)
            => _actions.Contains(item);

        public void CopyTo(IILStreamAction[] array, int arrayIndex)
            => _actions.CopyTo(array, arrayIndex);

        public IEnumerator<IILStreamAction> GetEnumerator()
            => _actions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)_actions).GetEnumerator();

        public int IndexOf(IILStreamAction item)
            => _actions.IndexOf(item);

        public void Insert(int index, IILStreamAction item)
            => _actions.Insert(index, item);

        public bool Remove(IILStreamAction item)
            => _actions.Remove(item);

        public void RemoveAt(int index)
            => _actions.RemoveAt(index);


        /// <summary>
        /// Searches operation instance that marks the specified label.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public IILStreamLabelMark? FindLabelMark(LabelDescriptor label)
        {
            return _actions
                .Select(x => x as IILStreamLabelMark)
                .FirstOrDefault(x => x?.Label == label);
        }
    }
}
