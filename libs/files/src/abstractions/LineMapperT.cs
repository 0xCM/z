//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class LineMapper<T> : LineMapper<LineMapper<T>, T>
    {
        public override T Map(TextLines src)
        {
            throw new NotImplementedException();
        }
    }
}