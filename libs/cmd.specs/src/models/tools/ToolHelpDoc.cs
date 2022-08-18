//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolHelpDoc
    {
        FS.FilePath Source;

        TextBlock Data;

        public readonly bool IsEmpty;

        public readonly Actor Tool;

        public ToolHelpDoc()
        {
            IsEmpty = true;
            Data = EmptyString;
            Source = FS.FilePath.Empty;
        }

        public ToolHelpDoc(Actor tool, FS.FilePath path)
        {
            Source = path;
            Tool = tool;
            IsEmpty = false;
            Data = EmptyString;
        }

        public ToolHelpDoc(Actor tool, FS.FilePath src, string data)
        {
            Tool = tool;
            Source = src;
            IsEmpty = false;
            Data = data;
        }

        public TextBlock Content
            => Data;

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();

        public ToolHelpDoc Load()
            => new ToolHelpDoc(Tool, Source, Source.ReadText());

        public static ToolHelpDoc Empty => new ToolHelpDoc();
    }
}