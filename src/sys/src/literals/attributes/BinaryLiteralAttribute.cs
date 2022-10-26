//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Attaches a binary literal value to a target
    /// </summary>
    public class BinaryLiteralAttribute : Attribute
    {
        public string Text {get;}

        public string Description {get;}

        public BinaryLiteralAttribute(string src)
        {
            Text = src ?? EmptyString;
            Description = EmptyString;
        }

        public BinaryLiteralAttribute(string src, string pattern, byte arg0, byte arg1)
        {
            Text = src ?? EmptyString;
            Description = string.Format(pattern, arg0, arg1);
        }

        public BinaryLiteralAttribute(string src, string pattern, byte arg0)
        {
            Text = src ?? EmptyString;
            Description = string.Format(pattern, arg0);
        }
    }
}