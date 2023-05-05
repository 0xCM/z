//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CellWriters
    {
        public static CellWriter<T> wrap<T>(BinaryWriter writer)
            where T : unmanaged
                => new CellWriter<T>(writer,false);
    }
}