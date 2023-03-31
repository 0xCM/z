//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ToolStreamWriter : ToolStreamWriter<ToolStreamWriter>
    {
        readonly FilePath TargetPath;

        StreamWriter TargetStream;

        public ToolStreamWriter(FilePath dst)
        {
            TargetPath = dst;
        }

        public override void Write(TextLine src)
        {
            if(TargetStream == null)
                TargetStream = TargetPath.Utf8Writer(false);
            TargetStream.WriteLine(src.Content);            
        }

        protected override void Dispose()
        {
            TargetStream?.Dispose();
        }
    }
}
