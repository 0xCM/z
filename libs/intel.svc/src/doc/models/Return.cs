//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public struct Return
        {
            public const string ElementName = "return";

            [Render(12)]
            public string varname;

            [Render(12)]
            public DataType type;

            [Render(12)]
            public string etype;

            [Render(12)]
            public string memwidth;

            public string Format()
                => type.Format();

            public override string ToString()
                => Format();

            public static Return Empty
            {
                get
                {
                    var dst = new Return();
                    dst.varname = EmptyString;
                    dst.type = EmptyString;
                    dst.etype = EmptyString;
                    dst.memwidth = EmptyString;
                    return dst;
                }
            }
        }
    }
}