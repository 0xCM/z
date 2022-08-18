//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ReflectedByteSpan
    {
        public readonly ClrMethodArtifact Source;

        public readonly BinaryCode Content;

        [MethodImpl(Inline)]
        public ReflectedByteSpan(ClrMethodArtifact source, BinaryCode content)
        {
            Source = source;
            Content = content;
        }
    }
}