//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public abstract record class DataType<T> : DataType, IDataType<T>
            where T : DataType<T>, new()
        {
            protected DataType(string name)
                :base(name)
            {
            }

            static T _Type = new();

            public static ref readonly T Type => ref _Type;
        }        
    }
}