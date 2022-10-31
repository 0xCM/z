//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class WfIterator<T>
    {
        protected WfIterator(IWfChannel channel)
        {
            Channel = channel;
        }

        protected readonly IWfChannel Channel;

        public Task<ExecToken> Start()
        {
            ExecToken Run()
            {
                var flow = Channel.Running();
                Iterate(Select());
                return Channel.Ran(flow);

            }
            return start(Run);
        }        

        protected abstract IEnumerable<T> Select();
    
        IEnumerable<T> Iterate(IEnumerable<T> src)
        {            
            var it = src.GetEnumerator();
            var item = Next(it, out var @continue);
            while(@continue)
            {
                if(item != null)
                    yield return item;
                
                if(!@continue)
                    break;
                item = Next(it, out @continue);
            }
        }

        T Next(IEnumerator<T> src, out bool @continue)
        {
            var item = default(T);
            try
            {
                @continue = src.MoveNext();
                item = src.Current;
                Traversed(item);
            }
            catch(Exception e)
            {
                Channel.Babble($"Trapped {e}");
                @continue = true;
            }
            return item;
        }

        protected virtual void Traversed(T item) {}
    }
}