//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

using static XedModels;

public sealed class XedRegMap
{
    public static XedRegMap Service => Instance;

    static readonly Dictionary<RegKind,XedRegId> RX = new Pairings<RegKind, XedRegId>(new Paired<RegKind,XedRegId>[]{
        (RegKind.MM0,XedRegId.MMX0),
        (RegKind.MM1,XedRegId.MMX1),
        (RegKind.MM2,XedRegId.MMX2),
        (RegKind.MM3,XedRegId.MMX3),
        (RegKind.MM4,XedRegId.MMX4),
        (RegKind.MM5,XedRegId.MMX5),
        (RegKind.MM6,XedRegId.MMX6),
        (RegKind.MM7,XedRegId.MMX7),
    }).Storage.ToDictionary();

    static Dictionary<XedRegId,RegKind> XR = sys.map(RX, x => Tuples.paired(x.Value, x.Key)).ToDictionary();

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
        dst.RegIndex = (byte)reg.IndexCode;
        return dst;
    }

    readonly ConstLookup<XedRegId,RegOp> XedToCanonicalLookup;

    readonly ConstLookup<RegKind,XedRegId> CanonicalToXedLookup;

    readonly ReadOnlySeq<RegMapEntry> XedToCanonicalEntries;

    readonly ReadOnlySeq<RegMapEntry> CanonicalToXedEntries;

    XedRegMap(ConstLookup<XedRegId,RegOp> rlu, ConstLookup<RegKind,XedRegId> xlu)
    {
        XedToCanonicalLookup = rlu;
        CanonicalToXedLookup = xlu;
        XedToCanonicalEntries = sys.map(rlu.Entries, x => entry(x.Key, x.Value));
        CanonicalToXedEntries = sys.map(xlu.Entries, x => entry(x.Value, x.Key));
    }

    RegOp Map(XedRegId src)
    {
        if(XedToCanonicalLookup.Find(src, out var reg))
            return reg;
        else
            return RegOp.Empty;
    }

    XedRegId Map(RegKind src)
    {
        if(CanonicalToXedLookup.Find(src, out var reg))
            return reg;
        else
            return XedRegId.INVALID;
    }

    public static RegOp convert(XedRegId src)
        => Instance.Map(src);

    public static XedRegId convert(RegOp src)
        => Instance.Map(src);

    public static bool convert(XedRegId src, out RegOp dst)
        => Instance.XedToCanonicalLookup.Find(src,out dst);

    public static bool convert(RegKind src, out XedRegId dst)
        => Instance.CanonicalToXedLookup.Find(src, out dst);

    public static ReadOnlySpan<RegMapEntry> REntries
    {
        [MethodImpl(Inline)]
        get => Instance.XedToCanonicalEntries;
    }

    public static ReadOnlySpan<RegMapEntry> XEntries
    {
        [MethodImpl(Inline)]
        get => Instance.CanonicalToXedEntries;
    }

    static readonly XedRegMap Instance = create();
}
