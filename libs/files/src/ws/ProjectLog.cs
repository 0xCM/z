//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectLog : IDisposable
    {
        ITextEmitter _Emitter;

        [MethodImpl(Inline)]
        ITextEmitter GetEmitter()
        {
            lock(CreateLock)
            {
                if(_Emitter == null)
                    _Emitter = Path.AsciWriter(!Overwrite).Emitter();
            }
            return _Emitter;
        }

        ITextEmitter Emitter
        {
            [MethodImpl(Inline)]
            get => GetEmitter();
        }

        public void Dispose()
        {
            if(_Emitter != null)
            {
                _Emitter.Flush();
                _Emitter.Dispose();
            }
        }

        object WriterLock = new();

        object CreateLock = new();

        public readonly FS.FilePath Path;

        readonly bool Overwrite;

        internal ProjectLog(FS.FilePath dst, bool overwrite)
        {
            Overwrite = overwrite;
            Path = dst;
        }

        public void Flush()
        {
            lock(WriterLock)
            {
                if(_Emitter != null)
                    _Emitter.Flush();
            }
        }

        public void AppendLine()
        {
            lock(WriterLock)
                Emitter.WriteLine();
        }

        public void AppendLine(object content)
        {
            lock(WriterLock)
                Emitter.AppendLine(content);
        }

        public void AppendLineFormat(string pattern, params object[] args)
        {
            lock(WriterLock)
                Emitter.AppendLineFormat(pattern, args);
        }
    }
}