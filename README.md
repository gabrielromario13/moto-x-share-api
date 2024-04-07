## How to use:

- You will need to install RabbitMQ and PostgreSQL.

**Enviroment**

- [RabbitMQ](https://www.rabbitmq.com/docs/download)
  - By default, application connect to http://localhost:15672
- [PostgreSQL](https://www.postgresql.org/download/)
  - Connection string configured on appsettings.json
  - Migrations will be applied when you run the application

## Implemented technologies:

- .NET Core 8
- Entity Framework Core
- RabbitMQ
- FluentValidation
- Swagger

## Architecture:

- SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Notification filter middleware
- Messaging
