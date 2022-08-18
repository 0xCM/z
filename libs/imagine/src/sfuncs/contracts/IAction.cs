//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IAction<A> : ISfxOp
    {
        void Invoke(A a);
    }

    [Free, SFx]
    public interface IAction<A0,A1> : ISfxOp
    {
        void Invoke(A0 a0, A1 a1);
    }

    [Free, SFx]
    public interface IAction<A0,A1,A2> : ISfxOp
    {
        void Invoke(A0 a0, A1 a1, A2 a2);
    }
}