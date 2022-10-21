//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate R FuncIn<A,R>(in A a);

    [Free]
    public delegate R FuncIn<A,B,R>(in A a, in B b);

    [Free]
    public delegate R FuncIn<A,B,C,R>(in A a, in B b, in C c);
}