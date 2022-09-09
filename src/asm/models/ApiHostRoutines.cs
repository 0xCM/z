//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    /// <summary>
    /// Collects sequences of instructions from host-defined members
    /// </summary>
    public readonly struct ApiHostRoutines
    {
        /// <summary>
        /// The defining host
        /// </summary>
        public ApiHostUri Uri {get;}

        /// <summary>
        /// The base address of the first member, where members are ordered by their individual base addresses
        /// </summary>
        public MemoryAddress BaseAddress {get;}

        /// <summary>
        /// The decoded members
        /// </summary>
        public Index<ApiHostRoutine> Members {get;}

        /// <summary>
        /// The total instruction count
        /// </summary>
        public uint InstructionCount {get;}

        [MethodImpl(Inline)]
        public ApiHostRoutines(ApiHostUri host, ApiHostRoutine[] src)
        {
            Uri = host;
            Members = src.OrderBy(x => x.BaseAddress).ToArray();
            BaseAddress = Members.Length != 0 ? Members[0].BaseAddress : MemoryAddress.Zero;
            InstructionCount = (uint)Members.Sum(i => (long)i.InstructionCount);
        }

        /// <summary>
        /// The member instruction content length
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => Members.Length;
        }

        public uint RoutineCount
        {
            [MethodImpl(Inline)]
            get => (uint)Members.Length;
        }
    }
}