//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    public class SettingLookup<T> : Seq<SettingLookup<T>,Setting>, ILookup<@string,Setting>
        where T : new()
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
            => api.search(this, key, out setting);

        // public override string Format()
        // {
        //     var dst = text.emitter();
        //     api.render(this, dst);
        //     return dst.Emit();
        // }

        // public override string ToString()
        //     => Format();

        [MethodImpl(Inline)]
        public static implicit operator SettingLookup(SettingLookup<T> src)
            => new SettingLookup(src.Data);
    }
}