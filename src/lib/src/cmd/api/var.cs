//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        public static CmdVar<K> var<K>(string name, K kind, string value)
            where K : unmanaged
                => new CmdVar<K>(name,kind,value);

        public static CmdVar<K,T> var<K,T>(string name, K kind, T value)
            where K : unmanaged
                => new CmdVar<K,T>(name, kind, value);

        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(Name name)
            => new CmdScriptVar(name);

        [MethodImpl(Inline), Op]
        public static CmdVar var(Name name, string value)
            => new CmdVar(name, value);

        [MethodImpl(Inline), Op]
        public static CmdVar var(string name, object value)
            => new CmdVar(name, value);
    }
}