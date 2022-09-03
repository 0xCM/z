//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ClrHandle
    {
        public readonly CliToken Token;

        public readonly ClrArtifactKind Kind;

        public readonly Ptr Pointer;

        [MethodImpl(Inline)]
        public ClrHandle(ClrArtifactKind kind, CliToken key, Ptr ptr)
        {
            Kind = kind;
            Token = key;
            Pointer = ptr;
        }
    }
}