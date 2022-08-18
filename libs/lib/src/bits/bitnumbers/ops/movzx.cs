//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using T = Z0;

    partial struct BitNumbers
    {
        /// <summary>
        /// Zero-extends a <see cref='bit'/> to a <see cref='T.uint3'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint3 movzx(bit src, W3 w)
            => new uint3((byte)src, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint1'/> to a <see cref='T.uint2'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint2 movzx(uint1 src, W2 w)
            => new uint2(src.Value, true);

        /// <summary>
        /// Promotes a <see cref='T.uint1'/> to a <see cref='T.uint3'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint3 movzx(uint1 src, W3 w)
            => new uint3(src.Value, true);

        /// <summary>
        /// Promotes a <see cref='T.uint1'/> to a <see cref='T.uint5'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint4 movzx(uint1 src, W4 w)
            => new uint4(src.Value, true);

        /// <summary>
        /// Promotes a <see cref='T.uint1'/> to a <see cref='T.uint5'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint5 movzx(uint1 src, W5 w)
            => new uint5(src.Value, true);

        /// <summary>
        /// Promotes a <see cref='T.uint1'/> to a <see cref='T.uint6'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint6 movzx(uint1 src, W6 w)
            => new uint6(src.Value, true);

        /// <summary>
        /// Promotes a <see cref='T.uint1'/> to a <see cref='T.uint7'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint7 movzx(uint1 src, W7 w)
            => new uint7(src.Value, true);

        /// <summary>
        /// Promotes a <see cref='T.uint1'/> to a <see cref='T.uint8b'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint8b movzx(uint1 src, W8 w)
            => new uint8b(src.Value);

        /// <summary>
        /// Promotes a <see cref='U'/> to a <see cref='T.uint3'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint3 movzx(uint2 src, W3 w)
            => new uint3(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint2'/> to a <see cref='T.uint4'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint4 movzx(uint2 src, W4 w )
            => new uint4(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint2'/> to a <see cref='T.uint5'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint5 movzx(uint2 src, W5 w)
            => new uint5(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint2'/> to a <see cref='T.uint6'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint6 movzx(uint2 src, W6 w)
            => new uint6(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint2'/> to a <see cref='T.uint7'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint7 movzx(uint2 src, W7 w)
            => new uint7(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint2'/> to a <see cref='T.uint8b'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint8b movzx(uint2 src, W8 w)
            => new uint8b(src.Value);

        /// <summary>
        /// Zero-extends a <see cref='T.uint3'/> to a <see cref='T.uint4'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint4 movzx(uint3 src, W4 w)
            => new uint4(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint3'/> to a <see cref='T.uint5'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint5 movzx(uint3 src, W5 w)
            => new uint5(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint3'/> to a <see cref='T.uint6'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint6 movzx(uint3 src, W6 w)
            => new uint6(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint3'/> to a <see cref='T.uint7'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint7 movzx(uint3 src, W7 w)
            => new uint7(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint3'/> to a <see cref='T.uint8b'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint8b movzx(uint3 src, W8 w)
            => new uint8b(src.Value);

        /// <summary>
        /// Zero-extends a <see cref='T.uint4'/> to a <see cref='T.uint5'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint5 movzx(uint4 src, W5 w)
            => new uint5(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint4'/> to a <see cref='T.uint6'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint6 movzx(uint4 src, W6 w)
            => new uint6(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint4'/> to a <see cref='T.uint7'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint7 movzx(uint4 src, W7 w)
            => new uint7(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint4'/> to a <see cref='T.uint8b'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint8b movzx(uint4 src, W8 w)
            => new uint8b(src.Value);

        /// <summary>
        /// Zero-extends a <see cref='T.uint5'/> to a <see cref='T.uint8b'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint8b movzx(uint5 src, W8 w)
            => new uint8b(src.Value);

        /// <summary>
        /// Zero-extends a <see cref='T.uint5'/> to a <see cref='T.uint6'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint6 movzx(uint5 src, W6 w)
            => new uint6(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint5'/> to a <see cref='T.uint7'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint7 movzx(uint5 src, W7 w )
            => new uint7(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint6'/> to a <see cref='T.uint7'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint7 movxz(uint6 src, W7 w)
            => new uint7(src.Value, true);

        /// <summary>
        /// Zero-extends a <see cref='T.uint6'/> to a <see cref='T.uint8b'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint8b movxz(uint6 src, W8 w)
            => new uint8b(src.Value);

        /// <summary>
        /// Zero-extends a <see cref='T.uint7'/> to a <see cref='T.uint8b'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint8b movzx(uint7 src, W8 w)
            => new uint8b(src.Value);
    }
}