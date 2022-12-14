//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract partial class ChildProcess : ProcessAdapter, IDisposable
    {
        static ConcurrentDictionary<ProcessId, ChildProcess> Children = new();

        protected ChildProcess()
        {
        }

        protected ChildProcess(Process process)
            : base(process)
        {
            Children.TryAdd(process.Id, this);
        }

        protected virtual void Disposing()
        {

        }

        public override void Kill()
        {
            Children.TryRemove(Id);
            base.Kill();
        }

        public void Dispose()
        {
            Disposing();
            Kill();
        }
    }
    
    public abstract class ChildProcess<P> : ChildProcess
        where P : ChildProcess<P>, new()
    {
        protected ChildProcess()
        {
            
        }

        protected ChildProcess(Process process)
            : base(process)
        {
            
        }
    }


    partial class ChildProcess
    {
        public class PassThrough : ChildProcess<PassThrough>
        {
            public PassThrough()
            {

            }

            public PassThrough(Process process)
                : base(process)
            {

            }
        }
    }
}