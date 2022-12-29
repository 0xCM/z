//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public interface IDataType
        {
            @string Name {get;}
        }

        public interface IDataType<T> : IDataType
            where T : IDataType<T>, new()
        {
        }
    }
}