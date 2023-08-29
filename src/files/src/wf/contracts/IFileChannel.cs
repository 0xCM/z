//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IFileChannel
{
    ExecToken EmittedBytes(FileEmission flow, ByteSize size);

    ExecToken EmittedFile(FileEmission flow, Count count);

    ExecToken EmittedFile(FileEmission flow, int count);

    ExecToken EmittedFile(FileEmission flow, uint count);

    ExecToken EmittedFile<T>(FileEmission flow, T msg);

    ExecToken EmittedFile(FileEmission flow);
    
    FileEmission EmittingFile(FilePath dst);

    ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

    ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci);

    ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

    ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

    ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

    ExecToken FileEmit(string src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8);
}
