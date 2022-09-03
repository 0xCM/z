//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckRunner
    {
        void Run();

        void Run(bool pll);

        ReadOnlySpan<string> Checks
            => sys.empty<string>();
    }
}