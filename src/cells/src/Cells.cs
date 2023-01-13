//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    [Free, ApiHost]
    public partial class Cells
    {
        const NumericKind Closure = UnsignedInts;
    }

    [Free, ApiHost]
    public unsafe class FixedCells
    {
        public static FixedCells<T> alloc<T>(uint count)
            where T : unmanaged
                => sys.alloc<T>(count);
        
        public static FixedCells<T> load<T>(Span<T> src)
            where T : unmanaged
                => new FixedCells<T>(src);
        
        public static FixedCells<T> load<T>(Span<byte> src)
            where T : unmanaged
        {
            var rem = (src.Length % sys.size<T>());
            return load(recover<T>(slice(src,0, src.Length - rem)));            
        }

        public static CellWriter<T> writer<T>(BinaryWriter writer)
            where T : unmanaged
                => new CellWriter<T>(writer,false);
    }
}