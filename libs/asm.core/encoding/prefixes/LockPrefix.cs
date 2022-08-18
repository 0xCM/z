//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmPrefixCodes;

    public struct LockPrefix : IAsmPrefix<LockPrefixCode>, IAsmByte<LockPrefix>
    {
        public LockPrefixCode _Code;

        [MethodImpl(Inline)]
        public LockPrefix(LockPrefixCode src)
        {
            _Code = src;
        }

        [MethodImpl(Inline)]
        public byte Value()
            => (byte)_Code;

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => (byte)_Code;
        }

        [MethodImpl(Inline)]
        public LockPrefixCode Code()
            => _Code;

        [MethodImpl(Inline)]
        public void Code(LockPrefixCode src)
            => _Code = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Code == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => _Code != 0;
        }

        public override string ToString()
            => Format();

        public string Format()
            => AsmBytes.format(this);

        [MethodImpl(Inline)]
        public static implicit operator LockPrefix(LockPrefixCode src)
            => new LockPrefix(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(LockPrefix src)
            => (byte)src._Code;
    }
}