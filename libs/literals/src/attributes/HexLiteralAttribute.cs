//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Attaches a hex literal to a target
    /// </summary>
    public class HexLiteralAttribute : Attribute
    {
        public string Text {get;}

        public HexLiteralAttribute(string src)
        {
            Text = src ?? EmptyString;
        }
    }
}