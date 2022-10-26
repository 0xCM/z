//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Applied to a structural artifact or member field, method or property to indicate that the target provides some sort of literal data
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class LiteralProviderAttribute : Attribute
    {
        public string Group {get;}

        public uint Kind {get;}

        public LiteralProviderAttribute()
        {
            Group = "";
            Kind = 0;
        }

        public LiteralProviderAttribute(string group)
        {
            Group = group;
            Kind = 0;
        }

        public LiteralProviderAttribute(ClrLiteralKind kind)
        {
            Group = "";
            Kind = (byte)kind;
        }

        public LiteralProviderAttribute(ClrEnumKind kind)
        {
            Group = "";
            Kind = (uint)kind << 8;
        }

        public LiteralProviderAttribute(string group, ClrLiteralKind kind)
        {
            Group = group;
            Kind = (byte)kind;
        }

        public LiteralProviderAttribute(string group, ClrEnumKind kind)
        {
            Group = group;
            Kind = (uint)kind << 8;
        }
    }
}