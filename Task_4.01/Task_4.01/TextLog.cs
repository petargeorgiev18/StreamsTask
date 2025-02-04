using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._01
{
    public class TextLog:ILog
    {
        private StringBuilder logContent;
        public TextLog()
        {
            logContent = new StringBuilder();
        }
        public void Log(string message)
        {
            logContent.AppendLine(message);
        }
        public void SaveLog(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, logContent.ToString());
                Console.WriteLine($"Log saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving log: {ex.Message}");
            }
        }
        public string GetLog()
        {
            return logContent.ToString();
        }
    }
}
