import openai

openai.api_key = ""  # API的密鑰
model_id = 'gpt-3.5-turbo'  # 使用的模型編號
conversation = [
    {"role": "system", "content": "Assistant is a large language model trained by OpenAI."},
]  # 對話紀錄的總和 AI承接上下文連貫的對話

while True:
    message = input('What do you want to say?')

    conversation.append({"role": "user", "content": message})

    response = openai.ChatCompletion.create(
        model=model_id,
        messages=conversation,
    )

    conversation.append(response['choices'][0].message)

    print(f"{response['choices'][0].message.content}\n")
