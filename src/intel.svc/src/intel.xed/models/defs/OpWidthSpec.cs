//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static MachineModes;

    partial class XedModels
    {
        public readonly struct OpWidthSpec
        {
            [MethodImpl(Inline)]
            public static OpWidthSpec spec(GprWidth gpr)
            {
                var w0 = (ushort)gpr[w16].Width;
                var w1 = (ushort)gpr[w32].Width;
                var w2 = (ushort)gpr[w64].Width;
                return new OpWidthSpec(0, MachineModeClass.Default, gpr, ElementType.Empty, 1);
            }

            public static OpWidthSpecs specs(Index<OpWidthDetail> src)
            {
                var count = src.Count*3;
                var dst = alloc<OpWidthSpec>(count);
                var k=0u;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var info = ref src[i];
                    seek(dst,k++) = new OpWidthSpec(info.Code, MachineModeClass.Mode16, info.Name, info.SegType, 1, info.ElementType, info.ElementWidth, info.Width16);
                    seek(dst,k++) = new OpWidthSpec(info.Code, MachineModeClass.Mode32, info.Name, info.SegType, 1, info.ElementType, info.ElementWidth, info.Width32);
                    seek(dst,k++) = new OpWidthSpec(info.Code, MachineModeClass.Mode64, info.Name, info.SegType, 1, info.ElementType, info.ElementWidth, info.Width64);
                }
                return new OpWidthSpecs(dst);
            }

            [MethodImpl(Inline)]
            OpWidthSpec(WidthCode code, MachineMode mode, asci16 name, BitSegType seg, ushort n, ElementType t, ushort cw, ushort bw)
            {
                Code = code;
                Mode = mode;
                Name = name;
                Seg = seg;
                Gpr = GprWidth.Empty;
                N = n;
                CellType = t;
                CellWidth = cw;
                Width = bw;
            }

            [MethodImpl(Inline)]
            OpWidthSpec(WidthCode code, MachineMode mode, GprWidth gpr, ElementType ct, ushort n)
            {
                Code = code;
                Gpr = gpr;
                CellType = ct;
                CellWidth = default;
                Seg = BitSegType.Empty;
                N = n;
                Width = default;
                Mode = default;
                Name = default;
            }

            public readonly WidthCode Code;

            public readonly GprWidth Gpr;

            public readonly asci16 Name;

            public readonly ElementType CellType;

            public readonly MachineMode Mode;

            public readonly BitSegType Seg;

            readonly ushort CellWidth;

            public readonly ushort N;

            public readonly ushort Width;

            public byte Count
            {
                [MethodImpl(Inline)]
                get => Gpr.IsEmpty ? (byte)1 : Gpr.Count;
            }

            public bool Invariant
            {
                [MethodImpl(Inline)]
                get => Gpr.IsInvariant;
            }

            public ushort W0
            {
                [MethodImpl(Inline)]
                get => Gpr.IsNonEmpty ? (ushort)Gpr[w16] : Width;
            }

            public ushort W1
            {
                [MethodImpl(Inline)]
                get => Gpr.IsNonEmpty ? (ushort)Gpr[w32] : Width;
            }

            public ushort W2
            {
                [MethodImpl(Inline)]
                get => Gpr.IsNonEmpty ?(ushort)Gpr[w64] : Width;
            }

            public ushort this[W16 w]
            {
                [MethodImpl(Inline)]
                get => W0;
            }

            public ushort this[W32 w]
            {
                [MethodImpl(Inline)]
                get => W1;
            }

            public ushort this[W64 w]
            {
                [MethodImpl(Inline)]
                get => W2;
            }

            public ushort OpBits
            {
                [MethodImpl(Inline)]
                get => (ushort)Width;
            }

            public static OpWidthSpec Empty => default;
        }
    }
}