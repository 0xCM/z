//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    partial class CMake
    {
        public abstract record class DataType<T> : DataType
            where T : DataType<T>, new()
        {
            protected DataType(string name, TypeKind kind)
                : base(name,kind)
            {
            }
        }
    }
}