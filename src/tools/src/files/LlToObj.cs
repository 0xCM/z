//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    using static Tools;

    partial class FileFlows
    {
        /// <summary>
        /// *.ll -> *.obj
        /// </summary>
        public class LlToObj : FileFlow<LlToObj,Llc>
        {
            public LlToObj()
                : base(llc, K.Llir, K.Obj)
            {

            }
        }
    }
}