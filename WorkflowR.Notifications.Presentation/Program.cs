using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;
using WorkflowR.Notifications.Infrastructure.IoC;
using WorkflowR.Notifications.Application.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddOptions(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("sendmessage", (IMessageBrokerProducer msgProducer) =>
{
    msgProducer.Publish("TEST");
});

app.Run();