//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    using Id = ApiClassKind;

    /// <summary>
    /// Identifies binary arithmetic operators classes
    /// </summary>
    [ApiClass, SymSource(api_classes)]
    public enum ApiBinaryArithmeticClass : ushort
    {
        /// <summary>
        /// The empty identity
        /// </summary>
        None = 0,

        Add = Id.Add,

        AddS = Id.AddS,

        AddH = Id.AddH,

        AddHS = Id.AddHS,

        Sad = Id.Sad,

        Sub = Id.Sub,

        SubH = Id.SubH,

        SubHS = Id.SubHS,

        SubS = Id.SubS,

        Mul = Id.Mul,

        MulLo = Id.MulLo,

        MulHi = Id.MulHi,

        Div = Id.Div,

        Mod = Id.Mod,

        Clamp = Id.Clamp,

        Dist = Id.Dist,

        ClMul = Id.ClMul,

        Dot = Id.Dot,

        Fma = Id.Fma,

        ModMul = Id.ModMul
    }
}