//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IOperand
    {
        byte Kind {get;}

        ReadOnlySpan<byte> Value {get;}
    }

    public interface IOperand<T> : IOperand
        where T : unmanaged
    {
        new T Value {get;}

        ReadOnlySpan<byte> IOperand.Value
            => sys.bytes(Value);
    }

    public interface IOperand<K,T> : IOperand<T>
        where T : unmanaged
        where K : unmanaged
    {
        new K Kind {get;}

        byte IOperand.Kind
            => sys.bw8(Kind);
    }     
}