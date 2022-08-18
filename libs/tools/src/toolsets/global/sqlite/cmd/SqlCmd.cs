//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
        partial class Sqlite
        {
            public readonly record struct SqlCmd
            {
                public readonly TextBlock Content;

                [MethodImpl(Inline)]
                public SqlCmd(string content)
                {
                    Content = content;
                }

                [MethodImpl(Inline)]
                public static implicit operator SqlCmd(string src)
                    => new SqlCmd(src);
            }
        }
    }
}