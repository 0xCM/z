//-----------------------------------------------------------------------------
// Copyright   : (c) LLVM Project
// License     : Apache-2.0 WITH LLVM-exceptions
// Source      : llvm/lib/Support/YAMLParser.cpp
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public struct YamlToken
    {
        public YamlTokenKind Kind {get;}

        [MethodImpl(Inline)]
        public YamlToken(YamlTokenKind kind)
        {
            Kind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator YamlToken(YamlTokenKind src)
            => new YamlToken(src);

        public static YamlToken Empty
        {
            [MethodImpl(Inline)]
            get => new YamlToken(0);
        }
    }
}