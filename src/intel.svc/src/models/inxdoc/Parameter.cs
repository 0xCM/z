//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public record struct Parameter
        {
            public const string ElementName = "parameter";

            public @string varname;

            public @string type;

            public @string etype;

            public @string memwidth;

            public @string immwidth;

            public string Format()
                => string.Format("{0} {1}", type, varname);

            public override string ToString()
                => Format();
        }
    }
}