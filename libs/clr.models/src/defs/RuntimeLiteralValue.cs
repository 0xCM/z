//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct RuntimeLiteralValue<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public RuntimeLiteralValue(T src)
        {
            Data = src;
        }

        public string Format()
            => Data?.ToString();

        public override string ToString()
            => Format();
    }
}