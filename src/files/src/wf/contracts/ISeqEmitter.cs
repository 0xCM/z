//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public interface ISeqEmitter
    {
        IEnumerable<dynamic> Yield();    
    }

    public interface ISeqEmitter<T> : ISeqEmitter
    {
        new IEnumerable<T> Yield();

        IEnumerable<dynamic> ISeqEmitter.Yield()
            => from item in Yield() select (dynamic)item;
    }
}