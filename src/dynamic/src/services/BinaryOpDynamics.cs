//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct BinaryOpDynamics
    {
        const NumericKind Closure = UnsignedInts;

        public static unsafe DynamicOp<BinaryOp<T>> dynop<T>(Identifier name, ReadOnlySpan<byte> f)
        {
            var emitted = create<T>(name, (MemoryAddress)memory.liberate(f), out var method);
            return (method,emitted);
        }

        [Op, Closures(Closure)]
        public static void eval<T>(Identifier name, ReadOnlySpan<byte> f, ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
        {
            var binop = create<T>(name,f);
            var count = dst.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = binop(skip(a,i), skip(b,i));
        }

        [MethodImpl(Inline)]
        public static T eval<T>(Identifier name, ReadOnlySpan<byte> f, T x, T y)
            where T : unmanaged
                => create<T>(name, f)(x, y);

        [Op, Closures(UInt64k)]
        public static unsafe BinaryOp<T> create<T>(Identifier name, byte* pCode)
            => create<T>(name, (MemoryAddress)pCode, out _);

        [Op, Closures(UInt64k)]
        public static unsafe BinaryOp<T> create<T>(OpIdentity id, ReadOnlySpan<byte> code)
            => create<T>(id.Format(), memory.liberate(code), out _);

        [Op, Closures(UInt64k)]
        public static unsafe BinaryOp<T> create<T>(Identifier name, ReadOnlySpan<byte> f)
            => create<T>(name, (MemoryAddress)memory.liberate(f), out _);

        static unsafe BinaryOp<T> create<T>(Identifier name, MemoryAddress f, out DynamicMethod method)
        {
            var tFunc = typeof(BinaryOp<T>);
            var tOperand = typeof(T);
            var args = array(tOperand, tOperand);
            method = new DynamicMethod(name, tOperand, args, tFunc.Module);
            var g = method.GetILGenerator();
            g.Emit(OpCodes.Ldarg_0);
            g.Emit(OpCodes.Ldarg_1);
            g.Emit(OpCodes.Ldc_I8, f);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, tOperand, args);
            g.Emit(OpCodes.Ret);
            return (BinaryOp<T>)CellDelegate.define(name, f, method, method.CreateDelegate(tFunc));
        }
    }
}