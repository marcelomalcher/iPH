using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CCXP.Utils.Collections
{
    public class SynchronizedQueue : Queue
    {
        object _syncObj;
        Queue _q;

        public SynchronizedQueue(Queue q)
        {
            _syncObj = q.SyncRoot;
            _q = q;
        }

        public override void Enqueue(object v)
        {
            lock (_syncObj)
            {
                this._q.Enqueue(v);
            }
        }

        public override object Dequeue()
        {
            lock (_syncObj)
            {
                return this._q.Dequeue();
            }
        }

        public override int Count
        {
            get
            {
                lock (_syncObj)
                {
                    return this._q.Count;
                }
            }
        }
    }
}
