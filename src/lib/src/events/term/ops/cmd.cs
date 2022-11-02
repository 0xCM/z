//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct term
    {
        public static void cmd()
            => write("cmd> ", (FlairKind)ConsoleColor.Cyan);
    }
}