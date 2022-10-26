//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RenderSlotAttribute : Attribute
    {
        public readonly byte Position;

        public readonly string SlotContent;

        public RenderSlotAttribute(byte position, string content)
        {
            Position = position;
            SlotContent = content;
        }
    }
}