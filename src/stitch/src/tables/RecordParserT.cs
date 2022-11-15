//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RecordParser<T> : IParser<T>
        where T : struct
    {
        readonly RecordParser Parser;

        public RecordParser(IMultiParser parser)
        {
            Parser = new RecordParser(TableConvention.reflected(typeof(T)), parser);
        }

        public Outcome Parse(string src, out T dst)
        {
            var result = Parser.Parse(src, out var _dst);
            if(result)
                dst = (T)_dst;
            else
                dst = default;
            return result;
        }
    }
}