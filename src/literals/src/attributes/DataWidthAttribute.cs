//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Class)]
    public class DataWidthAttribute : Attribute
    {
        public DataWidthAttribute(uint packed, uint native = 0)
        {
            PackedWidth = packed;
            NativeWidth = native;
        }

        public uint PackedWidth {get;}

        public uint NativeWidth {get;}
    }
}