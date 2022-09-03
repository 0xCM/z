//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class UnaryFlow<F,T> : GatedFlow<F,T>
        where F : UnaryFlow<F,T>,new()
        where T : unmanaged
    {
        public abstract T Flow(T a);
    }
}