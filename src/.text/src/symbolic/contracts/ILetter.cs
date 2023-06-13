//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ILetter
    {
        uint Code {get;}
    }

    [Free]
    public interface ILetter<S> : ILetter
        where S : unmanaged
    {
        S Symbol {get;}
    }

    [Free]
    public interface ILetter<S,C> : ILetter<S>
        where S : unmanaged
        where C : unmanaged
    {
        new C Code {get;}

        uint ILetter.Code
            => sys.bw32(Code);
    }
}