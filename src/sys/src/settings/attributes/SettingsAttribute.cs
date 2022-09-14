//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SettingsAttribute : Attribute
    {
        public SettingsAttribute(string name)
        {
            Name = name;
        }

        public @string Name {get;}
    }
}