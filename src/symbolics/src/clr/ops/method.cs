//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ClrMethodAdapter method(Delegate src)
            => src.Method;

        [MethodImpl(Inline), Op]
        public static string @string(Module module, EcmaToken token)
            => module.ResolveString((int)token);

        [MethodImpl(Inline), Op]
        public static MethodBase method(Module src, EcmaToken token)
            => src.ResolveMethod((int)token);

        [MethodImpl(Inline), Op]
        public static MethodInfo method(Type type, string name)
            => type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    }
}