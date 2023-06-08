using ChatGPT_API;
using ChatGPT_API.OpenAI;
using System;

IChatGPT chatGPT = new ChatGPT();

Console.WriteLine("請輸入多行文字，並以單獨的一行 '.' 來結束\n");

while (true)
{
    Console.Write("What do you want to say：\n");

    string userMessage = "";
    string? input = Console.ReadLine();
    while (input != ".")
    {
        userMessage += input + Environment.NewLine;
        input = Console.ReadLine();
    }

    string result = chatGPT.Chat(userMessage);

    Console.WriteLine($"ChatGPT:\n{result}\n");
}