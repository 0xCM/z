//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    sealed class QueryReceiver : FileQueries.Receiver<QueryReceiver>
    {
        Action<FileUri> Handler;
        
        public override void Matched(FileUri src)
        {
            Handler?.Invoke(src);
        }

        public QueryReceiver WithHandler(Action<FileUri> handler)
        {
            Handler = handler;
            return this;
        }
    }
}