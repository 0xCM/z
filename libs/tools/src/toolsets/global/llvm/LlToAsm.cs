//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    partial class Tools
    {
        /// <summary>
        /// *.ll -> *ll.asm
        /// </summary>
        public class LlToAsm : FileFlow<LlToAsm,Llc>
        {
            public LlToAsm()
                : base(llc, K.Llir, K.LlAsm)
            {

            }
        }
    }
}