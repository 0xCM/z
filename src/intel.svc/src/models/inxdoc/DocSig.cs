//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public readonly record struct DocSig
        {
            public readonly Return Return;

            public readonly string Name;

            public readonly Parameters Params;

            [MethodImpl(Inline)]
            public DocSig(Return ret, string name, Parameters ops)
            {
                Return = ret;
                Name = name;
                Params = ops;
            }

            public string Format()
                => string.Format("{0} {1}({2})", Return, Name, string.Join(", ", Params));

            public override string ToString()
                => Format();

            public static DocSig Empty => new DocSig(Return.Empty, EmptyString, new());
        }
    }
}