//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct Null<T> : IType<ulong>
        where T : IType
    {
        public static Null<T> Empty => default;

        public Identifier Name => "null<" + typeof(T).Name + ">";
        public bool IsEmpty
            => true;

        public Null<T> Zero
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