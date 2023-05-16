//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class DbBuilder
    {
        [MethodImpl(Inline), Op]
        public static DbDataType type(Name name, Name primitive, DataSize size, Name refinement = default)
            => new DbDataType(name, primitive, size, refinement.IsNonEmpty, refinement);

        [MethodImpl(Inline), Op]
        public static DbCol col(ushort pos, Name name, ReadOnlySpan<byte> widths)
            => new DbCol(pos, name, skip(widths, pos));

        public static Index<DbCol> resequence(Index<DbCol> left, Index<DbCol> right)
        {
            var count = left.Count + right.Count;
            var dst = sys.alloc<DbCol>(count);
            var k=z8;
            for(var i=0; i<left.Count; i++, k++)
                seek(dst,k) = (left[i].Reposition(k));

            for(var i=0; i<right.Count; i++, k++)
                seek(dst,k) = (right[i].Reposition(k));

            return dst;
        }

        [MethodImpl(Inline), Op]
        public static void split(uint src, out ushort a, out ushort b)
        {
            a = (ushort)(src & 0x0000_FFFF);
            b = (ushort)((src & 0xFFFF_0000) >> 16);
        }

        public static void check(IWfChannel channel)
        {
            check(channel, (32,32));
            check(channel, (12,12));
            check(channel, (8,8));
            check(channel, (256,256));
        }

        public static DbGrid<T> grid<T>(Dim2<uint> shape)
            => new DbGrid<T>(new DbRowGrid<T>(shape), new DbColGrid<T>(shape));

        public static void check(IWfChannel channel, Dim2<uint> shape)
        {
            var r = shape.I;
            var c = shape.J;
            var m = (uint)(r*c);
            var grid = DbBuilder.grid<byte>(shape);
            ref readonly var rows = ref grid.Rows;
            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                    rows[i,j] = (byte)math.mod((i*c + j), r) ;
            }

            var cols = rows.Columns();
            var rDst = text.emitter();
            var cDst = text.emitter();

            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                {
                    rDst.AppendFormat("{0:X2} | ", rows[i,j]);
                    cDst.AppendFormat("{0:X2} | ", cols[i,j]);
                }

                rDst.AppendLine();
                cDst.AppendLine();
            }

            var linear = Points.multilinear(shape);
            var lDst = text.emitter();
            Points.render(linear, lDst);

            var scope = "memdb";
            var suffix = $"{r}x{c}";
            channel.FileEmit(lDst.Emit(), linear.Count, AppDb.Service.Logs().Targets(scope).Path($"{scope}.linear.{suffix}", FileKind.Csv));
            channel.FileEmit(rDst.Emit(), m, AppDb.Service.Logs().Targets(scope).Path($"{scope}.rows.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
            channel.FileEmit(cDst.Emit(), m, AppDb.Service.Logs().Targets(scope).Path($"{scope}.cols.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
        }
    }
}