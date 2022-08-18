//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Symbols
    {
        [Op]
        public static string group(Type src)
            => text.ifempty(src.Tag<SymSourceAttribute>().MapValueOrDefault(a => a.SymGroup, EmptyString), EmptyString);
    }
}