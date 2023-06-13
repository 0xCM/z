//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a method entry point
    /// </summary>
    public readonly struct MethodEntryPoint
    {
        public readonly MemoryAddress Location;

        public readonly OpUri Uri;

        public readonly @string Sig;

        [MethodImpl(Inline)]
        public MethodEntryPoint(MemoryAddress address, OpUri uri, @string sig)
        {
            Location = address;
            Uri = Require.notnull(uri);
            Sig = sig;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Location == 0u;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Location != 0u;
        }

        public static MethodEntryPoint Empty => new MethodEntryPoint(0u,OpUri.Empty, EmptyString);
    }
}