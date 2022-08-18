//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Report<T>
        where T : struct
    {
        protected Index<T> Rows {get; set;}

        T[] Storage
        {
            [MethodImpl(Inline)]
            get => Rows.Storage;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Rows.View;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Rows.Edit;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Rows.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Rows.Length;
        }

        public ref T this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Rows[index];
        }

        public ref T this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Rows[index];
        }
    }
}