using System;
using System.IO;

namespace Logger
{
    public class MemoryStreamLogger : IDisposable
    {
        private StreamWriter streamWriter;
        private bool IsDisposed = false;

        public MemoryStreamLogger()
        {
            streamWriter = new StreamWriter(path: @"log.txt", append: true);
        }

        public void Log(string message)
        {
            if (IsDisposed)
                throw new InvalidOperationException("Calling operation on object that is already disposed.");

            streamWriter.Write(message);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                    streamWriter.Dispose();
            }
            IsDisposed = true;
        }

        ~MemoryStreamLogger()
        {
            Dispose(false);
        }
    }
}