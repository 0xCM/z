//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public class FileTypes : AppService<FileTypes>
    {
        public FileTypes()
        {
            Classifiers = ApiAssemblies.Parts.Types().Tagged<FileClassifierAttribute>().Concrete().Map(x => (IFileClassifier)Activator.CreateInstance(x)).ToHashSet();
        }

        readonly HashSet<IFileClassifier> Classifiers;
    }
}