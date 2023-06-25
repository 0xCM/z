//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdEffector
    {
        /// <summary>
        /// Identifies a command or related group of commands as specified by the <see cref='SubCommands'/> attribute
        /// </summary>
        ApiCmdRoute Route {get;}
    }
}