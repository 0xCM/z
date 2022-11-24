//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiArithmeticClass;

    /// <summary>
    /// Characterizes an arithmetic function classifier
    /// </summary>
    public interface IApiArithmeticApClass : IApiClass<K>
    {
        /// <summary>
        /// The literal identifier that will be lifted to the type-level
        /// </summary>
        new K Kind {get;}

        K IApiClass<K>.Kind
            => Kind;

        NumericKind OperandKind
            => default;
    }
}