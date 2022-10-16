//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial class Cmd
    {
        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";
    }
}