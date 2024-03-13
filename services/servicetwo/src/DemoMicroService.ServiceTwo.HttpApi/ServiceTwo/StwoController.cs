using System;
using Microsoft.AspNetCore.Mvc;


namespace DemoMicroService.ServiceTwo.ServiceTwo
{
    [Route("api/ServiceTwo")]
    public class StwoController : ServiceTwoController
    {
        private readonly RabbitMQEventConsumer _eventConsumer;

        public StwoController(RabbitMQEventConsumer eventConsumer)
        {
            _eventConsumer = eventConsumer;
        }
        [HttpGet]
        public void DisplayText(string queueName)
        {
            _eventConsumer.ConsumeMessage(queueName, message => Console.WriteLine(message)); ;
        }
    }
}
