//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        [MethodImpl(Inline), Op]
        public static CmdVarInfo varinfo(@string name, TextBlock purpose)
            => new (name,purpose);
    }
}