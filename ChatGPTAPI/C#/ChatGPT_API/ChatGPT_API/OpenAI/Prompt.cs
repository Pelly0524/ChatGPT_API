using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API.OpenAI
{
    public struct Prompt
    {
        // 對話角色
        public ChatGPT_Role Role;
        // 對話內容
        public string Content;
    }

    public enum ChatGPT_Role
    {
        [Description("System")]
        system = 1,
        [Description("User")]
        user = 2,
        [Description("Assistant")]
        assistant = 3
    }
}
