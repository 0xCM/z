//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class LineMapper<P,T> : Mapper<P,TextLines,T>, ILineMapper<T>
        where P : LineMapper<P,T>, new()
    {
        
    }
}