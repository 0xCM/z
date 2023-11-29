//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{
    [Op]
    public static string format(GridStats stats, int? colpad = null, char? delimiter = null)
    {
        var dst = text.buffer();
        var pad = colpad ?? 10;
        var sep = delimiter ?? Chars.Pipe;
        dst.Append($"{stats.Name}".PadRight(pad));
        dst.Append($" {sep} {stats.RowCount}".PadRight(pad));
        dst.Append($" {sep} {stats.ColCount}".PadRight(pad));
        dst.Append($" {sep} {stats.SegWidth}".PadRight(pad));
        dst.Append($" {sep} {stats.PointCount}".PadRight(pad));
        dst.Append($" {sep} {stats.SorageSegs}".PadRight(pad));
        dst.Append($" {sep} {stats.StorageBits}".PadRight(pad));
        dst.Append($" {sep} {stats.StorageBytes}".PadRight(pad));
        dst.Append($" {sep} {stats.Vec128Count}".PadRight(pad));
        dst.Append($" {sep} {stats.Vec128Remainder}".PadRight(pad));
        dst.Append($" {sep} {stats.Vec256Count}".PadRight(pad));
        dst.Append($" {sep} {stats.Vec256Remainder}".PadRight(pad));
        return dst.Emit();
    }
}
