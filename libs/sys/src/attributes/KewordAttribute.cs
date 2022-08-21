//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Applied to a function to denote inclusion as a keword within the DSL
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class KeywordAttribute : OpAttribute
    {

    }
}