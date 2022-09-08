//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmPrefixCodes;

    public struct BranchHintPrefix : IAsmPrefix<BranchHintCode>
    {
        BranchHintCode _Code;

        [MethodImpl(Inline)]
        public BranchHintPrefix(BranchHintCode src)
        {
            _Code = src;
        }

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => (byte)_Code;
        }

        [MethodImpl(Inline)]
        public BranchHintCode Code()
            => _Code;

        [MethodImpl(Inline)]
        public void Code(BranchHintCode src)
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
            => Encoded.FormatHex();

        [MethodImpl(Inline)]
        public static implicit operator BranchHintPrefix(BranchHintCode src)
            => new BranchHintPrefix(src);

        [MethodImpl(Inline)]
        public static implicit operator BranchHintCode(BranchHintPrefix src)
            => src.Code();

        [MethodImpl(Inline)]
        public static implicit operator byte(BranchHintPrefix src)
            => (byte)src._Code;
    }
}