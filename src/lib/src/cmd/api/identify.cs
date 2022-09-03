//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        public static CmdId identify<T>()
            => CmdId.identify<T>();

        [Op]
        public static CmdId identify(Type spec)
            => CmdId.identify(spec);
    }
}