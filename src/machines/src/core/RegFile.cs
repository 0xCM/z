//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Asm;

    /// <summary>
    /// Defines a squence of register seqeunces
    /// </summary>
    public readonly struct RegFile
    {
        static long FileSeqKeys;

        static long RegSeqKeys;

        [Op]
        public static RegFile intel64()
        {
            var gp64 = new RegSeqSpec((uint)inc(ref RegSeqKeys), 16, NativeSizeCode.W64);
            var v512 = new RegSeqSpec((uint)inc(ref RegSeqKeys), 32, NativeSizeCode.W512);
            var masks = new RegSeqSpec((uint)inc(ref RegSeqKeys), 8, NativeSizeCode.W64);
            var system = new RegSeqSpec((uint)inc(ref RegSeqKeys), 8, NativeSizeCode.W64);
            return new RegFile((uint)inc(ref FileSeqKeys),new RegSeqSpec[]{gp64,v512,masks,system});
        }

        /// <summary>
        /// A surrogate key
        /// </summary>
        public readonly uint Id;

        readonly Index<RegSeqSpec> Data;

        public uint SeqCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        internal RegFile(uint seq, RegSeqSpec[] specs)
        {
            Id = seq;
            Data = specs;
        }

        public Span<RegSeqSpec> Specs
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref RegSeqSpec Spec(uint seq)
            => ref Data[seq];
    }
}