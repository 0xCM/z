//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Attaches a binary literal value to a target or identifies a literal field
    /// </summary>
    public class IndicatorAttribute : Attribute
    {
        public object Min {get;}

        public object Max {get;}

        public string Indicator {get;}

        public IndicatorAttribute(AsciCharSym c)
        {
            Indicator = $"{c}";
            Min = c;
            Max = c;
        }

        public IndicatorAttribute(string indicator, byte min, byte max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, sbyte min, sbyte max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, ushort min, ushort max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, short min, short max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, uint min, uint max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, int min, int max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, long min, long max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, ulong min, ulong max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, float min, float max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, double min, double max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }

        public IndicatorAttribute(string indicator, decimal min, decimal max)
        {
            Indicator = indicator;
            Min = min;
            Max = max;
        }
    }
}