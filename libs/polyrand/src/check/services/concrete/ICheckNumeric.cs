//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckNumeric :
        ICheckGeneric,
        ICheckSpans,
        ICheckClose,
        ICheckPrimalSeq
    {
    }
}