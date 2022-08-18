//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellDelegates
    {
        /// <summary>
        /// Creates a binary cell operator determined by a source delegate and specified cell width
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryOp8 unary<T>(W8 w, Func<T,T> f)
            where T : unmanaged
                => (Cell8 a) => Cells.cell8(f(a.As<T>()));

        /// <summary>
        /// Creates a binary cell operator determined by a source delegate and specified cell width
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryOp16 unary<T>(W16 w, Func<T,T> f)
            where T : unmanaged
                => (Cell16 a) => Cells.cell16(f(a.As<T>()));

        /// <summary>
        /// Creates a binary cell operator determined by a source delegate and specified cell width
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryOp32 unary<T>(W32 w, Func<T,T> f)
            where T : unmanaged
                => (Cell32 a) => Cells.cell32(f(a.As<T>()));

        /// <summary>
        /// Creates a binary cell operator determined by a source delegate and specified cell width
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryOp64 unary<T>(W64 w, Func<T,T> f)
            where T : unmanaged
                => (Cell64 a) => Cells.cell64(f(a.As<T>()));

        [MethodImpl(NotInline), Op]
        public static UnaryOp1 unary(UnaryOp<bit> f)
            => a => f(a);

        [MethodImpl(NotInline), Op]
        public static UnaryOp8 unary(UnaryOp<sbyte> f)
            => a => f((sbyte)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryOp8 unary(UnaryOp<byte> f)
            => a => f((byte)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryOp16 unary(UnaryOp<short> f)
            => a => f((short)a);

        [MethodImpl(NotInline), Op]
        public static UnaryOp16 unary(UnaryOp<ushort> f)
            => a => f((ushort)a);

        [MethodImpl(NotInline), Op]
        public static UnaryOp32 unary(UnaryOp<int> f)
            => a => f((int)a);

        [MethodImpl(NotInline), Op]
        public static UnaryOp32 unary(UnaryOp<uint> f)
            => a => f((uint)a);

        [MethodImpl(NotInline), Op]
        public static UnaryOp64 unary(UnaryOp<long> f)
            => a => f((long)a);

        [MethodImpl(NotInline), Op]
        public static UnaryOp64 unary(UnaryOp<ulong> f)
            => a => f(a);

        /// <summary>
        /// Creates a fixed 128-bit unary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryOp128 unary<T>(Func<Vector128<T>, Vector128<T>> f)
            where T : unmanaged
                => (Cell128 a) => f(a.ToVector<T>()).ToCell();

        /// <summary>
        /// Creates a fixed 256-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryOp256 unary<T>(Func<Vector256<T>,Vector256<T>> f)
            where T : unmanaged
                => (Cell256 a) => f(a.ToVector<T>()).ToCell();


        [MethodImpl(Inline), Op, Closures(Integers)]
        internal static UnaryOp<T> unary<T>(MethodInfo src, UnaryOperatorClass<T> k = default)
            where T : unmanaged
                => Delegates.unary<T>(src);

        [MethodImpl(NotInline), Op]
        public static UnaryOp1 unary(W1 w, MethodInfo f, UnaryOperatorClass<bit> k)
            => unary(unary<bit>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp8 unary(W8i w, MethodInfo f, UnaryOperatorClass<sbyte> k)
            => unary(unary<sbyte>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp8 unary(MethodInfo f, UnaryOperatorClass<byte> k)
            => unary(unary<byte>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp16 unary(MethodInfo f, UnaryOperatorClass<short> k)
            => unary(unary<short>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp16 unary(MethodInfo f, UnaryOperatorClass<ushort> k)
            => unary(unary<ushort>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp32 unary(MethodInfo f, UnaryOperatorClass<int> k)
            => unary(unary<int>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp32 unary(MethodInfo f, UnaryOperatorClass<uint> k)
            => unary(unary<uint>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp64 unary(MethodInfo f, UnaryOperatorClass<long> k )
            => unary(unary<long>(f, k));

        [MethodImpl(NotInline), Op]
        public static UnaryOp64 unary(MethodInfo f, UnaryOperatorClass<ulong> k)
            => unary(unary<ulong>(f, k));
    }
}