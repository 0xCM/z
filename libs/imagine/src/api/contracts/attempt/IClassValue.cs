//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IClassValue : ITextual
    {
        object Class {get;}

        Identifier Name => Class?.ToString();

        string ITextual.Format()
            => Class?.ToString() ?? string.Empty;
    }

    public interface IClassValue<C> : IClassValue
    {
        new C Class {get;}

        object IClassValue.Class
            => Class;
    }
}