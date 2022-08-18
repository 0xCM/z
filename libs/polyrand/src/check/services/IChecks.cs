//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IChecks :
        ICheckLengths,
        ICheckPrimal,
        ICheckPrimalSeq,
        ICheckClose,
        ICheckFiles,
        ICheckInvariant,
        ICheckSets,
        ICheckNull
    {

    }
}