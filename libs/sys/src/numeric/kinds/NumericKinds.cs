//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using NK = NumericKind;

    [ApiHost]
    public partial class NumericKinds
    {
        /// <summary>
        /// Recognized unsigned integral types
        /// </summary>
        [Op]
        public static Type[] UnsignedTypes()
            => new Type[]{typeof(byte), typeof(ushort),  typeof(uint), typeof(ulong)};

        /// <summary>
        /// Recognized unsigned integral kinds
        /// </summary>
        [Op]
        public static NK[] UnsignedKinds()
            => new NK[]{NK.U8, NK.U16, NK.U32, NK.U64};

         /// <summary>
        /// Recognized signed integral kinds
        /// </summary>
        [Op]
        public static Type[] SignedTypes()
            => new Type[]{typeof(sbyte), typeof(short), typeof(int), typeof(long)};

        /// <summary>
        /// Recognized signed integral kinds
        /// </summary>
        [Op]
        public static NK[] SignedKinds()
            => new NK[]{NK.I8, NK.I16, NK.I32, NK.I64};

        /// <summary>
        /// recognized floating-point types
        /// </summary>
        [Op]
        public static Type[] FloatingTypes()
            => new Type[]{typeof(float), typeof(double)};

        /// <summary>
        /// Recognized floating-point kinds
        /// </summary>
        [Op]
        public static NK[] FloatingKinds()
           => new NK[]{NK.F32, NK.F64};

        /// <summary>
        /// Recognized integral types
        /// </summary>
        [Op]
        public static Type[] IntegerTypes()
            => SignedTypes().Union(UnsignedTypes()).Array();

        /// <summary>
        /// Recognized integral kinds
        /// </summary>
        [Op]
        public static NK[] IntegralKindSeq()
            => UnsignedKinds().Union(SignedKinds()).ToArray();

        /// <summary>
        /// Recognized numeric types
        /// </summary>
        [Op]
        public static Type[] NumericTypes()
            => IntegerTypes().Union(FloatingTypes()).ToArray();
    }
}