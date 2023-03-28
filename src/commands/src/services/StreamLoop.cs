
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class StreamLoop : RunLoop<StreamLoop>
    {
        Thread Control;

        StreamReader Reader;

        StreamWriter Writer;

        CancellationToken Cancel;

        bool Running;

        IWfChannel Channel;

        public void Init(StreamReader reader, StreamWriter writer, CancellationToken cancel)
        {
            Reader = reader;
            Writer = writer;
            Cancel = cancel;
            Control = new Thread(Run);
        }

        public void Stop()
        {
            Running = false;
        }

        public void Start(IWfChannel channel)
        {
            Channel = channel;
            Running = true;
            Control.Start();
        }

        string ReadLine()
        {
            var result = EmptyString;
            try
            {
                Channel.Babble("Reading line");
                result = Reader.ReadLine();
                Channel.Babble($"Read line {result}");
            }
            catch (OperationCanceledException)
            {
                Running = false;
            }
            catch(Exception e)
            {
                term.error(e);
                Running = false;
            }
            return result;
        }

        public void WriteLine(string src)
        {
            try
            {
                Writer.WriteLine();
                Writer.Flush();
            }
            catch (OperationCanceledException)
            {
                Running = false;
            }
            catch(Exception e)
            {
                term.error(e);
                Running = false;
            }
        }

        void Run()
        {
            while(Running)
            {
                var line = ReadLine();
                if (sys.nonempty(line))
                    WriteLine(line);
            }
        }

    }
}