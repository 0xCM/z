//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public unsafe readonly struct DFx
    {
        const NumericKind Closure = UnsignedInts;

        public readonly struct ActionSpec : IDFxSpec
        {
            public Identifier Name {get;}

            public SegRef Code {get;}

            public Action Operation {get;}

            [MethodImpl(Inline)]
            public ActionSpec(Identifier name, SegRef code, Action op)
            {
                Name = name;
                Code = code;
                Operation = op;
            }

            [MethodImpl(Inline)]
            public void Invoke()
                => Operation();

            public static ActionSpec Empty => default;
        }

        public struct UnaryOpSpec<T>
        {
            public Identifier Name;

            public SegRef Code;

            public UnaryOp<T> Operation;

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => Operation(a);

            public string Format(T a, T b)
            {
                const string Pattern = "{0}({1}) = {2}";
                return string.Format(Pattern, Name, a, b);
            }

            public OpExecInfo ExecInfo(T a, T b)
                => new OpExecInfo(Name, array<object>(a), b, Format(a,b));

            public static UnaryOpSpec<T> Empty => default;
        }

        public struct FuncSpec<A,B>
        {
            public Identifier Name;

            public SegRef Code;

            public Func<A,B> Operation;

            [MethodImpl(Inline)]
            public B Invoke(A a)
                => Operation(a);

            public string Format(A a, B b)
            {
                const string Pattern = "{0}({1}) = {2}";
                return string.Format(Pattern, Name, a, b);
            }

            public OpExecInfo ExecInfo(A a, B b)
                => new OpExecInfo(Name, array<object>(a), b, Format(a,b));

            public static FuncSpec<A,B> Empty => default;
        }

        public struct BinOpSpec<T>
        {
            public Identifier Name;

            public SegRef Code;

            public BinaryOp<T> Operation;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => Operation(a,b);

            public string Format(T a, T b, T c)
            {
                const string Pattern = "{0}({1},{2}) = {3}";
                return string.Format(Pattern, Name, a, b, c);
            }

            public OpExecInfo ExecInfo(T a, T b, T c)
                => new OpExecInfo(Name, array<object>(a,b), c, Format(a,b,c));

            public static BinOpSpec<T> Empty => default;
        }

        public struct FuncSpec<A,B,C>
        {
            public Identifier Name;

            public SegRef Code;

            public Func<A,B,C> Operation;

            [MethodImpl(Inline)]
            public FuncSpec(Identifier name, SegRef code, Func<A,B,C> op)
            {
                Name = name;
                Code = code;
                Operation = op;
            }

            [MethodImpl(Inline)]
            public C Invoke(A a, B b)
                => Operation(a,b);

            public string Format(A a, B b, C c)
            {
                const string Pattern = "{0}({1},{2}) = {3}";
                return string.Format(Pattern, Name, a, b, c);
            }

            public OpExecInfo ExecInfo(A a, B b, C c)
                => new OpExecInfo(Name, array<object>(a,b), c,  Format(a,b,c));

            public static FuncSpec<A,B,C> Empty => default;
        }

        public struct EmitterSpec<T>
        {
            public Identifier Name;

            public SegRef Code;

            public Producer<T> Operation;

            [MethodImpl(Inline)]
            public T Invoke()
                => Operation();

            public string Format(T a)
            {
                const string Pattern = "{0}() = {1}";
                return string.Format(Pattern, Name, a);
            }

            public OpExecInfo ExecInfo(T a)
                => new OpExecInfo(Name, sys.empty<object>(), a,  Format(a));
        }


        [Op, Closures(Closure)]
        public static UnaryOpSpec<T> unaryop<T>(Identifier name, SegRef dst)
        {
            var spec = new UnaryOpSpec<T>();
            spec.Name = name;
            spec.Code = dst;
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(UnaryOp<T>);
            spec.Operation = (UnaryOp<T>)emit(name, functype:tOperator, result:tResult, args: array(tOperand), dst.Address);
            return spec;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinOpSpec<T> binop<T>(Identifier name, SegRef dst)
        {
            var spec = new BinOpSpec<T>();
            spec.Name = name;
            spec.Code = dst;
            spec.Operation = (BinaryOp<T>)emit(name, functype:typeof(BinaryOp<T>), result:typeof(T), args: array(typeof(T), typeof(T)), dst.Address);
            return spec;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static EmitterSpec<T> emitter<T>(Identifier name, SegRef dst)
        {
            var spec = new EmitterSpec<T>();
            spec.Name = name;
            spec.Code = dst;
            spec.Operation = (Producer<T>)emit(name, functype:typeof(Producer<T>), result:typeof(T), args: sys.empty<Type>(), dst.Address);
            return spec;
        }

        [Op]
        public static ActionSpec action(Identifier name, SegRef dst)
            => new ActionSpec(name, dst, (Action)emit(name, functype:typeof(Action), result:typeof(void), args: sys.empty<Type>(), dst.Address));

        public static FuncSpec<A,B> func<A,B>(Identifier name, SegRef dst, out FuncSpec<A,B> spec)
        {
            spec.Name = name;
            spec.Code = dst;
            spec.Operation = (Func<A,B>)emit(name, functype:typeof(Func<A,B>), result:typeof(B), args: array(typeof(A)), dst.Address);
            return spec;
        }

        public static FuncSpec<A,B,C> func<A,B,C>(Identifier name, SegRef dst, out FuncSpec<A,B,C> spec)
        {
            spec.Name = name;
            spec.Code = dst;
            spec.Operation = (Func<A,B,C>)emit(name, functype:typeof(Func<A,B,C>), result:typeof(C), args: array(typeof(A), typeof(B)), dst.Address);
            return spec;
        }

        [Op, Closures(Closure)]
        public static unsafe Producer<T> emitter<T>(Identifier name, byte* pCode)
            => emitter<T>(name, (MemoryAddress)pCode, out _);

        [Op, Closures(Closure)]
        public static unsafe Producer<T> emitter<T>(Identifier name, ReadOnlySpan<byte> code)
            => emitter<T>(name.Format(), memory.liberate(code), out _);

        public static unsafe Producer<T> emitter<T>(Identifier name, MemoryAddress address, out DynamicMethod method)
        {
            var tFunc = typeof(Producer<T>);
            var tReturn = typeof(T);
            method = new DynamicMethod(name, tReturn, null, typeof(int).Module);
            var g = method.GetILGenerator();
            g.Emit(OpCodes.Ldc_I8, (long)address);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, tReturn, null);
            g.Emit(OpCodes.Ret);
            return (Producer<T>)CellDelegate.define(name, address, method, method.CreateDelegate(tFunc));
        }

        public static unsafe DynamicAction action(Identifier name, ReadOnlySpan<byte> f)
            => action(name, memory.liberate(f));

        public static unsafe DynamicAction action(Identifier name, MemoryAddress f)
        {
            var tFunc = typeof(Action);
            var method = new DynamicMethod(name, null, null, tFunc.Module);
            var g = method.GetILGenerator();
            g.Emit(OpCodes.Ldc_I8, f);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, null, null);
            g.Emit(OpCodes.Ret);
            return new DynamicAction(name, f, method, (Action)method.CreateDelegate(tFunc));
        }

        [MethodImpl(Inline), Op]
        public static SegRef load(ReadOnlySpan<byte> src, uint offset, in NativeBuffer dst)
        {
            var i0 = offset;
            ref var target = ref seek(dst.Edit, offset);
            var location = address(target);
            for(var i=0; i<src.Length; i++)
                seek(target, offset++) = skip(src,i);
            return (location, offset - i0);
        }

        public static Func<T0,R> emit<T0,R>(ApiCodeBlock src, Span<byte> buffer, out Func<T0,R> fx)
        {
            fx = (Func<T0,R>)DynamicFunctions.create(n1).Emit(src.OpUri.OpId, functype:typeof(Func<T0,R>), result:typeof(R), args: array(typeof(T0)), buffer);
            return fx;
        }

        public static void emit<T>(N1 n, ApiCodeBlock code, MemoryAddress dst, out UnaryOp<T> fx)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(UnaryOp<T>);
            var builder = DynamicFunctions.create(n);
            fx = (UnaryOp<T>)builder.Emit(code.OpUri.OpId, functype:tOperator, result:tResult, args: array(tOperand), dst);
        }

        public static void emit<T>(N2 n, ApiCodeBlock code, MemoryAddress dst, out BinaryOp<T> fx)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(BinaryOp<T>);
            var builder = DynamicFunctions.create(n);
            fx = (BinaryOp<T>)builder.Emit(code.OpUri.OpId, functype:tOperator, result:tResult, args: array(tOperand), dst);
        }

        public static void emit<T>(N3 n, ApiCodeBlock code, MemoryAddress dst, out TernaryOp<T> fx)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(TernaryOp<T>);
            var builder = DynamicFunctions.create(n);
            fx = (TernaryOp<T>)builder.Emit(code.OpUri.OpId, functype:tOperator, result:tResult, args: array(tOperand), dst);
        }

        public static UnaryOp<T> unaryop<T>(BufferToken dst, ApiCodeBlock src)
            where T : unmanaged
        {
            try
            {
                return unaryop<T>(src.Id.Format(), dst.Load(src.Encoded));
            }
            catch(Exception e)
            {
                term.magenta($"Operator production for {src.Id} failed");
                term.magenta(src);
                term.error(e);
                return empty;
            }
        }

        [MethodImpl(Inline)]
        public static BinaryOp<T> binaryop<T>(BufferToken dst, ApiCodeBlock src)
            where T : unmanaged
        {
            try
            {
                return binaryop<T>(src.Id.Format(), dst.Load(src.Encoded));
            }
            catch(Exception e)
            {
                term.magenta($"Operator production for {src.Id} failed");
                term.magenta(src);
                term.error(e);
                return empty;
            }
        }

        public static void emit<T0,T1,R>(MethodInfo src, bool calli, out Func<T0,T1,R> fx)
        {
            var args = new Type[]{typeof(T0), typeof(T1)};
            var returnType = typeof(R);
            var method = new DynamicMethod(src.Name, returnType, args, src.Module);
            var g = method.GetILGenerator();
            if(calli)
            {
                g.Emit(OpCodes.Ldarg_0);
                g.Emit(OpCodes.Ldarg_1);
                g.EmitCall(OpCodes.Call, src, null);
                g.Emit(OpCodes.Ret);
            }
            else
            {
                g.Emit(OpCodes.Ldarg_0);
                g.Emit(OpCodes.Ldarg_1);
                g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, returnType, args);
                g.Emit(OpCodes.Ret);
            }

            fx = (Func<T0,T1,R>)method.CreateDelegate(typeof(Func<T0,T1,R>));
        }

        [MethodImpl(Inline)]
        static BinaryOp<T> binaryop<T>(Identifier name, BufferToken dst)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(BinaryOp<T>);
            return (BinaryOp<T>)emit(name, functype:tOperator, result:tResult, args: array(tOperand,tOperand), dst.Address);
        }

        [MethodImpl(Inline)]
        static UnaryOp<T> unaryop<T>(Identifier name, BufferToken dst)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(UnaryOp<T>);
            return (UnaryOp<T>)emit(name, functype:tOperator, result:tResult, args: array(tOperand), dst.Address);
        }

        internal static CellDelegate emit(Identifier name, Type functype, Type result, Type[] args, MemoryAddress dst)
        {
            var method = new DynamicMethod(name, result, args, functype.Module);
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
            return CellDelegates.define(name, dst, method, method.CreateDelegate(functype));
        }

        static T empty<T>(T src)
            where T : unmanaged
                => default;

        static T empty<T>(T x, T y)
            where T : unmanaged
                => default;
    }
}