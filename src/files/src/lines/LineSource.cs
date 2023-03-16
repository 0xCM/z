//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineSource : ITokenSource<TextLine>
    {
        [Op]
        public static LineSource lines(FilePath src)
            => new LineSource(src.Utf8LineReader());

        readonly LineReader Reader;

        internal LineSource(LineReader src)
        {
            Reader = src;
        }

        public void Dispose()
            => Reader.Dispose();

        public bool Next(out TextLine dst)
            => Reader.Next(out dst);
    }
}