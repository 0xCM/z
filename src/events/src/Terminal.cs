//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    /// <summary>
    /// Implements a thread-safe/thread-aware terminal abstraction
    /// </summary>
    public class Terminal
    {
        [MethodImpl(Inline)]
        public static Terminal Get()
            => JustTheOne;

        static readonly Terminal JustTheOne = new Terminal();

        readonly object TermLock;

        readonly object ErrLock;

        readonly object StdLock;

        Option<Action> TerminationHandler;

        Terminal()
        {
             TermLock = new object();
             ErrLock = new object();
             StdLock = new object();
             Console.OutputEncoding = new UnicodeEncoding();
             Console.CancelKeyPress += OnCancelKeyPressed;
        }

        /// <summary>
        /// Specifies the handler to invoke when the user enters a cancellation
        /// command, such as Ctrl+C
        /// </summary>
        /// <param name="handler">The handler to invoke when a termination command is received</param>
        public void SetTerminationHandler(Action handler)
            => TerminationHandler = handler;

        void OnCancelKeyPressed(object sender, ConsoleCancelEventArgs args)
            => TerminationHandler.OnSome(h => h());

        public void WriteLine()
        {
            lock(TermLock)
                Console.WriteLine();
        }

        /// <summary>
        /// Writes a single character to the console
        /// </summary>
        /// <param name="c">The char to emit</param>
        /// <param name="severity">The severity</param>
        public void WriteChar(char c, FlairKind? color = null)
            => Write(c, (color ?? FlairKind.Warning));

        public void WriteMessage(IAppMsg msg, FlairKind? color = null)
        {
            if(msg.Kind == LogLevel.Error)
                WriteError(msg);
            else
                WriteLine(msg, color ?? msg.Flair);
        }

        public void WriteLines<F>(params F[] src)
            where F : ITextual
        {
            lock(TermLock)
            {
                foreach(var item in src)
                    Console.WriteLine(item.Format());
            }
        }

        public void WriteLine<F>(F src, FlairKind color)
            where F : ITextual
        {
            lock(TermLock)
            {
                var current = Console.ForegroundColor;
                Console.ForegroundColor = (ConsoleColor)color;
                Console.WriteLine(src.Format());
                Console.ForegroundColor = current;
            }
        }

        public void WriteLines<F>(FlairKind color, params F[] src)
            where F : ITextual
        {
            lock(TermLock)
            {
                var current = Console.ForegroundColor;
                Console.ForegroundColor = (ConsoleColor)color;
                foreach(var msg in src)
                    Console.WriteLine(msg);
                Console.ForegroundColor = current;
            }
        }

        public void WriteMessages(IEnumerable<IAppMsg> messages)
        {
            var frozen = messages.Array();
            var count = frozen.Length;
            if(count != 0)
            {
                lock(TermLock)
                {
                    var revert = Console.ForegroundColor;
                    for(var i=0; i<count; i++)
                    {
                        var msg = frozen[i];
                        Console.ForegroundColor = (ConsoleColor)msg.Flair;
                        if(msg.IsError)
                            Console.Error.WriteLine(msg);
                        else
                            Console.WriteLine(msg);
                        Console.ForegroundColor = revert;
                    }
                }
            }
        }

        public string ReadLine()
            => Console.ReadLine();

        public string Prompt(object msg)
        {
            Write(msg, (FlairKind)ConsoleColor.Cyan);
            return Console.ReadLine();
        }

        public char ReadKey(IAppMsg msg = null)
        {
             if(msg != null)
                WriteMessage(msg);

            return Console.ReadKey().KeyChar;
        }

        void WriteLine(object src, FlairKind color)
        {
            lock(TermLock)
            {
                var current = Console.ForegroundColor;
                Console.ForegroundColor = (ConsoleColor)color;
                Console.WriteLine(src);
                Console.ForegroundColor = current;
            }
        }

        public void SetInputEncoding(Encoding e)
        {
            Console.InputEncoding = e;
        }

        public void SetOutputEncoding(Encoding e)
        {
            Console.OutputEncoding = e;
        }

        void WriteWarning(object src)
        {
            lock(TermLock)
            {
                var current = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(src);
                Console.ForegroundColor = current;
            }
        }

        public void Write(object src)
        {
            lock(TermLock)
                Console.Write(src);
        }

        public void Write(object src, FlairKind flair)
        {
            lock(TermLock)
                WriteNoLock(src, flair);
        }

        void WriteNoLock(object src, FlairKind flair)
        {
            var current = Console.ForegroundColor;
            Console.ForegroundColor = (ConsoleColor)flair;
            Console.Write(src);
            Console.ForegroundColor = current;
        }

        public void Write(params (object content, FlairKind flair)[] messages)
        {
            lock(TermLock)
                sys.iter(messages, msg => WriteNoLock(msg.content,msg.flair));
        }

        public void WriteError(IAppMsg src)
        {
            if(src == null)
            {
                var current = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Error message is null!");
                Console.ForegroundColor = current;
            }
            else
            {
                var rendered = src.Format();
                if(string.IsNullOrWhiteSpace(rendered))
                {
                    var current = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine("Error message is blank!");
                    Console.ForegroundColor = current;
                }
                else
                {
                    lock(TermLock)
                    {
                        var current = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Error.Write(src);
                        Console.Error.Write(Chars.Eol);
                        Console.ForegroundColor = current;
                    }
                }
            }
        }

        public void WriteLine(object sr)
            => WriteLine(sr, FlairKind.Status);

        public void Warn(string description)
            => WriteWarning((object)description);

        public void Info(string message)
            => WriteLine((object)message, FlairKind.Status);

        public void WriteLine(string message, FlairKind color)
            => WriteLine((object)message, color);
    }
}