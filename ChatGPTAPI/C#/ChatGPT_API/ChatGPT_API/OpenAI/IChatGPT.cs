using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API.OpenAI
{
    public interface IChatGPT
    {
        /// <summary>
        /// 聊天對話(記錄上下文)
        /// </summary>
        string Chat(string userMessage);

        /// <summary>
        /// 單獨對話
        /// </summary>
        string Chat_Single(string userMessage);

        /// <summary>
        /// 重置對話
        /// </summary>
        void Reset();

        /// <summary>
        /// 設定 API 金鑰
        /// </summary>
        void Setting_APIKey(string apiKey);

        /// <summary>
        /// 設定SystemMessage
        /// </summary>
        void Setting_SystemMessage(string message);

    }
}
