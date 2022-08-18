//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct ClrHandle<T>
        where T : struct
    {
        public ClrArtifactKind Kind {get;}

        public CliToken Token {get;}

        public T Handle {get;}

        [MethodImpl(Inline)]
        public ClrHandle(ClrArtifactKind kind, CliToken token, T handle)
        {
            Kind = kind;
            Token = token;
            Handle = handle;
        }

        // [MethodImpl(Inline)]
        // public static implicit operator ClrHandle(ClrHandle<T> src)
        //     => api.untype(src);
    }
}