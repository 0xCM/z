//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileClassifier
    {
        ReadOnlySeq<IFileType> SupportedTypes {get;}

        bool Clasify(FileUri src, out IFileType dst);

        void Classify(IEnumerable<FileUri> src, Action<FileUri, bool, IFileType> dst);
    }
}