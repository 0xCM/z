//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static FileChangeKind;

public record class FileChangeEvent : IEvent<FileChangeEvent>
{
    [Op]
    public static string symbolize(FileChangeKind kind)
    {   
        var dst = EmptyString;
        if(kind.Test(Created))
            dst += "+";
        if(kind.Test(Deleted))
            dst += "-";
        if(kind.Test(Modified))
            dst += "M";
        if(kind.Test(Renamed))
            dst += "R";
        if(text.empty(dst))
            dst = "?";
        return dst;
    }
    
    public readonly FilePath File;

    public readonly FileChangeKind ChangeKind;

    public readonly EventId EventId;

    public FileChangeEvent()
    {
        File = FilePath.Empty;
        ChangeKind = 0;
        EventId = EventId.Empty;
    }

    public FileChangeEvent(FilePath path, FileChangeKind kind)
    {
        ChangeKind = kind;
        EventId = $"File{kind}";
        File = path;
    }

    public LogLevel EventLevel => LogLevel.Error;

    EventId IEvent.EventId 
        => EventId;

    [MethodImpl(Inline)]
    public string Format()
        => string.Format(RP.PSx3, EventId, symbolize(ChangeKind), $"{File}");

    public override string ToString()
        => Format();
}