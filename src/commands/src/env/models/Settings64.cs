//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class Settings64 : Settings<Settings64,Name,Setting64>
    {
        public Settings64()
        {

        }

        readonly ReadOnlySeq<Setting64> _Settings;

        public Settings64(Setting64[] data)
            : base(data.Select(x => new Setting<Name,Setting64>(x.Name, x)))
        {
            _Settings = data;
        }

        public ref readonly ReadOnlySeq<Setting64> Settings
        {
            [MethodImpl(Inline)]
            get => ref _Settings;
        }

        public new ref readonly Setting64 this[int i]
        {
            [MethodImpl(Inline)]
            get => ref _Settings[i];
        }

        public new ref readonly Setting64 this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Settings[i];
        }
    }
}