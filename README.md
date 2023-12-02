# Exkyn Send

Projeto destinado a envio de mensagens.

Atualmente está liberado apenas o envio de mensagens por e-mail.


## Instalação

Você pode instalar esse projeto pelo Nuget

```bash
  dotnet add package Exkyn.Send --version 8.0.0
```
    
## Exemplo de Uso

```c#
using Exkyn.Send.Email;

//Cria a configuração do e-mail que enviara as mensagens
var configuration = new SendingEmailConfiguration("remetente@email.com.br", "senha_email_remetente");

var sendEmail = new Send.Email.Send(configuration);

//Envia o e-mail
sendEmail.SendEmail("destinatario@email.com.br", "Assunto da mensagem", "Mensagem que deseja enviar.");
```


## Autores

- [@Daniel Moura](https://github.com/dmodesigner)


## Licença

Esse projeto pode ser usado de forma livre. É oferecido sobre a Licença [MIT](https://github.com/dmodesigner/Exkyn.Send/blob/main/LICENSE.txt)