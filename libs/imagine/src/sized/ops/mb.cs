//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static Mb mb(Kb src)
            => new Mb(src.Count/(uint)BytesPerKb);

        [MethodImpl(Inline), Op]
        public static Mb mb(Gb src)
            => new Mb(src.Count/(uint)BytesPerGb);
    }
}