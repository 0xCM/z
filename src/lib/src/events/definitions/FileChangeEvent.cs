//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileChangeKind;

    [Event(EventKind.FileChange)]
    public readonly record struct FileChangeEvent : IWfEvent<FileChangeEvent>
    {
        [Op]
        public static asci4 symbolize(FileChangeKind kind)
        {   
            var dst = asci4.Null;
            if(kind.Test(Created))
                dst += "+";
            if(kind.Test(Deleted))
                dst += "-";
            if(kind.Test(Modified))
                dst += "M";
            if(kind.Test(Renamed))
                dst += "R";
            if(dst.IsNull)
                dst = "?";
            return dst;
        }
        
        public readonly FileUri File;

        public readonly FileChangeKind ChangeKind;

        public readonly EventId EventId;

        public FlairKind Flair => FlairKind.Babble;

        public FileChangeEvent(FilePath path, FileChangeKind kind)
        {
            ChangeKind = kind;
            EventId = $"File{kind}";
            File = path;
        }

        EventId IWfEvent.EventId 
            => EventId;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.PSx3, EventId, symbolize(ChangeKind), $"{File}");

        public override string ToString()
            => Format();
    }
}