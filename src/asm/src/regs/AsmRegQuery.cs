//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    using api = AsmRegs;

    [ApiHost]
    public ref struct AsmRegQuery
    {
        /// <summary>
        /// Defines a query source over a specified operand sequence
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static AsmRegQuery query(ReadOnlySpan<RegOp> src)
            => new (src);

        readonly ReadOnlySpan<RegOp> Regs;

        readonly Span<RegOp> Cache;

        public uint RegCount
        {
            [MethodImpl(Inline)]
            get => (uint)Regs.Length;
        }

        internal AsmRegQuery(ReadOnlySpan<RegOp> src)
        {
            Regs = src;
            Cache = alloc<RegOp>(src.Length);
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<RegOp> Where(RegClassCode @class)
        {
            var target = Cache;
            var count = api.filter(@class, Regs, target);
            return slice(target, 0, count);
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<RegOp> Where(NativeSizeCode width)
        {
            var target = Cache;
            var count = api.filter(width, Regs, target);
            return slice(target, 0, count);
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<RegOp> Where(RegClassCode @class, NativeSizeCode width)
        {
            var target = Cache;
            var count = api.filter(@class, width, Regs, target);
            return slice(target, 0, count);
        }
    }
}