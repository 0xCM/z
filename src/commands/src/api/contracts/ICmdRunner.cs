//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdRunner 
    {
        Task<ExecToken> Start(string[] args);   

        ExecToken Run(string[] args);        
    }
}