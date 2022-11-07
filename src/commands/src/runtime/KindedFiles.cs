//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class KindedFiles : ChannelIterator<FileUri>
    {
        readonly Func<IEnumerable<FileUri>> Selector;

        public KindedFiles(IWfChannel channel, FolderPath root, params FileKind[] kinds)
            : base(channel)
        {            
            Selector = () => DbArchive.enumerate(root, true, kinds);
        }

        protected override IEnumerable<FileUri> Select()
            => Selector();
    }
}