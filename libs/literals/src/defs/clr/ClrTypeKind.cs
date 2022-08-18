//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines classifiers that correspond to the basic CLR types
    /// </summary>
    [Flags, SymSource(clr)]
    public enum ClrTypeKind : uint
    {
        None = 0,

        [Symbol("class")]
        Class = ClrArtifactKind.Class,

        [Symbol("struct")]
        Struct = ClrArtifactKind.Struct,

        [Symbol("delegate")]
        Delegate = ClrArtifactKind.Delegate,

        [Symbol("enum")]
        Enum = ClrArtifactKind.Enum,

        [Symbol("interface")]
        Interface = ClrArtifactKind.Interface
    }
}
