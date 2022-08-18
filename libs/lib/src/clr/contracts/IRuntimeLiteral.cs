//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IRuntimeLiteral : IClrLiteralValue
    {
        Label Source {get;}

        Label Name {get;}
    }

    public interface IRuntimeLiteral<T> : IRuntimeLiteral, IClrLiteralValue<T>
        where T : IEquatable<T>
    {

    }
}