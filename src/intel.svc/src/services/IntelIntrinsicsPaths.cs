//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class IntelIntrinsicPaths
    {
        const string intrinsics = "intel.intrinsics";

        const string sep = ".";

        const string refs = intrinsics + sep + nameof(refs);

        const string checks = intrinsics + sep + nameof(checks);

        const string specs = intrinsics + sep + nameof(specs);

        const string algs = intrinsics + sep + nameof(algs);

        const string sigs = intrinsics + sep + nameof(sigs);

        static FileName AlgFile => FS.file(algs, FS.Txt);

        static FileName XmlFile => FS.file(intrinsics, FS.Xml);

        public static FileName DeclFile = FS.file(intrinsics, FS.H);
 
        readonly IDbArchive _Sources;

        readonly IDbArchive _Targets;

        public IntelIntrinsicPaths(IDbArchive src, IDbArchive dst)
        {
            _Sources = src;
            _Targets = dst;
        }

        public IDbArchive Targets()
            => _Targets;

        public IDbArchive Sources()
            => _Sources;

        public FilePath XmlSource()
            => Sources().Path(XmlFile);

        public FilePath DeclTarget()
            => Targets().Path(DeclFile);

        public FilePath AlgTarget()
            => Targets().Path(AlgFile);

        public FilePath ExportTable<T>()
            where T : struct
                => Targets().Table<T>();
    }
}