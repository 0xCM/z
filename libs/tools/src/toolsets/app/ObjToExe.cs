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