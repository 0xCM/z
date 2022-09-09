//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;

    using static Root;
    using static CellDelegates;

    using U = UnaryOperatorClass;
    using B = BinaryOperatorClass;
    using T = TernaryOperatorClass;

    readonly struct Dynexus : IDynexus
    {
        [MethodImpl(Inline)]
        public static IDynexus service()
            => new Dynexus(MultiDiviner.Service);

        readonly IMultiDiviner Diviner;

        [MethodImpl(Inline)]
        internal Dynexus(IMultiDiviner diviner)
            => Diviner = diviner;

        [MethodImpl(Inline)]
        OpIdentity Identify(MethodInfo src)
            => Diviner.Identify(src);

        U Unary => default;

        B Binary => default;

        T Ternary => default;

        DynamicDelegate<UnaryOp<Vector128<T>>> IDynexus.CreateUnaryOp<T>(MethodInfo src, W128 w, byte imm)
            => Dynop.EmbedVUnaryOpImm(VK.vk128<T>(), Identify(src), src, imm);

        DynamicDelegate<BinaryOp<Vector128<T>>> IDynexus.CreateBinaryOp<T>(MethodInfo src, W128 w, byte imm)
            => Dynop.EmbedVBinaryOpImm(VK.vk128<T>(), Identify(src), src, imm);

        DynamicDelegate<UnaryOp<Vector256<T>>> IDynexus.CreateUnaryOp<T>(MethodInfo src, W256 w, byte imm)
            => Dynop.EmbedVUnaryOpImm(VK.vk256<T>(), Identify(src), src, imm);

        DynamicDelegate<BinaryOp<Vector256<T>>> IDynexus.CreateBinaryOp<T>(MethodInfo src, W256 w, byte imm)
            => Dynop.EmbedImmVBinaryOpImm(VK.vk256<T>(), Identify(src), src, imm);


        Option<DynamicDelegate> IDynexus.CreateUnaryOp(NativeTypeWidth w, MethodInfo src, byte imm8)
        {
            if(w == NativeTypeWidth.W128)
                return DynamicImmediate.EmbedVUnaryOpImm(w128, src,imm8, Identify(src));
            else if(w == NativeTypeWidth.W256)
                return DynamicImmediate.EmbedVUnaryOpImm(w256, src,imm8, Identify(src));
            else
                return Option.none<DynamicDelegate>();
        }

        Option<DynamicDelegate> IDynexus.CreateBinaryOp(NativeTypeWidth w, MethodInfo src, byte imm8)
        {
            if(w == NativeTypeWidth.W128)
                return DynamicImmediate.EmbedVBinaryOpImm(w128, src, imm8, Identify(src));
            else if(w == NativeTypeWidth.W256)
                return DynamicImmediate.EmbedVBinaryOpImm(w256, src, imm8, Identify(src));
            else
                return Option.none<DynamicDelegate>();
        }

        UnaryOp<F> IDynexus.EmitFixedUnary<F>(BufferToken dst, ApiCodeBlock src)
            => (UnaryOp<F>)Emit(src.Id, typeof(UnaryOp<F>), typeof(F),
                    sys.array(typeof(F)), dst.Load(src.Encoded).Handle);

        BinaryOp<F> IDynexus.EmitFixedBinary<F>(BufferToken dst, ApiCodeBlock src)
            => (BinaryOp<F>)Emit(src.Id, typeof(BinaryOp<F>), typeof(F),
                    sys.array(typeof(F),typeof(F)),dst.Load(src.Encoded).Handle);

        TernaryOp<F> IDynexus.EmitFixedTernary<F>(BufferToken dst, ApiCodeBlock src)
            => (TernaryOp<F>)Emit(src.Id, typeof(TernaryOp<F>), typeof(F),
                    sys.array(typeof(F), typeof(F), typeof(F)), dst.Load(src.Encoded).Handle);

        UnaryOp8 IDynexus.EmitFixedUnary(BufferToken dst, W8 w, ApiCodeBlock src)
            => Emit(src.Id, Unary, w, dst.Load(src.Encoded));

        UnaryOp16 IDynexus.EmitFixedUnary(BufferToken dst, W16 w, ApiCodeBlock src)
            => Emit(src.Id, Unary, w, dst.Load(src.Encoded));

        UnaryOp32 IDynexus.EmitFixedUnary(BufferToken dst, W32 w, ApiCodeBlock src)
            => Emit(src.Id, Unary, w, dst.Load(src.Encoded));

        UnaryOp64 IDynexus.EmitFixedUnary(BufferToken dst, W64 w, ApiCodeBlock src)
            => Emit(src.Id, Unary, w, dst.Load(src.Encoded));

        UnaryOp128 IDynexus.EmitFixedUnary(BufferToken dst, W128 w, ApiCodeBlock src)
            => Emit(dst.Load(src.Encoded), src.Id, Unary, w);

        UnaryOp256 IDynexus.EmitFixedUnary(BufferToken dst, W256 w, ApiCodeBlock src)
            => Emit(dst.Load(src.Encoded), src.Id, Unary, w);

        BinaryOp8 IDynexus.EmitFixedBinary(BufferToken dst, W8 w, ApiCodeBlock src)
            => Emit(dst.Load(src.Encoded), src.Id, Binary, w);

        BinaryOp16 IDynexus.EmitFixedBinary(BufferToken dst, W16 w, ApiCodeBlock src)
            => Emit(dst.Load(src.Encoded), src.Id, Binary, w);

        BinaryOp32 IDynexus.EmitFixedBinary(BufferToken dst, W32 w, ApiCodeBlock src)
            => Emit(dst.Load(src.Encoded), src.Id, Binary, w);

        BinaryOp64 IDynexus.EmitFixedBinary(BufferToken dst, W64 w, ApiCodeBlock src)
            => Emit(dst.Load(src.Encoded), src.Id, Binary, w);

        BinaryOp128 IDynexus.EmitFixedBinary(BufferToken dst, W128 w, ApiCodeBlock src)
            => Emit(src.Id, Binary, w, dst.Load(src.Encoded));

        BinaryOp256 IDynexus.EmitFixedBinary(BufferToken dst, W256 w, ApiCodeBlock src)
            => Emit(src.Id, Binary, w, dst.Load(src.Encoded));

        UnaryOp<T> IDynexus.EmitUnaryOp<T>(BufferToken dst, ApiCodeBlock src)
            => EmitUnaryOp<T>(src.Id, dst.Load(src.Encoded));

        BinaryOp<T> IDynexus.EmitBinaryOp<T>(BufferToken dst, ApiCodeBlock src)
            => EmitBinaryOp<T>(src.Id, dst.Load(src.Encoded));

        TernaryOp<T> IDynexus.EmitTernaryOp<T>(BufferToken dst, ApiCodeBlock src)
            => EmitTernaryOp<T>(src.Id, dst.Load(src.Encoded));

        [MethodImpl(Inline)]
        UnaryOp8 Emit(OpIdentity id, U f, W8 w, BufferToken dst)
            => (UnaryOp8)Emit(id, f, typeof(UnaryOp8), typeof(Cell8), dst);

        [MethodImpl(Inline)]
        UnaryOp16 Emit(OpIdentity id, U f, W16 w, BufferToken dst)
            => (UnaryOp16)Emit(id, f, typeof(UnaryOp16), typeof(Cell16), dst);

        [MethodImpl(Inline)]
        UnaryOp32 Emit(OpIdentity id, U f, W32 w, BufferToken dst)
            => (UnaryOp32)Emit(id, f, typeof(UnaryOp32), typeof(Cell32), dst);

        [MethodImpl(Inline)]
        UnaryOp64 Emit(OpIdentity id, U f, W64 w, BufferToken dst)
            => (UnaryOp64)Emit(id, f, typeof(UnaryOp64), typeof(Cell64), dst);

        [MethodImpl(Inline)]
        UnaryOp128 Emit(BufferToken dst, OpIdentity id, U f, N128 w)
            => (UnaryOp128)Emit(id, f, typeof(UnaryOp128), typeof(Cell128), dst);

        [MethodImpl(Inline)]
        UnaryOp256 Emit(BufferToken dst, OpIdentity id, U f, N256 w)
            => (UnaryOp256)Emit(id, f, typeof(UnaryOp256), typeof(Cell256), dst);

        [MethodImpl(Inline)]
        BinaryOp8 Emit(BufferToken dst, OpIdentity id, B f, W8 w)
            => (BinaryOp8)Emit(id, f, typeof(BinaryOp8), typeof(Cell8), dst);

        [MethodImpl(Inline)]
        BinaryOp16 Emit(BufferToken dst, OpIdentity id, B f, W16 w)
            => (BinaryOp16)Emit(id, f, typeof(BinaryOp16), typeof(Cell16), dst);

        [MethodImpl(Inline)]
        BinaryOp32 Emit(BufferToken dst, OpIdentity id, B f, W32 w)
            => (BinaryOp32)Emit(id, f, typeof(BinaryOp32), typeof(Cell32), dst);

        [MethodImpl(Inline)]
        BinaryOp64 Emit(BufferToken dst, OpIdentity id, B f, W64 w)
            => (BinaryOp64)Emit(id, f, typeof(BinaryOp64), typeof(Cell64), dst);

        [MethodImpl(Inline)]
        BinaryOp128 Emit(OpIdentity id, B f, N128 w, BufferToken dst)
            => (BinaryOp128)Emit(id, f, typeof(BinaryOp128), typeof(Cell128), dst);

        [MethodImpl(Inline)]
        BinaryOp256 Emit(OpIdentity id, B f, N256 w, BufferToken dst)
            => (BinaryOp256)Emit(id, f, typeof(BinaryOp256), typeof(Cell256), dst);

        [MethodImpl(Inline)]
        CellDelegate Emit(OpIdentity id, U f, Type operatorType, Type operandType, BufferToken dst)
            => Emit(id, functype:operatorType, result:operandType,
                    args:core.array(operandType, operandType), dst.Handle);

        [MethodImpl(Inline)]
        CellDelegate Emit(OpIdentity id, B f, Type operatorType, Type operandType, BufferToken dst)
            => Emit(id, functype:operatorType, result:operandType,
                    args:core.array(operandType, operandType), dst.Handle);

        [MethodImpl(Inline)]
        UnaryOp<T> EmitUnaryOp<T>(OpIdentity id, BufferToken dst)
            where T : unmanaged
                => (UnaryOp<T>)EmitUnaryOp(id, typeof(UnaryOp<T>), typeof(T), dst);

        [MethodImpl(Inline)]
        BinaryOp<T> EmitBinaryOp<T>(OpIdentity id, BufferToken dst)
            where T : unmanaged
                => (BinaryOp<T>)EmitBinaryOp(id, typeof(BinaryOp<T>), typeof(T), dst);

        [MethodImpl(Inline)]
        TernaryOp<T> EmitTernaryOp<T>(OpIdentity id, BufferToken dst)
            where T : unmanaged
                => (TernaryOp<T>)EmitTernaryOp(id,typeof(TernaryOp<T>), typeof(T), dst);

        [MethodImpl(Inline)]
        CellDelegate EmitUnaryOp(OpIdentity id, Type operatorType, Type operandType, BufferToken dst)
            => Emit(id, functype: operatorType, result: operandType, args: core.array(operandType), dst.Handle);

        [MethodImpl(Inline)]
        CellDelegate EmitBinaryOp(OpIdentity id, Type operatorType, Type operandType, BufferToken dst)
            => Emit(id, functype:operatorType, result:operandType, args: core.array(operandType, operandType), dst.Handle);

        [MethodImpl(Inline)]
        CellDelegate EmitTernaryOp(OpIdentity id, Type operatorType, Type operandType, BufferToken dst)
            => Emit(id, functype:operatorType, result:operandType, args: core.array(operandType, operandType, operandType), dst.Handle);

        CellDelegate Emit(OpIdentity id, Type functype, Type result, Type[] args, IntPtr dst)
        {
            var method = new DynamicMethod(id, result, args, functype.Module);
            var g = method.GetILGenerator();
            switch(args.Length)
            {
                case 1:
                    g.Emit(OpCodes.Ldarg_0);
                break;
                case 2:
                    g.Emit(OpCodes.Ldarg_0);
                    g.Emit(OpCodes.Ldarg_1);
                break;
                case 3:
                    g.Emit(OpCodes.Ldarg_0);
                    g.Emit(OpCodes.Ldarg_1);
                    g.Emit(OpCodes.Ldarg_2);
                break;
                case 4:
                    g.Emit(OpCodes.Ldarg_0);
                    g.Emit(OpCodes.Ldarg_1);
                    g.Emit(OpCodes.Ldarg_2);
                    g.Emit(OpCodes.Ldarg_3);
                break;

            }
            g.Emit(OpCodes.Ldc_I8, (long)dst);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, result, args);
            g.Emit(OpCodes.Ret);
            return CellDelegates.define(id, dst, method, method.CreateDelegate(functype));
        }
    }
}