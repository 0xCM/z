//-----------------------------------------------------------------------------
// Copyright   :  Microsoft/DotNet Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct CilModels
{
    [DataWidth(3)]
    public enum OpCodeType : byte
    {
        Annotation = 0,

        Macro = 1,

        Nternal = 2,

        Objmodel = 3,

        Prefix = 4,

        Primitive = 5,
    }
}
