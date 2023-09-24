//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public readonly record struct ModRmDomain
{
    [MethodImpl(Inline)]
    public static ModRmDomain define(ModRmClass @class)
        => new (@class);

    [MethodImpl(Inline)]
    public static ModRmDomain define(ModRmClass @class, ClosedInterval<uint2> mod,  ClosedInterval<uint3> reg, ClosedInterval<uint3> rm)
        => new (@class, mod, reg, rm);

    [MethodImpl(Inline)]
    public static ModRmDomain define(ClosedInterval<uint2> mod,  ClosedInterval<uint3> reg, ClosedInterval<uint3> rm)
        => new (ModRmKind.None, mod, reg, rm);

    [MethodImpl(Inline)]
    public static ModRmDomain define(uint2 mod,  ClosedInterval<uint3> reg, ClosedInterval<uint3> rm)
        => new (ModPoint(mod), reg, rm);

    [MethodImpl(Inline)]
    public static ModRmDomain define(ModRmClass mod, uint3 reg, uint3 rm)
        => new (mod, RegPoint(reg), RmPoint(rm));

    [MethodImpl(Inline)]
    public static ModRmDomain define(ModRmClass mod,  ClosedInterval<uint3> reg, uint3 rm)
        => new (mod, reg, RmPoint(rm));

    [MethodImpl(Inline)]
    public static ModRmDomain define(ModRmClass mod,  uint3 reg, ClosedInterval<uint3> rm)
        => new (mod, RegPoint(reg), rm);

    [MethodImpl(Inline)]
    static ClosedInterval<uint2> ModPoint(uint2 src)
        =>  (src,src);

    [MethodImpl(Inline)]
    static ClosedInterval<uint3> RegPoint(uint3 src)
        =>  (src,src);

    [MethodImpl(Inline)]
    static ClosedInterval<uint3> RmPoint(uint3 src)
        =>  (src,src);

    [MethodImpl(Inline)]
    static ClosedInterval<uint2> mod(ModRmClass @class)
        => @class.Kind switch{
            ModRmKind.RR => (uint2.Max, uint2.Max),
            ModRmKind.RD => (uint2.Min, uint2.Max - 1),
            _ => (uint2.Min, uint2.Max),
        };

    [MethodImpl(Inline)]
    static ModRmClass ModClass(ClosedInterval<uint2> src)
    {
        if(src.IsDegenerate && src.Min == uint2.Max)
            return ModRmKind.RR;
        else if(src.Min == uint2.Min && src.Max == uint2.Max - 1)
            return ModRmKind.RD;
        else
            return ModRmKind.None;
    }

    public readonly ModRmClass Class;

    public readonly ClosedInterval<uint2> Mod;

    public readonly ClosedInterval<uint3> Reg;

    public readonly ClosedInterval<uint3> Rm;

    [MethodImpl(Inline)]
    public ModRmDomain(ModRmClass @class, ClosedInterval<uint3> reg, ClosedInterval<uint3> rm)
    {
        Class = @class;
        Mod = mod(@class);
        Reg = reg;
        Rm = rm;
    }

    [MethodImpl(Inline)]
    public ModRmDomain(ClosedInterval<uint2> mod, ClosedInterval<uint3> reg, ClosedInterval<uint3> rm)
    {
        Class = ModClass(mod);
        Mod = mod;
        Reg = reg;
        Rm = rm;
    }


    [MethodImpl(Inline)]
    public ModRmDomain(ModRmClass @class, ClosedInterval<uint2> mod,  ClosedInterval<uint3> reg, ClosedInterval<uint3> rm)
    {
        Class = @class;
        Mod = mod;
        Reg = reg;
        Rm = rm;
    }

    [MethodImpl(Inline)]
    public ModRmDomain(ModRmClass @class)
    {
        Class = @class;
        Mod = mod(@class);
        Reg = (uint3.Min, uint3.Max);
        Rm = (uint3.Min, uint3.Max);
    }

    public string Format()
    {
        var _mod = Mod.IsNonDegenrate ? string.Format("mod[{0}:{1}]", Mod.Max, Mod.Min) : Mod.Format();
        var _reg  = Reg.IsNonDegenrate ? string.Format("reg[{0}:{1}]", Reg.Max, Reg.Min) : Reg.Format();
        var _rm = Rm.IsNonDegenrate ? string.Format("rm[{0}:{1}]", Rm.Max, Rm.Min) : Rm.Format();
        return string.Format("{0} | {1} | {2}", _mod, _reg, _rm);
    }

    public override string ToString()
        => Format();
}
