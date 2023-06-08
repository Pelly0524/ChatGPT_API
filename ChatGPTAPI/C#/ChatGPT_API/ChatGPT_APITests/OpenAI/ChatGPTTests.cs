using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatGPT_API.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API.OpenAI.Tests
{
    [TestClass()]
    public class ChatGPTTests
    {
        [TestMethod()]
        public void ChatTest() // 測試一個簡單的對話
        {
            IChatGPT chatGPT = new ChatGPT();
            chatGPT.Setting_APIKey("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");
            string result = chatGPT.Chat_Single("Hello!This is a test message.Please just said \"Test Success!\" for my test.");
            if (result != "Test Success!")
                Assert.Fail();
        }
    }
}