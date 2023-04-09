//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolStreamWriter<T> : IToolStreamWriter
        where T : ToolStreamWriter<T>
    {
        protected abstract void Dispose();
        
        public abstract void Write(TextLine src);

        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
