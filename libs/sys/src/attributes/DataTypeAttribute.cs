//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class DataTypeAttribute : Attribute
    {

    }

    /// <summary>
    /// Applied to a type to denote inclusion as a datatype within the DSL
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Class | AttributeTargets.Field)]
    public class DataTypeAttributeD : Attribute
    {
        public DataTypeAttributeD()
        {
            Group = EmptyString;
            Name = EmptyString;
            Kind = EmptyString;
        }

        public DataTypeAttributeD(string group)
        {
            Group = group;
            Name = group;
            Kind = group;
        }

        public DataTypeAttributeD(NumericKind closures)
        {
            Group = EmptyString;
            Closures = closures;
            Kind = EmptyString;
            Name = EmptyString;
        }

        public DataTypeAttributeD(string group, NumericKind closures)
        {
            Group = group;
            Closures = closures;
            Name = group;
            Kind = group;
        }

        public DataTypeAttributeD(string name, bool @virtual)
        {
            Name = name;
            Group = name;
            Kind = EmptyString;
        }

        public string Group {get;}

        public NumericKind Closures {get;}

        public string Name {get;}

        public object Kind {get;}
    }
}