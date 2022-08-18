//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial struct AsmSyntaxModel
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
                => core.bytes(Value);
        }

        public interface IOperand<K,T> : IOperand<T>
            where T : unmanaged
            where K : unmanaged
        {
            new K Kind {get;}

            byte IOperand.Kind
                => core.bw8(Kind);
        }
    }
}