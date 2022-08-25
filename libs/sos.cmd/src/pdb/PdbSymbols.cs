//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.SymbolStore;
    using Microsoft.SymbolStore.KeyGenerators;
    using SOS;

    public sealed class PdbSymbols : AppService<PdbSymbols>
    {
        public static PdbReader reader(PdbSymbolSource src)
            => PdbReader.create(src);

        public static PdbReader reader(FilePath pe, FilePath pdb)
        {
            if(!pe.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pe));
            if(!pdb.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pdb));
            return PdbReader.create(PdbSymbols.source(pe, pdb));
        }

        public static SymbolMetadata metadata(PdbSymbolSource source)
            => new SymbolMetadata(source);

        /// <summary>
        /// Loads a symbol source from specified binary data
        /// </summary>
        /// <param name="pe">The pe data</param>
        /// <param name="pdb">The pdb data</param>
        [Op]
        public static PdbSymbolSource source(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
            => new PdbSymbolSource(pe,pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe and pdb paths
        /// </summary>
        /// <param name="pe">The pe file path</param>
        /// <param name="pdb">The pdb file path</param>
        [Op]
        public static PdbSymbolSource source(FilePath pe, FilePath pdb)
            => new PdbSymbolSource(pe, pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe, assuming the existence of a colocated pdb
        /// </summary>
        /// <param name="pe">The pe file path</param>
        [Op]
        public static PdbSymbolSource source(FilePath pe)
            => new PdbSymbolSource(pe, pe.ChangeExtension(FS.Pdb));

        public static DirectorySymbolStore store(FS.FolderPath src, WfEmit channel)
            => new DirectorySymbolStore(tracer(channel), null, src.Name);

        public static SymbolStoreFile file(FilePath src)
            => new SymbolStoreFile(src.Stream(), src.FileName.Name);

        public static KeyGenerator keygen(SymbolStoreFile src, WfEmit channel)
            => new PortablePDBFileKeyGenerator(tracer(channel), src);

        public static ReadOnlySeq<SymbolStoreKey> keys(KeyGenerator src)
            => src.GetKeys(KeyTypeFlags.IdentityKey).Array();

        public static ReadOnlySeq<SymbolStoreKey> keys(SymbolStoreFile src, WfEmit channel)
            => keys(keygen(src, channel)).Array();

        [MethodImpl(Inline)]
        public static ITracer tracer(WfEmit channel)
            => new SymbolTracer(channel);
    }
}