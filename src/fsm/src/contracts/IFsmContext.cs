//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines context specialization for FSM
    /// </summary>
    public interface IFsmContext
    {
        ulong? ReceiptLimit {get;}
    }
}