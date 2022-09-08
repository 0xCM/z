//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   public interface ICmdRender<C> : ICmdRender
        where C : ICmd<C>, new()
    {
        CmdId ICmdRender.CmdId 
            => CmdId.identify<C>();

        string Format(C src);
        
        string ICmdRender.Format(ICmd src)
            => Format((C)src);
    }
        
    [Free]
    public interface ICmd<T> : ICmd
        where T : ICmd<T>, new()
    {
        CmdId ICmd.CmdId
            => CmdId.identify<T>();

        string IExpr.Format()
            => CmdFormat.format(this);
    }    

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

    [Free]
    public interface IShellCmd<D> : ICmdDef<D>
        where D : struct, IShellCmd<D>
    {

    }
}