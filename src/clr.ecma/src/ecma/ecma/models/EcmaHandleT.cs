//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaHandle<T>
        where T : struct
    {
        public ClrArtifactKind Kind {get;}

        public EcmaToken Token {get;}

        public T Handle {get;}

        [MethodImpl(Inline)]
        public EcmaHandle(ClrArtifactKind kind, EcmaToken token, T handle)
        {
            Kind = kind;
            Token = token;
            Handle = handle;
        }
    }
}