//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BitMaskAttribute : BinaryLiteralAttribute
    {
        public BitMaskAttribute(string src)
            : base(src)
        {

        }

        public BitMaskAttribute(string src, string pattern, byte arg0, byte arg1)
            : base(src,pattern,arg0,arg1)
        {

        }
    }
}