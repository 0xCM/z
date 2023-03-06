//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineTokenizer : ITokenizer<LineSource,TextLine,TextLine>
    {
        public IEnumerable<TextLine> Tokenize(LineSource src)
        {
            var dst = TextLine.Empty;
            while(src.Next(out dst))
            {
                yield return dst;                     
            }
        }
    }
}