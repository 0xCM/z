//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TypedLogicSpec;

    using L = AsciLetterLoSym;

    public abstract class t_typed_logix<X> : t_logix<X>
        where X : t_typed_logix<X>
    {

   }
}