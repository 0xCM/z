//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public interface ISeqReceiver
    {
        void Accept(IEnumerable<dynamic> src);
    }

    public interface ISeqReceiver<T> : ISeqReceiver
    {
        void Accept(IEnumerable<T> src);

        void ISeqReceiver.Accept(IEnumerable<dynamic> src)
            =>Accept(from item in src select (T)item);
    }
}