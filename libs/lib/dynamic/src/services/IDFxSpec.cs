//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDFxSpec
    {
        Identifier Name {get;}

        SegRef Code {get;}
    }

    [Free]
    public interface IDFxSpec<T> : IDFxSpec
        where T : IDFxSpec<T>
    {

    }
}