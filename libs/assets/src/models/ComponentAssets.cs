//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ComponentAssets : IIndex<Asset>
    {
        public readonly Assembly Source;

        readonly Index<Asset> Data;

        [MethodImpl(Inline)]
        public ComponentAssets(Assembly src, Index<Asset> data)
        {
            Data = data;
            Source = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public Asset[] Storage
        {
            get => Data.Storage;
        }

        public ReadOnlySpan<Asset> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref Asset this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Asset this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public ref readonly Asset Descriptor(uint index)
            => ref Data[index];

        [MethodImpl(Inline)]
        public ComponentAssets Filter(string match)
            => new ComponentAssets(Source, Data.Storage.Where(x => x.NameLike(match)));

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Content(uint index)
        {
            ref readonly var src = ref Descriptor(index);
            return core.view(src.Address, src.Size);
        }
    }
}