using System;
using System.Collections;
using System.Collections.Generic;
using EierfamBl;

namespace GefluegelListe
{
    // Generische Typen
    // Event, wenn Element hinzugefügt
    // IEnumerable

    public class GefluegelListe<T> : IEnumerable<T> where T : IEiLeger
    {
        List<T> liste = new List<T>();

        public event EventHandler<ListenEventArgs> ElementAdded;

        /// <summary>
        /// Event-Trigger für das ElementAdded-Event
        /// </summary>
        private void OnElementAdded(T element)
        {
            //if (ElementAdded!=null)
            //{
            //    ElementAdded(this, new ListenEventArgs(element));
            //}
            ElementAdded?.Invoke(this, new ListenEventArgs(element));
        }

        /// <summary>
        /// Fügt der Liste ein weiteres Element am Ende der Liste an.
        /// </summary>
        /// <param name="element">Das hinzuzufügende Element.</param>
        public void Add(T element)
        {
            liste.Add(element);
            OnElementAdded(element);
        }

        #region IEnumerable<T>-Implentierung

        public IEnumerator<T> GetEnumerator()
        {
            return liste.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() // Explizite Interface-Implementierung für IEnumerable (ohne <T>, nicht generisch!)
        {
            return this.GetEnumerator();
        }

        #endregion

        // Nested Class
        public class ListenEventArgs : EventArgs
        {
            public ListenEventArgs(T element)
            {
                this.Element = element;
            }

            public T Element { get; set; }
        }
    }

}

