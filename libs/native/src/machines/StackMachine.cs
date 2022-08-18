//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiComplete]
    public readonly ref struct StackMachine
    {
        public const byte CellSize = 8;

        readonly Span<StackState> State;

        readonly Span<ulong> Storage;

        public StackMachine(uint capacity)
        {
            Storage = alloc<ulong>(capacity);
            State = new StackState[1]{new StackState(capacity)};
        }

        /// <summary>
        /// Specifies the size of the stack, in bytes
        /// </summary>
        public ByteSize StackSize
        {
            [MethodImpl(Inline)]
            get => Capacity * CellSize;
        }

        /// <summary>
        /// Presents a view of the current state
        /// </summary>
        [MethodImpl(Inline)]
        public ref readonly StackState state()
            => ref first(State);

        [MethodImpl(Inline)]
        public bool Push(ulong src)
        {
            if(Index < Capacity - 1)
            {
                seek(Storage, Index) = src;
                Index++;
                Count++;
                Current = src;
                return true;
            }
            else
                return false;
        }

        [MethodImpl(Inline)]
        public bool Pop(out ulong dst)
        {
            if(Count > 0)
            {
                dst = Current;
                Current = seek(Storage, 0);
                Count--;
                Index--;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        ref ulong Current
        {
            [MethodImpl(Inline)]
            get => ref first(State).Current;
        }

        ref uint Index
        {
            [MethodImpl(Inline)]
            get => ref first(State).Index;
        }

        /// <summary>
        /// Specifies the buffer cell count
        /// </summary>
        ref readonly uint Capacity
        {
            [MethodImpl(Inline)]
            get => ref first(State).Capacity;
        }

        /// <summary>
        /// Tracks the number of contented cells
        /// </summary>
        ref uint Count
        {
            [MethodImpl(Inline)]
            get => ref first(State).Count;
        }
    }
}