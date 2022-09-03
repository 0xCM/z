//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        [MethodImpl(Inline), Op]
        public static CmdVarInfo varinfo(Name name, TextBlock purpose)
            => new (name,purpose);
    }
}