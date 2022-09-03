//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMultiParser
    {
        Outcome Parse(Type t, string src, out dynamic dst);

        Outcome Parse<T>(string src, out T dst);
    }
}