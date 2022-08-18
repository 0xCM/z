//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IPageDispenser : IAllocDispenser<MemorySeg>
    {
        MemorySeg Page();
    }

}