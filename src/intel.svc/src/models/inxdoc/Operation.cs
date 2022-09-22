//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public struct Operation
        {
            public const string ElementName = "operation";

            public List<TextLine> Content;

            public Operation()
            {
                Content = new();
            }

            [MethodImpl(Inline)]
            public Operation(List<TextLine> src)
            {
                Content = src;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => (uint)(Content?.Count ?? 0);
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Count != 0;
            }
        }
    }
}