//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IChecker : IApiService
    {
        void Run(IEventTarget dst, bool pll);

        void Run(bool pll, IEventTarget dst)
            => Run(dst,pll);

        ref readonly Index<string> Specs {get;}
    }
}