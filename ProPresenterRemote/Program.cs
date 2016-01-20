using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            
            Trace.Listeners.Add(new TextWriterTraceListener("Log.txt"));
            Trace.AutoFlush = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e != null)
            {
                WriteError(e.ExceptionObject as Exception);
            }
        }

        static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e != null)
            {
                WriteError(e.Exception);
            }
        }


        /// <summary>
        /// Logs exception to error log
        /// </summary>
        /// <param name="exception"></param>
        static public void WriteError(Exception exception)
        {
            if (exception == null)
                return;

            Trace.TraceError(
                Environment.NewLine +
                String.Format("Date: {0:d} {0:T}", DateTime.Now) +
                Environment.NewLine +
                exception.Format());
        }

        /// <summary>
        /// Returns formated string with all inner exceptions and stack trace
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        static internal string Format(this Exception exception)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(CompileMessage(exception));

            Exception current = exception;
            while (current.InnerException != null)
            {
                message.AppendLine(new String('=', 80));
                message.AppendLine(CompileMessage(current));
                message.AppendLine();

                current = current.InnerException;
            }

            return message.ToString();
        }

        /// <summary>
        /// Concat message and stack trace
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        static private string CompileMessage(Exception exception)
        {
            return String.Concat(
                exception.Message,
                Environment.NewLine,
                exception.StackTrace);
        }
    }
}
