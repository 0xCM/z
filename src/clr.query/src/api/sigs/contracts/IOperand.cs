//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IOperand
    {
        byte Kind {get;}
    }

    [Free]
    public interface IOperand<T> : IOperand
        where T : unmanaged
    {
        T Value {get;}
    }

    [Free]
    public interface IOperand<K,T> : IOperand<T>
        where T : unmanaged
        where K : unmanaged
    {
        new K Kind {get;}

        byte IOperand.Kind
            => sys.bw8(Kind);
    }     
}