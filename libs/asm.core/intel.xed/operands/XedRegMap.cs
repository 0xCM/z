//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using static XedModels;

    public sealed class XedRegMap
    {
        public static RegOp map(XedRegId src)
            => Instance.Map(src);

        public static bool map(XedRegId src, out RegOp dst)
            => Instance.Map(src, out dst);

        public static XedRegId map(RegKind src)
            => Instance.Map(src);

        public static bool map(RegKind src, out XedRegId dst)
            => Instance.Map(src, out dst);

        public static XedRegMap Service => Instance;

        static Dictionary<RegKind,XedRegId> RX = new Pairings<RegKind, XedRegId>(new Paired<RegKind,XedRegId>[]{
            (RegKind.MM0,XedRegId.MMX0),
            (RegKind.MM1,XedRegId.MMX1),
            (RegKind.MM2,XedRegId.MMX2),
            (RegKind.MM3,XedRegId.MMX3),
            (RegKind.MM4,XedRegId.MMX4),
            (RegKind.MM5,XedRegId.MMX5),
            (RegKind.MM6,XedRegId.MMX6),
            (RegKind.MM7,XedRegId.MMX7),
        }).Storage.ToDictionary();

        static Dictionary<XedRegId,RegKind> XR = core.map(RX, x => paired(x.Value, x.Key)).ToDictionary();

        static XedRegMap create()
        {
            var xsyms = Symbols.index<XedRegId>().View;
            var rlu = dict<XedRegId,RegOp>();

            var rsyms = Symbols.index<RegKind>();
            var xlu = dict<RegKind,XedRegId>();

            var rkinds = rsyms.View.Map(x => (x.Expr.Format(), x.Kind)).ToDictionary();
            foreach(var xedreg in xsyms)
            {
                var name = xedreg.Expr.Format().ToLower();
                if(rkinds.TryGetValue(name, out var kind))
                {
                    rlu[xedreg.Kind] = kind;
                    xlu[kind] = xedreg;
                }
                else
                {
                    if(XR.TryGetValue(xedreg, out var rk))
                    {
                        rlu[xedreg.Kind] = rk;
                        xlu[rk] = xedreg;
                    }
                }
            }

            return new XedRegMap(rlu,xlu);
        }

        static RegMapEntry entry(XedRegId src, RegOp reg)
        {
            var dst = default(RegMapEntry);
            dst.XedRegId = (ushort)src;
            dst.RegClass = reg.RegClass;
            dst.RegSize = reg.Size;
            dst.RegName = reg.Name;
            dst.RegIndex = (byte)reg.Index;
            return dst;
        }

        ConstLookup<XedRegId,RegOp> RLU;

        ConstLookup<RegKind,XedRegId> XLU;

        Index<RegMapEntry> RLUData;

        Index<RegMapEntry> XLUData;

        internal XedRegMap(ConstLookup<XedRegId,RegOp> rlu, ConstLookup<RegKind,XedRegId> xlu)
        {
            RLU = rlu;
            XLU = xlu;
            RLUData = core.map(rlu.Entries, x => entry(x.Key, x.Value));
            XLUData = core.map(xlu.Entries, x => entry(x.Value, x.Key));
        }

        public RegOp Map(XedRegId src)
        {
            if(RLU.Find(src, out var reg))
                return reg;
            else
                return RegOp.Empty;
        }

        public XedRegId Map(RegKind src)
        {
            if(XLU.Find(src, out var reg))
                return reg;
            else
                return XedRegId.INVALID;
        }

        public bool Map(XedRegId src, out RegOp dst)
            => RLU.Find(src, out dst);

        public bool Map(RegKind src, out XedRegId dst)
            => XLU.Find(src, out dst);

        public ReadOnlySpan<RegMapEntry> REntries
        {
            [MethodImpl(Inline)]
            get => RLUData;
        }

        public ReadOnlySpan<RegMapEntry> XEntries
        {
            [MethodImpl(Inline)]
            get => XLUData;
        }

        static XedRegMap Instance = create();
    }
}