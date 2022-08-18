//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // public interface IChecker :
    //     ICheckError,
    //     ICheckInvariant,
    //     ICheckLengths,
    //     ICheckFiles,
    //     ICheckNull,
    //     ICheckSettings,
    //     ICheckPrimal,
    //     ICheckSets
    // {

    // }

    public interface IChecking :
        ICheckError,
        ICheckInvariant,
        ICheckLengths,
        ICheckFiles,
        ICheckNull,
        ICheckSettings,
        ICheckPrimal,
        ICheckSets
    {

    }
}