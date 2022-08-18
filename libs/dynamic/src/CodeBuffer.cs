//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static DFx;

    public class CodeBuffer : IDisposable
    {
        public static CodeBuffer allocate(uint size = Pow2.T14)
            => new CodeBuffer(size);

        NativeBuffer Code;

        ByteSize EffectiveSize;

        ByteSize Capacity;

        uint Offset;

        CodeBuffer(ByteSize size)
        {
            Code = memory.native(size);
            Capacity = size;
            Clear();
        }

        public void Dispose()
        {
            Code.Dispose();
        }

        public void Clear()
        {
            Code.Clear();
            Offset = 0;
        }

        public ByteSize Remainder
        {
            [MethodImpl(Inline)]
            get => Capacity - Offset;
        }

        public ByteSize Load(ReadOnlySpan<byte> src)
        {
            Clear();
            var size = min(Capacity, src.Length);
            var buffer = Code.Edit;
            for(var i=0; i<size; i++)
                seek(buffer, i) = skip(src,i);

            EffectiveSize = size;
            return EffectiveSize;
        }

        [MethodImpl(Inline)]
        NativeBuffer Reserve(ByteSize size)
        {
            Offset += size;
            return Code;
        }

        public FuncSpec<A,B> LoadUnaryFunc<A,B>(Identifier name, ReadOnlySpan<byte> src)
            => DFx.func<A,B>(name, DFx.load(src, Offset, Reserve(src.Length)), out _);

        public UnaryOpSpec<T> LoadUnaryOp<T>(Identifier name, ReadOnlySpan<byte> src)
            => DFx.unaryop<T>(name, DFx.load(src, Offset, Reserve(src.Length)));

        public BinOpSpec<T> LoadBinOp<T>(Identifier name, ReadOnlySpan<byte> src)
            => DFx.binop<T>(name, DFx.load(src, Offset, Reserve(src.Length)));

        public EmitterSpec<T> LoadEmitter<T>(Identifier name, ReadOnlySpan<byte> src)
            => DFx.emitter<T>(name, DFx.load(src, Offset, Reserve(src.Length)));

        //var _f = Marshal.GetDelegateForFunctionPointer<DelegateBindings.cpuid>(block.Address);
        // var f = DynamicOperations.binop<ulong>(RoutineName, block);
    }
}