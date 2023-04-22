//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Null
    {
        public static Null Empty => default;

        public Identifier Name => "null";

        public bool IsEmpty
            => true;

        public Null Zero
            => Empty;

        public ulong Kind
            => 0;

        [MethodImpl(Inline)]
        public string Format()
            => Name;

        public override string ToString()
            => Format();
    }
}