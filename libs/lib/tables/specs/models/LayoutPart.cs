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

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct LayoutPart : IDataLayout<LayoutPart>
    {
        /// <summary>
        /// Defines enclosure-relative partition identity
        /// </summary>
        public LayoutIdentity Id {get;}

        readonly PartitionSegment<ulong> Range;

        /// <summary>
        /// The enclosure-relative partition index
        /// </summary>
        public uint Index => Id.Index;

        [MethodImpl(Inline)]
        public LayoutPart(LayoutIdentity id, ulong start, ulong end)
        {
            Id = id;
            Range = new PartitionSegment<ulong>(start,end);
        }

        /// <summary>
        /// The bit position at which partition begins
        /// </summary>
        public ulong Left
        {
            [MethodImpl(Inline)]
            get => Range.Min;
        }

        /// <summary>
        /// The bit position at which partition ends
        /// </summary>
        public ulong Right
        {
            [MethodImpl(Inline)]
            get => Range.Max;
        }

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