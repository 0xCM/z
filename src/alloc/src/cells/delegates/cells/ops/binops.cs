//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Cells;

    partial class CellDelegates
    {
        /// <summary>
        /// Creates a fixed 16-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp8 binop<T>(Func<T,T,T> f, W8 dst)
            where T : unmanaged
                => (Cell8 a, Cell8 b) => cell8(f(a.As<T>(),b.As<T>()));

        /// <summary>
        /// Creates a fixed 16-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp16 binop<T>(Func<T,T,T> f, W16 dst)
            where T : unmanaged
                => (Cell16 a, Cell16 b) => cell16(f(a.As<T>(),b.As<T>()));

        /// <summary>
        /// Creates a fixed 32-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp32 binop<T>(Func<T,T,T> f, W32 dst)
            where T : unmanaged
                => (Cell32 a, Cell32 b) => cell32(f(a.As<T>(),b.As<T>()));

        /// <summary>
        /// Creates a fixed 64-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp64 binop<T>(Func<T,T,T> f, W64 dst)
            where T : unmanaged
                => (Cell64 a, Cell64 b) => cell64(f(sys.@as<T>(a), sys.@as<T>(b)));

        [MethodImpl(NotInline), Op]
        public static BinaryOp1 binop(BinaryOp<bit> f)
            => (a,b) => f(a,b);

        [MethodImpl(NotInline), Op]
        public static BinaryOp8 binop(BinaryOp<sbyte> f)
            => (a, b) => f((sbyte)a, (sbyte)b);

        [MethodImpl(NotInline), Op]
        public static BinaryOp8 binop(BinaryOp<byte> f)
            => (a, b) => f(a, b);

        [MethodImpl(NotInline), Op]
        public static BinaryOp16 binop(BinaryOp<short> f)
            => (a, b) => f((short)a.Content, (short)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp16 binop(BinaryOp<ushort> f)
            => (a, b) => f(a.Content, b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp32 binop(BinaryOp<int> f)
            => (a, b) => f((int)a, (int)b);

        [MethodImpl(NotInline), Op]
        public static BinaryOp32 binop(BinaryOp<uint> f)
            => (a, b)  => f(a, b);

        [MethodImpl(NotInline), Op]
        public static BinaryOp64 binop(BinaryOp<long> f)
            => (a, b)  => f((long)a, (long)b);

        [MethodImpl(NotInline), Op]
        public static BinaryOp64 binop(BinaryOp<ulong> f)
            => (a, b)  => f(a, b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp128 binop<T>(Func<Vector128<T>,Vector128<T>,Vector128<T>> f)
            where T : unmanaged
                => (Cell128 a, Cell128 b) => f(a.ToVector<T>(), b.ToVector<T>()).ToCell();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp256 binop<T>(Func<Vector256<T>,Vector256<T>,Vector256<T>> f)
            where T : unmanaged
                => (Cell256 a, Cell256 b) => f(a.ToVector<T>(), b.ToVector<T>()).ToCell();

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static BinaryOp<T> binop<T>(MethodInfo src)
            where T : unmanaged
                => Delegates.binop<T>(src);

        [MethodImpl(Inline), Op]
        public static BinaryOp1 binop(W1 w, MethodInfo f)
            => binop(binop<bit>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp8 binop(W8i w, MethodInfo f)
            => binop(binop<sbyte>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp8 binop(W8 w, MethodInfo f)
            => binop(binop<byte>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp16 binop(W16i w, MethodInfo f)
            => binop(binop<short>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp16 binop(W16 w, MethodInfo f)
            => binop(binop<ushort>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp32 binop(W32 w, MethodInfo f)
            => binop(binop<uint>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp32 binop(W32i w, MethodInfo f)
            => binop(binop<int>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp64 binop(W64 w, MethodInfo f)
            => binop(binop<ulong>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp64 binop(W64i w, MethodInfo f)
            => binop(binop<long>(f));
    }
}