//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a benchmark measure for an operator
    /// </summary>
    public readonly struct BenchmarkRecord : IRecord<BenchmarkRecord>, IComparable<BenchmarkRecord>, IComparable
    {
        /// <summary>
        /// The name of the measured operation
        /// </summary>
        public readonly _OpIdentity OpId;

        /// <summary>
        /// Either the invocation count or the number of discrete operations performed
        /// </summary>
        public readonly long OpCount;

        /// <summary>
        /// The measured time
        /// </summary>
        public readonly Duration Timing;

        public static BenchmarkRecord Empty => new BenchmarkRecord(0, Duration.Zero,string.Empty);

        [MethodImpl(Inline)]
        public static BenchmarkRecord Capture(_OpIdentity op, long opcount, in SystemCounter clock)
            => new BenchmarkRecord(op, opcount, clock.Elapsed());

        [MethodImpl(Inline)]
        public static implicit operator BenchmarkRecord(in (_OpIdentity op, long opcount, SystemCounter clock)  src)
            => Capture(src.op,src.opcount, src.clock);

        [MethodImpl(Inline)]
        public static implicit operator BenchmarkRecord((string opName, long opCount, SystemCounter clock) src)
            => Capture(_OpIdentity.define(src.opName), src.opCount, src.clock);

        [MethodImpl(Inline)]
        public static BenchmarkRecord Define(long count, Duration timing, string label)
            => new BenchmarkRecord(_OpIdentity.define(label), count, timing);

        [MethodImpl(Inline)]
        BenchmarkRecord(_OpIdentity id, long opcount, Duration elapsed)
        {
            OpId = id;
            OpCount = opcount;
            Timing = elapsed;
        }

        [MethodImpl(Inline)]
        BenchmarkRecord(long count, Duration timing, string Label)
        {
            this.OpId = _OpIdentity.define(Label ?? "?");
            this.OpCount = count;
            this.Timing = timing;
        }

        const int OpNamePad = 30;

        const int OpCountPad = 15;

        public string Format(int? labelPad = null)
            => $"{OpId}".PadRight(labelPad ?? OpNamePad) + $" | Ops = {OpCount} " + $"| Time = {Timing}";

        public override string ToString()
            => Format();

        public int CompareTo(BenchmarkRecord other)
            => OpId.IdentityText.CompareTo(other.OpId.IdentityText);

        public int CompareTo(object obj)
            => obj is BenchmarkRecord r ? CompareTo(r) : -1;
    }
}