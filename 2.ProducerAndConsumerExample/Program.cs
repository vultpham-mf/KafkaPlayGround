using _2.ProducerAndConsumerExample.Consumers;
using _2.ProducerAndConsumerExample.Producers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddProducer();
builder.Services.AddConsumer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

TriggerProducerApi.Map(app);

app.Run();
