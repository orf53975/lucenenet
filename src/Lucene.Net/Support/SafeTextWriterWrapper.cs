﻿using System;
using System.IO;
#if !NETSTANDARD
using System.Runtime.Remoting;
#endif
using System.Text;
using System.Threading.Tasks;

namespace Lucene.Net.Support
{
    /// <summary>
    /// Decorates a <see cref="TextWriter"/> instance and
    /// makes no assumptions about whether <see cref="IDisposable.Dispose"/>
    /// has been called on the inner instance or not. Acts like a circuit breaker -
    /// the first <see cref="ObjectDisposedException"/> caught turns it off and
    /// the rest of the calls are ignored after that point until <see cref="Reset"/>
    /// is called.
    /// <para/>
    /// The primary purpose is for using a <see cref="TextWriter"/> instance within a non-disposable
    /// parent object. Since the creator of the <see cref="TextWriter"/> ultimately is responsible for
    /// disposing it, our non-disposable object has no way of knowing whether it is safe to use the <see cref="TextWriter"/>.
    /// Wraping the <see cref="TextWriter"/> within a <see cref="SafeTextWriterWrapper"/> ensures the
    /// non-disposable object can continue to make calls to the <see cref="TextWriter"/> without raising
    /// exceptions (it is presumed that the <see cref="TextWriter"/> functionality is optional).
    /// </summary>
    public class SafeTextWriterWrapper : TextWriter
    {
        private readonly TextWriter textWriter;
        private bool isDisposed = false;

        public SafeTextWriterWrapper(TextWriter textWriter)
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException("textWriter");
            }

            this.textWriter = textWriter;
        }

        public override Encoding Encoding
        {
            get
            {
                return Run(() => textWriter.Encoding);
            }
        }

        public override IFormatProvider FormatProvider
        {
            get
            {
                return Run(() => textWriter.FormatProvider);
            }
        }

        public override string NewLine
        {
            get
            {
                return Run(() => textWriter.NewLine);
            }

            set
            {
                Run(() => textWriter.NewLine = value);
            }
        }

#if !NETSTANDARD
        public override void Close()
        {
            Run(() => textWriter.Close());
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return Run(() => textWriter.CreateObjRef(requestedType));
        }
#endif

        public override bool Equals(object obj)
        {
            return Run(() => textWriter.Equals(obj));
        }

        public override void Flush()
        {
            Run(() => textWriter.Flush());
        }

        public override Task FlushAsync()
        {
            return Run(() => textWriter.FlushAsync());
        }

        public override int GetHashCode()
        {
            return Run(() => textWriter.GetHashCode());
        }

#if !NETSTANDARD
        public override object InitializeLifetimeService()
        {
            return Run(() => textWriter.InitializeLifetimeService());
        }
#endif

        public override string ToString()
        {
            return Run(() => textWriter.ToString());
        }

        public override void Write(bool value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(char value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(char[] buffer)
        {
            Run(() => textWriter.Write(buffer));
        }

        public override void Write(char[] buffer, int index, int count)
        {
            Run(() => textWriter.Write(buffer, index, count));
        }

        public override void Write(decimal value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(double value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(float value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(int value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(long value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(object value)
        {
            Run(() => textWriter.Write(value));
        }

        public override void Write(string format, object arg0)
        {
            Run(() => textWriter.Write(format, arg0));
        }

        public override void Write(string format, object arg0, object arg1)
        {
            Run(() => textWriter.Write(format, arg0, arg1));
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            Run(() => textWriter.Write(format, arg0, arg1, arg2));
        }

        public override void Write(string format, params object[] arg)
        {
            Run(() => textWriter.Write(format, arg));
        }

        public override void Write(string value)
        {
            Run(() => textWriter.Write(value));
        }

        [CLSCompliant(false)]
        public override void Write(uint value)
        {
            Run(() => textWriter.Write(value));
        }

        [CLSCompliant(false)]
        public override void Write(ulong value)
        {
            Run(() => textWriter.Write(value));
        }

        public override Task WriteAsync(char value)
        {
            return Run(() => textWriter.WriteAsync(value));
        }

        public override Task WriteAsync(char[] buffer, int index, int count)
        {
            return Run(() => textWriter.WriteAsync(buffer, index, count));
        }

        public override Task WriteAsync(string value)
        {
            return Run(() => textWriter.WriteAsync(value));
        }

        public override void WriteLine()
        {
            Run(() => textWriter.WriteLine());
        }

        public override void WriteLine(bool value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(char value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(char[] buffer)
        {
            Run(() => textWriter.WriteLine(buffer));
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            Run(() => textWriter.WriteLine(buffer, index, count));
        }

        public override void WriteLine(decimal value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(double value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(float value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(int value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(long value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(object value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override void WriteLine(string format, object arg0)
        {
            Run(() => textWriter.WriteLine(format, arg0));
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            Run(() => textWriter.WriteLine(format, arg0, arg1));
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            Run(() => textWriter.WriteLine(format, arg0, arg1, arg2));
        }

        public override void WriteLine(string format, params object[] arg)
        {
            Run(() => textWriter.WriteLine(format, arg));
        }

        public override void WriteLine(string value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        [CLSCompliant(false)]
        public override void WriteLine(uint value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        [CLSCompliant(false)]
        public override void WriteLine(ulong value)
        {
            Run(() => textWriter.WriteLine(value));
        }

        public override Task WriteLineAsync()
        {
            return Run(() => textWriter.WriteLineAsync());
        }

        public override Task WriteLineAsync(char value)
        {
            return Run(() => textWriter.WriteLineAsync(value));
        }

        public override Task WriteLineAsync(char[] buffer, int index, int count)
        {
            return Run(() => textWriter.WriteLineAsync(buffer, index, count));
        }

        public override Task WriteLineAsync(string value)
        {
            return Run(() => textWriter.WriteLineAsync(value));
        }

        private void Run(Action method)
        {
            if (isDisposed) return;

            try
            {
                method();
            }
            catch (ObjectDisposedException)
            {
                isDisposed = true;
            }
        }

        private T Run<T>(Func<T> method)
        {
            if (isDisposed) return default(T);

            try
            {
                return method();
            }
            catch (ObjectDisposedException)
            {
                isDisposed = true;
                return default(T);
            }
        }

        public virtual void Reset()
        {
            isDisposed = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                textWriter.Dispose();
            }
        }
    }
}
