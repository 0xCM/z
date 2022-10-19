//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdDef
    {
        CmdUri Uri {get;}
    }

    [Free]
    public interface ICmdDef<D> : ICmdDef
        where D : struct, ICmdDef<D>
    {

    }
}