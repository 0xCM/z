//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    /// <summary>
    /// Computes a sequence of bitfield offsets predicated on enum with literals that specify segment widths
    /// </summary>
    /// <typeparam name="W">The enum type</typeparam>
    public static Index<uint> offsets<W>()
        where W : unmanaged, Enum
            => offsets(Bitfields.widths<W>());

    /// <summary>
    /// Computes a sequence of bitfield offsets given a sequence of field widths
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    [Op]
    public static Index<uint> offsets(Index<byte> widths)
    {
        var count = widths.Count;
        var dst = alloc<uint>(count);
        var offset = z8;
        for(var i=0; i<count; i++)
        {
            seek(dst,i) = offset;
            offset += widths[i];
        }
        return dst;
    }

    public static Index<uint> offsets<F,T>(BfDataset<F,T> src)
        where F : unmanaged, Enum
        where T : unmanaged
    {
        var dst = alloc<uint>(src.FieldCount);
        var fields = src.Fields;
        var offset = z8;
        for(var i=0; i<src.FieldCount; i++)
        {
            seek(dst,i) = offset;
            offset += src.Width(fields[i]);
        }
        return dst;
    }    
}
