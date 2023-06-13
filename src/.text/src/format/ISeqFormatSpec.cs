//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISeqFormatSpec
    {
        string Delimiter {get;}
    }

    public interface ISeqFormatSpec<C> : ISeqFormatSpec
        where C : struct, ISeqFormatSpec
    {

    }
}