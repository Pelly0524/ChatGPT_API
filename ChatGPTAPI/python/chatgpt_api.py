import openai

api_key = ""
model_id = 'text-davinci-003'

openai.api_key = api_key

while True:
    message = input("What do you want to say?")

    response = openai.Completion.create(
        engine=model_id,
        prompt=message,
        temperature=0.7,
        top_p=0.9,
        max_tokens=100,
    )

    print(f'{response["choices"][0]["text"]}\n')
