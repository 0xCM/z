//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public readonly struct OpenHandle : IDisposable
    {
        [MethodImpl(Inline)]
        public static OpenHandle opened(IntPtr src)
            => new OpenHandle(src);
        public IntPtr Handle {get;}

        [MethodImpl(Inline)]
        public OpenHandle(IntPtr value)
        {
            Handle = value;
        }

        public void Dispose()
        {
            if(IsNonEmpty)
                Kernel32.CloseHandle(Handle);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => (ulong)Handle == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => (ulong)Handle != 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(OpenHandle src)
            => src.Handle;

        [MethodImpl(Inline)]
        public static implicit operator OpenHandle(IntPtr src)
            => new OpenHandle(src);
    }
}