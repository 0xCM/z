//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x16;

    /// <summary>
    /// Artifact classifiers that align with literals defined by <see cref='AttributeTargets'/>
    /// </summary>
    [Flags, SymSource(clr)]
    public enum ClrArtifactKind : uint
    {
        None = 0,

        Assembly = P2ᐞ00,

        Module = P2ᐞ01,

        Class = P2ᐞ02,

        Struct = P2ᐞ03,

        Enum = P2ᐞ04,

        Ctor = P2ᐞ05,

        Method = P2ᐞ06,

        Property = P2ᐞ07,

        Field = P2ᐞ08,

        Event = P2ᐞ09,

        Interface = P2ᐞ10,

        ValueParam = P2ᐞ11,

        Delegate = P2ᐞ12,

        ReturnValue = P2ᐞ13,

        TypeParam = P2ᐞ14,

        Type = Struct | Class | Delegate | Interface | Enum,

        EnumField = Enum | Field,
    }
}