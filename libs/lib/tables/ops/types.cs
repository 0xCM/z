//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        public static Index<Type> types(params Assembly[] src)
            => src.Types().Tagged<RecordAttribute>();
    }
}