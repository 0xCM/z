//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckSF : ITestService, ICheckVectors
    {
        bool ExcludeZero => false;
    }
}