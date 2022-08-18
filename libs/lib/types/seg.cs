//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NativeSegKind;

    partial class NativeTypes
    {
        public static byte nonempty(in NativeTypeSeq src)
        {
            var count = z8;
            for(var i=0; i<src.MaxCount; i++)
            {
                ref readonly var type = ref src[i];
                if(type.IsVoid)
                    break;
                count++;
            }
            return count;
        }

        [MethodImpl(Inline)]
        public static NativeType seg(NativeScalar cellType, byte cellCount)
            => new NativeType(NativeSizes.seg(cellType, cellCount));

        [MethodImpl(Inline), Op]
        public static NativeType seg(NativeSegKind kind)
            => new NativeType(kind);

        [MethodImpl(Inline), Op]
        public static NativeType seg16(NativeScalar cell)
            => seg(cell, (byte)(16/cell.Width));

        [MethodImpl(Inline), Op]
        public static NativeType seg32(NativeScalar cell)
            => seg(cell, (byte)(32/cell.Width));

        [MethodImpl(Inline), Op]
        public static NativeType seg64(NativeScalar cell)
            => seg(cell, (byte)(64/cell.Width));

        [MethodImpl(Inline), Op]
        public static NativeType seg128(NativeScalar cell)
            => seg(cell, (byte)(128/cell.Width));

        [MethodImpl(Inline), Op]
        public static NativeType seg256(NativeScalar cell)
            => seg(cell, (byte)(256/cell.Width));

        [MethodImpl(Inline), Op]
        public static NativeType seg512(NativeScalar cell)
            => seg(cell, (byte)(256/cell.Width));

        [MethodImpl(Inline), Op]
        public static NativeType seg16x8u()
            => Seg16x8u;

        [MethodImpl(Inline), Op]
        public static NativeType seg16x8i()
            => Seg16x8i;

        [MethodImpl(Inline), Op]
        public static NativeType seg32x8u()
            => Seg32x8u;

        [MethodImpl(Inline), Op]
        public static NativeType seg32x8i()
            => Seg32x8i;

        [MethodImpl(Inline), Op]
        public static NativeType seg32x16u()
            => Seg32x16u;

        [MethodImpl(Inline), Op]
        public static NativeType seg32x16i()
            => Seg32x16i;

        [MethodImpl(Inline), Op]
        public static NativeType seg64x8u()
            => Seg64x8u;

        [MethodImpl(Inline), Op]
        public static NativeType seg64x8i()
            => Seg64x8i;

        [MethodImpl(Inline), Op]
        public static NativeType seg64x16u()
            => Seg64x16u;

        [MethodImpl(Inline), Op]
        public static NativeType seg64x32u()
            => Seg64x32u;

        [MethodImpl(Inline), Op]
        public static NativeType seg64x32i()
            => Seg64x32i;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x8u()
            => Seg128x8u;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x8i()
            => Seg128x8i;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x16u()
            => Seg128x16u;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x16i()
            => Seg128x16i;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x32u()
            => Seg128x32u;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x32i()
            => Seg128x32i;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x64u()
            => Seg128x64u;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x64i()
            => Seg128x64i;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x16f()
            => Seg128x16f;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x32f()
            => Seg128x32f;

        [MethodImpl(Inline), Op]
        public static NativeType seg128x64f()
            => Seg128x64f;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x8u()
            => Seg256x8u;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x8i()
            => Seg256x8i;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x16u()
            => Seg256x16u;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x16i()
            => Seg256x16i;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x32u()
            => Seg256x32u;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x32i()
            => Seg256x32i;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x64u()
            => Seg256x64u;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x64i()
            => Seg256x64i;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x16f()
            => Seg256x16f;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x32f()
            => Seg256x32f;

        [MethodImpl(Inline), Op]
        public static NativeType seg256x64f()
            => Seg256x64f;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x8u()
            => Seg512x8u;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x8i()
            => Seg512x8i;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x16u()
            => Seg512x16u;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x16i()
            => Seg512x16i;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x32u()
            => Seg512x32u;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x32i()
            => Seg512x32i;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x64u()
            => Seg512x64u;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x64i()
            => Seg512x64i;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x16f()
            => Seg512x16f;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x32f()
            => Seg512x32f;

        [MethodImpl(Inline), Op]
        public static NativeType seg512x64f()
            => Seg512x64f;
    }
}