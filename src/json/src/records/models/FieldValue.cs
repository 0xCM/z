//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public record class FieldValue
        {
            public readonly dynamic Value;
            
            internal FieldValue(dynamic value)
            {
                Value = value;                
            }
        }
    }
}