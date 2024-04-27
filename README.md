## How to use:

- You'll need to install RabbitMQ and PostgreSQL.

**Enviroment**

- [RabbitMQ](https://www.rabbitmq.com/docs/download)
  - By default, the application connect to http://localhost:15672
- [PostgreSQL](https://www.postgresql.org/download/)
  - Connection string is configured on appsettings.json
  - Migrations will be applied when you start the application

## Implemented technologies:

- .NET Core 8
- Entity Framework Core
- RabbitMQ
- FluentValidation
- Identity Authetication
- Swagger

## Architecture:

- SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Notification filter middleware
- Messaging
