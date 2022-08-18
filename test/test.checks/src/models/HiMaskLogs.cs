//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HiMaskLogs<T> : IIndex<HiMaskLog<T>>
    {
        readonly Index<HiMaskLog<T>> Data;

        public ReadOnlySpan<HiMaskLog<S>> Review<S>()
            where S : unmanaged
                => core.recover<HiMaskLog<T>,HiMaskLog<S>>(Storage);

        public ref HiMaskLog<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref HiMaskLog<T> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public HiMaskLog<T>[] Storage
            => Data;

        public ReadOnlySpan<HiMaskLog<T>> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public HiMaskLogs(HiMaskLog<T>[] src)
            => Data = src;

        [MethodImpl(Inline)]
        public HiMaskLogs<T> Refresh(HiMaskLog<T>[] src)
            => new HiMaskLogs<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator HiMaskLogs<T>(HiMaskLog<T>[] src)
            => new HiMaskLogs<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Span<HiMaskLog<T>>(HiMaskLogs<T> src)
            => src.Storage;
    }
}