using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class FileLogger : ILogger
    {
        //private readonly object _lock = new object();
        //private ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        public async Task Log(string message)
        {
            await _semaphore.WaitAsync();
            try
            {
                await using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\log.txt"))
                {
                    await sw.WriteLineAsync(message);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
