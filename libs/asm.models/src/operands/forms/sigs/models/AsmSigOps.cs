//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct AsmSigOps : INullity, IHashed
    {
        public AsmSigOp Op0;

        public AsmSigOp Op1;

        public AsmSigOp Op2;

        public AsmSigOp Op3;

        public AsmSigOp Op4;

        public AsmSigOp this[int i]
        {
            get => i switch {
                0 => Op0,
                1 => Op1,
                2 => Op2,
                3 => Op3,
                4 => Op4,
                _ => AsmSigOp.Empty,
            };

            set
            {
                switch(i)
                {
                    case 0:
                        Op0 = value;
                    break;
                    case 1:
                        Op1 = value;
                    break;
                    case 2:
                        Op2 = value;
                    break;
                    case 3:
                        Op3 = value;
                    break;
                    case 4:
                        Op4 = value;
                    break;
                }
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpCount == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => OpCount != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (Hash32)(Op0.Hash | Op1.Hash) | (Hash32)(Op2.Hash | Op3.Hash | Op4.Hash);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsmSigOps src)
        {
            var result = OpCount == src.OpCount;
            result &= Op0 == src.Op0;
            result &= Op1 == src.Op1;
            result &= Op2 == src.Op2;
            result &= Op3 == src.Op3;
            result &= Op4 == src.Op4;
            return result;
        }

        public byte OpCount
        {
            [MethodImpl(Inline)]
            get => (byte)(u8(Op0.IsNonEmpty) + u8(Op1.IsNonEmpty) + u8(Op2.IsNonEmpty) + u8(Op3.IsNonEmpty) + u8(Op4.IsNonEmpty));
        }

        public static AsmSigOps Empty => default;
    }
}