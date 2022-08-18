//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public readonly record struct DataType
        {
            public readonly string Name;

            [MethodImpl(Inline)]
            public DataType(string src)
            {
                Name = src;
            }

            public string Format()
                => Name;

            public override string ToString()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator DataType(string src)
                => new DataType(src);
        }
    }
}