//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArg<T> arg<T>(T value)
            where T : ICmdArg<T>, IEquatable<T>, IComparable<T>
                => value;
        [Op]
        public static CmdArg arg(CmdArgs src, int index)
        {
            if(src.IsEmpty)
                @throw(EmptyArgList.Format());

            var count = src.Count;
            if(count < index - 1)
                @throw(ArgSpecError.Format());
            return src[(ushort)index];
        }
    }
}