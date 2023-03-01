//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public sealed class QueryReceiver : FileQueries.Receiver<QueryReceiver>
    {
        Action<FilePath> Handler;
        
        public override void Matched(FilePath src)
        {
            Handler?.Invoke(src);
        }

        public QueryReceiver WithHandler(Action<FilePath> handler)
        {
            Handler = handler;            
            return this;
        }
    }
}