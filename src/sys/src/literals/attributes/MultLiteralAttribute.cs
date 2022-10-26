//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Attaches a muliliteral to a target
    /// </summary>
    public class MultiLiteralAttribute : Attribute
    {
        public readonly string Data;

        public MultiLiteralAttribute(string data)
        {
            Data = data;
        }
    }
}