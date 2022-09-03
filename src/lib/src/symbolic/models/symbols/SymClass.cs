//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SymClass
    {
        [Parser]
        public static Outcome parse(string src, out SymClass dst)
        {
            dst = new SymClass(src);
            return true;
        }

        public readonly string Name;

        [MethodImpl(Inline)]
        public SymClass(string name)
        {
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => core.empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => core.nonempty(Name);
        }

        public string Format()
            => Name ?? EmptyString;

        public override string ToString()
            => Format();

        public static SymClass Empty
        {
            [MethodImpl(Inline)]
            get => new SymClass(EmptyString);
        }
    }
}