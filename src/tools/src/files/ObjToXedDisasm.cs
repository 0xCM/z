//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Tools;

    partial class FileFlows
    {
        /// <summary>
        /// *.obj -> *.xed.disam.txt
        /// </summary>
        public class ObjToXedDisasm : FileFlow<ObjToXedDisasm,Xed>
        {
            public ObjToXedDisasm()
                : base(xed, FileKind.Obj, FileKind.XedRawDisasm)
            {

            }
        }
    }
}