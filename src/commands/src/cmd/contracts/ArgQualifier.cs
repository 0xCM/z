//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ArgQualifier
    {
        readonly AsciCode Code;

        [MethodImpl(Inline)]
        public ArgQualifier(AsciCode code)
            => Code = code;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code == AsciCode.Null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Code != AsciCode.Null;
        }

        [MethodImpl(Inline)]
        public string Format()
            => ((char)Code).ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator string(ArgQualifier src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator ArgQualifier(char src)
            => new ArgQualifier((AsciCode)src);

        [MethodImpl(Inline)]
        public static implicit operator ArgQualifier(AsciCode src)
            => new ArgQualifier(src);

        [MethodImpl(Inline)]
        public static implicit operator ArgQualifier(AsciSymbol src)
            => new ArgQualifier(src);

        public static ArgQualifier Empty
            => new ArgQualifier(AsciCode.Null);

        public static ArgQualifier Space
            => new ArgQualifier(AsciCode.Space);

        public static ArgQualifier Colon
            => new ArgQualifier(AsciCode.Colon);

        public static ArgQualifier Eq
            => new ArgQualifier(AsciCode.Eq);
    }
}