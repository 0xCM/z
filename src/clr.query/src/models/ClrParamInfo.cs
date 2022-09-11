//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a method (value, not type) parameter
    /// </summary>
    public readonly struct ClrParamInfo
    {
        public readonly string Name;

        public readonly ushort Position;

        public readonly ClrTypeSigInfo Type;

        public readonly ClrParamModifierKind RefKind;

        [MethodImpl(Inline)]
        public ClrParamInfo(ClrTypeSigInfo type, ClrParamModifierKind refkind, string name, ushort pos)
        {
            Type = type;
            Name = name;
            Position = pos;
            RefKind = refkind;
        }
    }
}