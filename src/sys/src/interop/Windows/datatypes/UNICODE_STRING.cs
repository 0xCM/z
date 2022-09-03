//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UNICODE_STRING
    {
        // The length in bytes of the string pointed to by buffer, not including the null-terminator.
        public ushort Length;

        // The total allocated size in memory pointed to by buffer.
        public ushort MaximumLength;

        // A pointer to the buffer containing the string data.
        public IntPtr Buffer;
    }
}