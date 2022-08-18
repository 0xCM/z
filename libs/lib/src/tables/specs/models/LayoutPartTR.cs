//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using api = DataLayouts;

    /// <summary>
    /// Defines a <typeparamref name='T'/> kinded segment partition
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct LayoutPart<T,R>
        where T : unmanaged
        where R : unmanaged
    {
        public LayoutIdentity<T> Id {get;}

        readonly PartitionSegment<R> Range;

        /// <summary>
        /// The enclosure-relative partition index
        /// </summary>
        public uint Index => Id.Index;

        [MethodImpl(Inline)]
        public LayoutPart(LayoutIdentity<T> id, R start, R end)
        {
            Id = id;
            Range = new PartitionSegment<R>(start,end);
        }

        /// <summary>
        /// The inclusive lower index
        /// </summary>
        public R Left
        {
            [MethodImpl(Inline)]
            get => Range.Min;
        }

        /// <summary>
        /// The inclusive upper index
        /// </summary>
        public R Right
        {
            [MethodImpl(Inline)]
            get => Range.Max;
        }

        /// <summary>
        /// The partition width determined by <see cref='Right'/> - <see cref='Left'/>
        /// </summary>
        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Range.Width;
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

    }
}