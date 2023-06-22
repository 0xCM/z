//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        /// <summary>
        /// Identifies a disassembly workflow
        /// </summary>
        public readonly record struct DisasmToken
        {
            readonly ulong Data;

            [MethodImpl(Inline)]
            public DisasmToken(ulong value)
            {
                Data = value;
            }

            [MethodImpl(Inline)]
            public DisasmToken Branch(uint seq)
                => (uint)Data | (seq << 32);

            public uint Seq
            {
                [MethodImpl(Inline)]
                get => (uint)(Data >> 32);
            }

            public uint Value
            {
                [MethodImpl(Inline)]
                get => (uint)Data;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            [MethodImpl(Inline)]
            public static implicit operator DisasmToken(ulong src)
                => new DisasmToken(src);

            [MethodImpl(Inline)]
            public static ulong branch(ulong token, uint seq)
                => token | (seq << 32);

            public static DisasmToken Empty => default;
        }
    }
}