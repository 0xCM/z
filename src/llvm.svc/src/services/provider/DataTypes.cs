//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataProvider
    {
        public Index<LlvmDataType> DataTypes(Index<RecordField> src)
            => (Index<LlvmDataType>)DataSets.GetOrAdd("DataTypes", _ => DataCalcs.CalcDataTypes(src));
    }
}