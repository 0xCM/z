//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class NativeTypeMap
{
    public static NativeTypeMap build(Action<MapBuilder> f)
    {
        var map = new NativeTypeMap(f);
        f(map._Builder);
        return map;
    }

    public struct MapBuilder
    {
        readonly Dictionary<string,MapEntry> Data;

        readonly List<string> Sources;

        int SourceIndex;

        NativeTypeMap _Map;

        internal MapBuilder(NativeTypeMap map, Dictionary<string,MapEntry> data, List<string> sources)
        {
            _Map = map;
            Data = data;
            Sources  = sources;
            SourceIndex = 0;
        }

        public MapEntry Map(string src, NativeType dst)
        {
            Sources.Add(src);
            var mapped = new MapEntry(_Map, SourceIndex++, dst);
            Data[src] = mapped;
            return mapped;
        }
    }

    NativeTypeMap(Action<MapBuilder> f)
    {
        var data = dict<string,MapEntry>();
        var sources = list<string>();
        _Builder = new MapBuilder(this, data, sources);
        f(_Builder);
        _Sources = sources.ToArray();
        Data = data;
    }

    readonly MapBuilder _Builder;

    ConstLookup<string,MapEntry> Data;

    Index<string> _Sources;

    internal ref readonly string this[int index]
    {
        [MethodImpl(Inline)]
        get => ref _Sources[index];
    }

    internal ref readonly string this[uint index]
    {
        [MethodImpl(Inline)]
        get => ref _Sources[index];
    }

    public ReadOnlySpan<string> Sources
    {
        [MethodImpl(Inline)]
        get => Data.Keys;
    }

    public ReadOnlySpan<MapEntry> Targets
    {
        [MethodImpl(Inline)]
        get => Data.Values;
    }

    public bool TryMap(string src, out MapEntry dst)
        => Data.Find(src, out dst);

    public MapEntry Map(string src)
        => Data[src];

    public MapEntry this[string src]
        => Data[src];

    public readonly struct MapEntry
    {
        readonly NativeTypeMap Map;

        readonly int SourceId;

        public readonly NativeType Target;

        [MethodImpl(Inline)]
        internal MapEntry(NativeTypeMap map, int src, NativeType dst)
        {
            Map = map;
            SourceId = src;
            Target = dst;
        }

        public ref readonly string Source
        {
            [MethodImpl(Inline)]
            get => ref Map[SourceId];
        }

        public string Format()
            => NativeSigs.format(this);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Target.GetHashCode() | ((int)SourceId << 24);

        public bool Equals(MapEntry src)
            => SourceId == src.SourceId && Target == src.Target;
    }
}
