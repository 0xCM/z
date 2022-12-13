//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdPipes
    {

    }



    public abstract class CmdPipe<S0,P0,S1,E> 
        where S0 : IApiCmd, new()
        where P0 : INullity, new()
        where S1 : IApiCmd, new()
        where E : IExecutor
    {
            
    }
}