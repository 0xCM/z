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
        public class ObjToObjAsm : FileFlow<ObjToObjAsm,LlvmObjDump>
        {
            public ObjToObjAsm()
                : base(llvm_objdump, K.Obj, K.ObjAsm)
            {

            }
        }
    }
}