//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRecord
    {
        [Op]
        TableId TableId {get;}
    }

    [Free]
    public interface IRecord<T> : IRecord
        where T : struct, IRecord<T>
    {
        TableId IRecord.TableId
            => TableId.identify(typeof(T));
    }

    [Free]
    public interface IComparableRecord<T> : IRecord<T>, IComparable<T>
        where T : struct, IComparableRecord<T>
    {

    }
}