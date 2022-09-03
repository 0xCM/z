//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Settings(Name)]
    public record struct WatchSettings : ISettings<WatchSettings>
    {
        public const string Name = "watch";

        public string Sources;

        public string Targets;
    }
}