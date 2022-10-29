//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static sys;

    public class FileSplitter : AppService<FileSplitter>
    {
        public Outcome<FileSplitInfo> Run(FileSplitSpec spec)
        {
            var writer = default(StreamWriter);
            try
            {
                var flow = Channel.Running();
                using var reader = spec.SourcePath.Reader(spec.TargetEncoding);
                var paths = list<FilePath>();
                var subcount = 0u;
                var linecount = 0u;
                var splitcount = 0u;
                var emptycount = 0;
                var emptylimit = 5;
                var path = NextPath(spec, ref splitcount);
                paths.Add(path);
                writer = path.Writer(spec.TargetEncoding);
                var emitting = Wf.EmittingFile(path);
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if(text.empty(line))
                        emptycount++;
                    else
                        emptycount = 0;

                    if(emptycount > emptylimit)
                        continue;

                    writer.WriteLine(line);
                    subcount++;
                    if(subcount >= spec.MaxLineCount)
                    {
                        writer.Flush();
                        writer.Dispose();
                        Wf.EmittedFile(emitting, subcount);
                        path = NextPath(spec, ref splitcount);
                        paths.Add(path);
                        writer = path.Writer(spec.TargetEncoding);
                        linecount += subcount;
                        subcount = 0;
                        emitting = Wf.EmittingFile(path);
                    }
                }

                Wf.Ran(flow);
                return new FileSplitInfo(spec, paths.ToArray(), linecount);
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return e;
            }
            finally
            {
                writer.Flush();
                writer.Dispose();
            }
        }

        FilePath NextPath(in FileSplitSpec spec, ref uint part)
            => (spec.TargetDir + spec.SourcePath.FileName.WithoutExtension + FS.ext(string.Format("{0:D3}{1}", part++, spec.SourcePath.FileName.FileExt)));
    }
}