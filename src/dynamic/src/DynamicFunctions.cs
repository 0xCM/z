//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct DynamicFunctions
    {
        public static DynamicFunctions create(N1 n)
            => new DynamicFunctions(new UnaryFuncEmitter());

        public static DynamicFunctions create(N2 n)
            => new DynamicFunctions(new BinaryFuncEmitter());

        public static DynamicFunctions create(N3 n)
            => new DynamicFunctions(new TernaryFuncEmitter());

        readonly IMethodBodyEmitter BodyEmitter;

        public DynamicFunctions(IMethodBodyEmitter emitter)
            => BodyEmitter = emitter;

        public CellDelegate Emit(OpIdentity id, Type functype, Type result, Type[] args, MemoryAddress dst)
        {
            var method = new DynamicMethod(id, result, args, functype.Module);
            var g = BodyEmitter.Emit(method);
            g.Emit(OpCodes.Ldc_I8, (long)dst);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, result, args);
            g.Emit(OpCodes.Ret);
            return CellDelegates.define(id, dst, method, method.CreateDelegate(functype));
        }

        public CellDelegate Emit(OpIdentity id, Type functype, Type result, Type[] args, Span<byte> buffer)
        {
            var method = new DynamicMethod(id, result, args, functype.Module);
            var g = BodyEmitter.Emit(method);
            var address = core.address(buffer);
            g.Emit(OpCodes.Ldc_I8, (long)address);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, result, args);
            g.Emit(OpCodes.Ret);
            return CellDelegates.define(id, address, method, method.CreateDelegate(functype));
        }
    }

    readonly struct UnaryFuncEmitter : IMethodBodyEmitter
    {
        public ILGenerator Emit(DynamicMethod dst)
        {
            var g = dst.GetILGenerator();
            g.Emit(OpCodes.Ldarg_0);
            return g;
        }
    }

    readonly struct BinaryFuncEmitter : IMethodBodyEmitter
    {
        public ILGenerator Emit(DynamicMethod dst)
        {
            var g = dst.GetILGenerator();
            g.Emit(OpCodes.Ldarg_0);
            g.Emit(OpCodes.Ldarg_1);
            return g;
        }
    }

    readonly struct TernaryFuncEmitter : IMethodBodyEmitter
    {
        public ILGenerator Emit(DynamicMethod dst)
        {
            var g = dst.GetILGenerator();
            g.Emit(OpCodes.Ldarg_0);
            g.Emit(OpCodes.Ldarg_1);
            g.Emit(OpCodes.Ldarg_2);
            return g;
        }
    }
}