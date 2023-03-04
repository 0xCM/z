//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static EcmaReader EcmaReader(this EcmaFile src)
            => Z0.EcmaReader.create(src);
    }
}