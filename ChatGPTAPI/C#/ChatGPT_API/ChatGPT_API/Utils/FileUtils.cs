using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API.Utils
{
    public static class FileUtils
    {
        public static string ReadTextFromFile(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath), "文件路徑不能為空");
                }

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("找不到指定的文件", filePath);
                }

                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"讀取文件時出現錯誤：{ex.Message}");
                throw;
            }
        }
    }
}
