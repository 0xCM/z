//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRenderProduct<T>
    {
        IFormatPattern Pattern {get;}

        T Product {get;}
    }
}