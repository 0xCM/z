//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = CpuCellWidth;

    partial class Widths
    {
        [MethodImpl(Inline)]
        public static CpuCellWidth cell<W>(W w = default)
            where W : struct, ICellWidth
                => cell_u<W>();

        [MethodImpl(Inline)]
        static CpuCellWidth cell_u<W>(W w = default)
            where W : struct, ICellWidth
        {
            if(typeof(W) == typeof(W8))
                return K.W8;
            if(typeof(W) == typeof(W16))
                return K.W16;
            else if(typeof(W) == typeof(W32))
                return K.W32;
            else if(typeof(W) == typeof(W64))
                return K.W64;
            else if(typeof(W) == typeof(W128))
                return K.W128;
            else if(typeof(W) == typeof(W256))
                return K.W256;
            else if(typeof(W) == typeof(W512))
                return K.W512;
            else
                return cell_i<W>();
        }

        [MethodImpl(Inline)]
        static CpuCellWidth cell_i<W>()
            where W : struct, ICellWidth
        {
            if(typeof(W) == typeof(W8i))
                return K.W8;
            if(typeof(W) == typeof(W16i))
                return K.W16;
            else if(typeof(W) == typeof(W32i))
                return K.W32;
            else if(typeof(W) == typeof(W64i))
                return K.W64;
            else if(typeof(W) == typeof(W128i))
                return K.W128;
            else if(typeof(W) == typeof(W256i))
                return K.W256;
            else if(typeof(W) == typeof(W512i))
                return K.W512;
            else
                return 0;
        }

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W8 w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W16 w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W32 w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W64 w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W128 w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W256 w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W512 w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W8i w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W16i w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W32i w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W64i w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W128i w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W256i w)
            => cell_u(w);

        [MethodImpl(Inline), Op]
        public static CpuCellWidth cell(W512i w)
            => cell_u(w);
    }
}