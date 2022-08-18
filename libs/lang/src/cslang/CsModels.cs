//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly partial struct CsModels
    {
        [Op]
        public static SummaryComment comment(string content)
            => new SummaryComment(content);
    }
}