//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ArgProtocol
    {
        public ArgPrefix Prefix {get;}

        public ArgQualifier Qualifier {get;}

        [MethodImpl(Inline)]
        public ArgProtocol(ArgPrefix delimiter, ArgQualifier qualifier)
        {
            Prefix = delimiter;
            Qualifier = qualifier;
        }

        [MethodImpl(Inline)]
        public ArgProtocol(ArgPrefix delimiter)
        {
            Prefix = delimiter;
            Qualifier = AsciCode.Space;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Prefix.IsEmpty && Qualifier.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public static implicit operator ArgProtocol(ArgPrefix prefix)
            => new ArgProtocol(prefix);

        [MethodImpl(Inline)]
        public static implicit operator ArgProtocol((ArgPrefix prefix, ArgQualifier qualifier) src)
            => new ArgProtocol(src.prefix, src.qualifier);

        public static ArgProtocol Empty
        {
            [MethodImpl(Inline)]
            get => new ArgProtocol(ArgPrefix.Empty, ArgQualifier.Space);
        }
    }
}