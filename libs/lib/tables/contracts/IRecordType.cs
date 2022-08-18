//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRecordType : IType
    {
        ulong IType.Kind
            => 0;
    }

    public interface IRecordType<T> : IRecordType
        where T : struct
    {
        Identifier IType.Name
            => Tables.identify<T>().Format();
    }
}