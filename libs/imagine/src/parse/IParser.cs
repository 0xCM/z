//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IParser
    {
        Type TargetType {get;}

        Outcome Parse(string src, out dynamic dst);
    }

    [Free]
    public interface IParser<T> : IParser
    {
        Outcome Parse(string src, out T dst);

        Type IParser.TargetType
            => typeof(T);

        Outcome IParser.Parse(string src, out dynamic dst)
        {
            var result = Parse(src, out var x);
            if(result)
            {
                dst = x;
            }
            else
            {
                dst = default(T);
            }
            return result;
        }
    }
}