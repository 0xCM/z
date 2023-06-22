//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SdmFormSeq : Seq<SdmFormSeq,SdmForm>
    {
        public SdmFormSeq()
        {

        }

        public SdmFormSeq(SdmForm[] src)
            : base(src)
        {
        }

        [MethodImpl(Inline)]
        public static implicit operator SdmFormSeq(SdmForm[] src)
            => new SdmFormSeq(src);
    }
}