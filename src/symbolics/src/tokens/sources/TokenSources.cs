//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class TokenSources
    {
        public static LineSource lines(FileUri src)
            => new LineSource(src.Utf8LineReader());

        public static CharSource chars(FileUri src)
            => new CharStream(src.Utf8Reader());
    }
}