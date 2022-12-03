
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdEmitter
    {
        bool Next(out ICmd cmd);
    }

    public interface ICmdEmitter<C> : ICmdEmitter
        where C : ICmd, new()
    {
        bool Next(out C cmd);

        bool ICmdEmitter.Next(out ICmd cmd)
        {
            var result = Next(out var c);
            cmd = c;
            return result;
        }
    }
}