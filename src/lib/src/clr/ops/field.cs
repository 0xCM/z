//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static FieldInfo field(Module src, CliToken token)
            => src.ResolveField((int)token);

        [MethodImpl(Inline), Op]
        public static FieldInfo field(Type type, string name)
            => type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    }
}