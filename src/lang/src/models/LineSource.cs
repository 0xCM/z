//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineSource : ITokenSource<TextLine>
    {
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