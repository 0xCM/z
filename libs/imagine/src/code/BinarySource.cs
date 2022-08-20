//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SourceCode
    {
    }

    public record class BinarySource : SourceCode<BinarySource, BinaryCode>
    {
        public BinarySource()
            : base(BinaryCode.Empty)
        {

        }

        public BinarySource(BinaryCode src)
            : base(src)
        {

        }

        public override bool IsEmpty 
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public override Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.Hash;
        }
        
        public override string Format()
            => Content.Format();

        [MethodImpl(Inline)]
        public static implicit operator BinarySource(BinaryCode src)
            => new BinarySource(src);

        [MethodImpl(Inline)]
        public static implicit operator BinarySource(byte[] src)
            => new BinarySource(src);
    }
}