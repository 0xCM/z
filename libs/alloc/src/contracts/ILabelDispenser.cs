//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ILabelDispenser : IAllocDispenser<Label>
    {
        Label Label(string content);
    }
}