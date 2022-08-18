//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute(string name)
        {
            FieldName = name;
            DataWidth = 0;
        }

        public FieldAttribute(uint width)
        {
            FieldName = string.Empty;
            DataWidth = width;
        }

        public FieldAttribute(string name, uint width)
        {
            FieldName = name;
            DataWidth = width;
        }

        public string FieldName {get;}

        public uint DataWidth {get;}
    }
}