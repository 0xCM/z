//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISettingKey<K> : IExpr
        where K : ISettingKey<K>
    {
        bool Parse(string src, out K dst);
    }
}