//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    /// <summary>
    /// Collects sequences instructions from part-defined api hosts
    /// </summary>
    public readonly struct ApiPartRoutines
    {
        /// <summary>
        /// The decoded instructions
        /// </summary>
        readonly Index<ApiHostRoutines> Data;

        /// <summary>
        /// The defining part
        /// </summary>
        public PartId Part {get;}

        [MethodImpl(Inline)]
        public ApiPartRoutines(PartId part, ApiHostRoutines[] src)
        {
            Part = part;
            Data = src;
        }

        public Span<ApiHostRoutines> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<ApiHostRoutines> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref ApiHostRoutines this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ApiHostRoutines this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        /// <summary>
        /// The number of host routine sets
        /// </summary>
        public Count HostCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        /// <summary>
        /// The total routine count
        /// </summary>
        public Count RoutineCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Storage.Sum(x => x.RoutineCount);
        }

        /// <summary>
        /// The total instruction count
        /// </summary>
        public Count InstructionCount
            => (uint)Data.Storage.Sum(i => (long)i.InstructionCount);

        public Index<ApiInstruction> Instructions()
            => Data.Storage.SelectMany(x => x.Members).SelectMany(x => x.Instructions.Storage).OrderBy(x => x.IP).Array();

        public static ApiPartRoutines Empty
            => new ApiPartRoutines(PartId.None, sys.empty<ApiHostRoutines>());

    }
}