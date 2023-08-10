//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IX86Machine : IDisposable
    {
        void Submit(AsmHexCode inst);
    }
}