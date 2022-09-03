//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class TypeNats
    {
        /// <summary>
        /// Creates a reflected natural sequence from a sequence of primitive values
        /// </summary>
        /// <param name="digits">The source digits</param>
        public static INatSeq seq(byte[] digits)
        {
            var dtypes = primtypes(digits);
            var nattype = seqtype((uint)dtypes.Length).MakeGenericType(dtypes);
            return (INatSeq)Activator.CreateInstance(nattype);
        }

        /// <summary>
        /// Creates a two-term natural sequence {D0, D1} from primitive natural types D0 and D1 that represents the value k = d0*10 + d1
        /// </summary>
        /// <param name="d0">The primal representative of the leading term</param>
        /// <param name="d1">The primal representative of the second term</param>
        /// <typeparam name="D0">The primitive type of the leading term</typeparam>
        /// <typeparam name="D1">The primitive type of the second term</typeparam>
        [MethodImpl(Inline)]
        public static NatSeq<D0,D1> seq<D0,D1>(D0 d0 = default, D1 d1 = default)
            where D0 : unmanaged, INatPrimitive<D0>
            where D1 : unmanaged, INatPrimitive<D1>
                => NatSeq<D0,D1>.Rep;

        /// <summary>
        /// Creates a three-term natural sequence {D0, D1, D2} from natural primitive types D0, D1, D2
        /// that represents the value k = d0*10^2 + d1*10^1 + d2
        /// </summary>
        /// <param name="d0">The primal representative of the leading term</param>
        /// <param name="d1">The primal representative of the second term</param>
        /// <param name="d2">The primal representative of the third term</param>
        /// <typeparam name="D0">The primitive type of the leading term</typeparam>
        /// <typeparam name="D1">The primitive type of the second term</typeparam>
        /// <typeparam name="D2">The primitive type of the third term</typeparam>
        [MethodImpl(Inline)]
        public static NatSeq<D0,D1,D2> seq<D0,D1,D2>(D0 d0 = default, D1 d1 = default, D2 d2 = default)
            where D0 : unmanaged, INatPrimitive<D0>
            where D1 : unmanaged, INatPrimitive<D1>
            where D2 : unmanaged, INatPrimitive<D2>
                => NatSeq<D0,D1,D2>.Rep;

        /// <summary>
        /// Creates a four-term natural sequence {D0, D1, D2, D3} from natural primitive types D0, D1, D2, D3
        /// that represents the value k = d0*10^3 + d1*10^2 + d2*10 + d3
        /// </summary>
        /// <param name="d0">The primal representative of the leading term</param>
        /// <param name="d1">The primal representative of the second term</param>
        /// <param name="d2">The primal representative of the third term</param>
        /// <param name="d3">The primal representative of the fourth term</param>
        /// <typeparam name="D0">The primitive type of the leading term</typeparam>
        /// <typeparam name="D1">The primitive type of the second term</typeparam>
        /// <typeparam name="D2">The primitive type of the third term</typeparam>
        /// <typeparam name="D3">The primitive type of the fourth term</typeparam>
        [MethodImpl(Inline)]
        public static NatSeq<D0,D1,D2,D3> seq<D0,D1,D2,D3>(D0 d0 = default, D1 d1 = default, D2 d2 = default, D3 d3 = default)
            where D0 : unmanaged, INatPrimitive<D0>
            where D1 : unmanaged, INatPrimitive<D1>
            where D2 : unmanaged, INatPrimitive<D2>
            where D3 : unmanaged, INatPrimitive<D3>
                => NatSeq<D0,D1,D2,D3>.Rep;

        /// <summary>
        /// Creates a five-term natural sequence {D0, D1, D2, D3, D4} from natural primitive types D0, D1, D2, D3, D4
        /// that represents the value k = d0*10^4 + d1*10^3 + d2*10^2 + d3*10 + d4
        /// </summary>
        /// <param name="d0">The primal representative of the leading term</param>
        /// <param name="d1">The primal representative of the second term</param>
        /// <param name="d2">The primal representative of the third term</param>
        /// <param name="d3">The primal representative of the fourth term</param>
        /// <param name="d4">The primal representative of the fifth term</param>
        /// <typeparam name="D0">The primitive type of the leading term</typeparam>
        /// <typeparam name="D1">The primitive type of the second term</typeparam>
        /// <typeparam name="D2">The primitive type of the third term</typeparam>
        /// <typeparam name="D3">The primitive type of the fourth term</typeparam>
        /// <typeparam name="D4">The primitive type of the fifth term</typeparam>
        [MethodImpl(Inline)]
        public static NatSeq<D0,D1,D2,D3,D4> seq<D0,D1,D2,D3,D4>(D0 d0 = default, D1 d1 = default, D2 d2 = default, D3 d3 = default, D4 d4 = default)
            where D0 : unmanaged, INatPrimitive<D0>
            where D1 : unmanaged, INatPrimitive<D1>
            where D2 : unmanaged, INatPrimitive<D2>
            where D3 : unmanaged, INatPrimitive<D3>
            where D4 : unmanaged, INatPrimitive<D4>
                => NatSeq<D0,D1,D2,D3,D4>.Rep;

        /// <summary>
        /// Creates a reflected two-term natural sequence {d0, d1} from three primitive values d0 and d1
        /// </summary>
        /// <param name="d0">The value of the leading term</param>
        /// <param name="d1">The value of the second term</param>
        [MethodImpl(Inline)]
        public static INatSeq seq(byte d0, byte d1)
            => (INatSeq) Activator.CreateInstance(close(seqtype(2), primtype(d0), primtype(d1)));

        /// <summary>
        /// Creates a reflected three-term natural sequence {d0, d1, d2} from three primitive values d0, d1, d2
        /// </summary>
        /// <param name="d0">The value of the leading term</param>
        /// <param name="d1">The value of the second term</param>
        /// <param name="d2">The value of the third term</param>
        [MethodImpl(Inline)]
        public static INatSeq seq(byte d0, byte d1, byte d2)
            => (INatSeq) Activator.CreateInstance(close(seqtype(3), primtype(d0), primtype(d1), primtype(d2)));

        /// <summary>
        /// Creates a reflected four-term natural sequence from three primitive values
        /// </summary>
        /// <param name="d0">The value of the leading term</param>
        /// <param name="d1">The value of the second term</param>
        /// <param name="d2">The value of the third term</param>
        /// <param name="d3">The value of the fourth term</param>
        [MethodImpl(Inline)]
        public static INatSeq seq(byte d0, byte d1, byte d2, byte d3)
            => (INatSeq) Activator.CreateInstance(close(seqtype(4), primtype(d0), primtype(d1), primtype(d2), primtype(d3)));

        [MethodImpl(Inline)]
        static Type close(Type t, params Type[] args)
            => t.MakeGenericType(args);
    }
}