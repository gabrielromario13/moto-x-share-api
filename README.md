## How to use:

- You'll need to install RabbitMQ and PostgreSQL.

**Enviroment**

- [RabbitMQ](https://www.rabbitmq.com/docs/download)
  - By default, application connect to http://localhost:15672
- [PostgreSQL](https://www.postgresql.org/download/)
  - Connection string configured on appsettings.json
  - Migrations will be applied when you start the application

## How to authenticate:

- There's two default users in the application:
  - ("admin@admin.com", "Admin!1")
  - ("user@user.com", "User!1")
- To authenticate you just have to login here: (if you want to use cookies instead of a token, just set the prop "useCookies" to true)
  - ![image](https://github.com/gabrielromario13/moto-x-share-api/assets/50808281/a64a2f08-68a0-4886-90a7-2df37455780c)
- And paste the generated token here: (don't forget to add "Bearer" before the token)
  - ![image](https://github.com/gabrielromario13/moto-x-share-api/assets/50808281/bb9aea26-4b39-420f-8392-b75a966da161)


## Implemented technologies:

- .NET Core 8
- Entity Framework Core
- RabbitMQ
- FluentValidation
- Swagger

## Architecture:

- SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Identity authetication
- Notification filter middleware
- Messaging
