//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EcmaHandle
    {
        public readonly EcmaToken Token;

        public readonly ClrArtifactKind Kind;

        public readonly Ptr Pointer;

        [MethodImpl(Inline)]
        public EcmaHandle(ClrArtifactKind kind, EcmaToken key, Ptr ptr)
        {
            Kind = kind;
            Token = key;
            Pointer = ptr;
        }
    }
}