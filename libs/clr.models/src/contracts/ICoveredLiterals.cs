//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type that defines views over captured literals
    /// </summary>
    /// <typeparam name="K">The covered literal type</typeparam>
    public interface ICoveredLiterals<C>
        where C : struct, ICoveredLiterals<C>
    {
        FieldInfo[] Covered
            => typeof(C).GetFields();
    }
}