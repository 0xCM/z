//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a parameter that accepts an immediate value
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ImmAttribute : Attribute
    {
        public ImmAttribute()
        {
            Min = 0;
            Max = 0;
        }

        public ImmAttribute(byte max)
        {
            Min = 0;
            Max = max;
        }

        public ImmAttribute(byte min, byte max)
        {
            Min = min;
            Max = max;
        }

        public byte Min {get;}

        public byte Max {get;}

        public bool Bounded
            => Max != 0;
    }
}