using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class FileLogger : ILogger
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        public async Task Log(BallJsonModel ball)
        {
            await _semaphore.WaitAsync();
            try
            {
                await using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + $"\\log.json"))
                {
                    Debug.WriteLine(DateTime.Now.Millisecond.ToString() + "   " + ball.Top);
                    await sw.WriteLineAsync(JsonSerializer.Serialize(ball));
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
