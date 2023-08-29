//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Control : IControl
    {
        protected virtual void Disposing() {}

        void IDisposable.Dispose()
            => Disposing();
    }
}