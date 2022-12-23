//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public class FileTypes : ReadOnlySeq<FileTypes, IFileClassifier>
    {
        public static FileTypes Types => new();

        public FileTypes()
            : base(Classifiers.Array())
        {
            
        }

        static readonly HashSet<IFileClassifier> Classifiers = ApiAssemblies.Parts.Types().Tagged<FileClassifierAttribute>().Concrete().Map(x => (IFileClassifier)Activator.CreateInstance(x)).ToHashSet();
    }
}