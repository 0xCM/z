//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        public static EcmaReader Reader(this EcmaFile src)
            => EcmaReader.create(src);
    }

}