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
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToExe : FileFlow<ObjToExe,LlvmLld>
        {
            public ObjToExe()
                : base(llvm_lld, K.Obj, K.Exe)
            {

            }
        }
    }
}