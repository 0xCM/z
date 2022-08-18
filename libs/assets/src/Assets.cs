//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ApiAtomic;

    [ApiHost("asset.services")]
    public sealed class Assets : WfSvc<Assets>
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static Index<ResourceName> ManifestNames(Assembly src)
        {
            var names = src.GetManifestResourceNames();
            var dst = alloc<ResourceName>(names.Length);
            for(var i=0; i<names.Length; i++)
                seek(dst,i) = new ResourceName(skip(names,i));
            return dst;
        }

        public static ReadOnlySeq<AssetCatalogEntry> entries(Index<Asset> src)
        {
            var count = src.Length;
            var dst = alloc<AssetCatalogEntry>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = entry(src[i]);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AssetCatalogEntry entry(in Asset src)
        {
            AssetCatalogEntry dst = new();
            dst.BaseAddress = src.Address;
            dst.Name = src.Name.ManifestName;
            dst.Size = src.Size;
            return dst;
        }

        public static AssetName name(Assembly src, string resname)
        {
            var manifest = resname;
            var @short = manifest;
            var m0 = src.GetSimpleName() + ".";
            if(text.index(manifest, m0) >= 0)
                @short = text.remove(@short, m0);

            var m1 = "assets" + ".";
            if(text.index(@short,m1) >= 0)
                @short = text.remove(@short, m1);

            return new AssetName(manifest,@short);
        }

        [MethodImpl(Inline), Op]
        public static Asset asset(Assembly source, string manifest, MemoryAddress address, ByteSize size)
            => new Asset(name(source, manifest), address, size);

        [MethodImpl(Inline), Op]
        public static unsafe ComponentAssets extract(Assembly src)
        {
            var names = src.GetManifestResourceNames().Index();
            var srcname = src.GetSimpleName();
            var count = names.Count;
            var buffer = alloc<Asset>(count);
            var dst = new ComponentAssets(src, buffer);
            for(var i=0u; i<count; i++)
            {
                var stream = (UnmanagedMemoryStream)src.GetManifestResourceStream(names[i]);
                var manifest = new ResourceName(names[i]);
                dst[i] = Assets.asset(src, names[i], stream.PositionPointer, (uint)stream.Length);
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Index<ComponentAssets> extract(ReadOnlySpan<Assembly> src)
        {
            var dst = list<ComponentAssets>();
            iter(src, component => dst.Add(extract(component)));
            return dst.ToArray();
        }

        [Op]
        public static ApiCodeRes code(string id, ReadOnlySpan<CodeBlock> src)
        {
            var count = src.Length;
            var buffer = alloc<BinaryResSpec>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new BinaryResSpec(string.Format("{0}_{1}", id, i), skip(src,i));
            return new ApiCodeRes(buffer);
        }

        /// <summary>
        /// Reveals the data represented by a <see cref='Asset'/>
        /// </summary>
        /// <param name="src">The source descriptor</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset src)
            => core.view(src.Address, src.Size);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<T> view<T>(in Asset<T> id)
            where T : unmanaged
                => core.view<T>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset<byte> id)
            => core.view<byte>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> view(in Asset<char> id)
            => core.view<char>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public unsafe static ReadOnlySpan<char> view(in Asset<char> res, uint i0, uint i1)
            => core.section((char*)res.Address, i0, i1);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset<byte> res, uint i0, uint i1)
            => core.view<byte>(res.Address, (i1 - i0 + 1));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> view(in StringResRow src)
            => core.view<char>(src.Address, src.Length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ResMember member<T>(MemberInfo member, ReadOnlySpan<T> src)
            => new ResMember(member, MemorySegs.define(recover<T,byte>(src)));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(FieldInfo field, uint size)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, size));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W8 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 1));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W16 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 2));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W32 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 4));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W64 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 8));

        [Op]
        public static Index<ResDocInfo> docs(Assembly src)
        {
            var names = src.GetManifestResourceNames().Index();
            var count = names.Length;
            var dst = alloc<ResDocInfo>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new ResDocInfo(names[i]);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static string utf8(in Asset src)
            => Encoding.UTF8.GetString(view(src));

        [MethodImpl(Inline), Op]
        public static BinaryAsset binary(Assembly owner, string id, ReadOnlySpan<byte> src)
            => new BinaryAsset(owner, id, src.Length, core.address(src));

        [MethodImpl(Inline), Op]
        public static BinaryAsset binary(Assembly owner, string id, ByteSize size, MemoryAddress address)
            => new BinaryAsset(owner, id, size, address);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ReadOnlySpan<T> extract<T>(in ResMember member, uint i0, uint i1)
            where T : unmanaged
                => section(member.Address.Pointer<T>(), i0, i1);

        public static Outcome<Count> structured(Asset src, string delimiter, ReadOnlySpan<byte> widths, FS.FilePath dst)
        {
            var data = text.utf8(src.Bytes());
            var result = TextGrids.parse(data, out var doc);
            if(result.Fail)
                return result;

            return TextGrids.normalize(data, delimiter, widths, dst);
        }

        public static bool resource(in Asset src, TextDocFormat format, out TextGrid dst)
        {
            var content = utf8(src);
            using var stream = content.Stream();
            using var reader = new StreamReader(stream);
            var result = TextGrids.parse(reader, format);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = TextGrid.Empty;
                return false;
            }
        }

        public static bool structured(in Asset src, out TextGrid dst)
        {
            var content = utf8(src);
            using var stream = content.Stream();
            using var reader = new StreamReader(stream);
            var result = TextGrids.parse(reader, TextDocFormat.Structured());
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = TextGrid.Empty;
                return false;
            }
        }
    }
}