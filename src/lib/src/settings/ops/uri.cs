//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        [MethodImpl(Inline), Op]
        public static FileUri uri(in Setting src)
            => new (src.ValueText);
    }
}