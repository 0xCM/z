//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TernaryFlow<F,T> : GatedFlow<F,T>
        where F : TernaryFlow<F,T>,new()
        where T : unmanaged
    {
        public abstract T Flow(T a, T b, T c);
    }
}