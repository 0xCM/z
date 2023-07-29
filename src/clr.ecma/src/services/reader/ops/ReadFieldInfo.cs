//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaReader
    {
        public ParallelQuery<FieldDefRow> ReadFieldDefRows()
            => from handle in FieldDefHandles()
                let def = MD.GetFieldDefinition(handle)
                select new FieldDefRow {
                    Index = handle,
                    DeclaringType = def.GetDeclaringType(),
                    Marshal = def.GetMarshallingDescriptor(),
                    Name = def.Name,
                        Attributes = def.Attributes,
                        Offset = def.GetOffset(),
                        Sig = def.Signature
                };
    }
}