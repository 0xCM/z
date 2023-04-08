//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class SettingLookup : Seq<SettingLookup,Setting>, ILookup<@string,Setting>
    {
        public SettingLookup()
        {

        }

        [MethodImpl(Inline)]
        public SettingLookup(Setting[] src)
            : base(src)
        {

        }

        public bool Find(@string key, out Setting setting)
            => Settings.search(this, key, out setting);

        public override string Format()
            => Settings.format(this);
    }
}