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

        public readonly _OpUri Uri;

        public readonly @string Sig;

        [MethodImpl(Inline)]
        public MethodEntryPoint(MemoryAddress address, _OpUri uri, @string sig)
        {
            Location = address;
            Uri = Require.notnull(uri);
            Sig = sig;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Location == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Location != 0;
        }

        public static MethodEntryPoint Empty => new MethodEntryPoint(0,_OpUri.Empty, EmptyString);
    }
}