
using Microsoft.AspNetCore.Mvc;

namespace DemoMicroService.ServiceOne.ServiceOne
{
    [Route("api/ServiceOne")]
    public class SOneController : ServiceOneController
    {
        private readonly RabbitMQEventBusProducer _eventBus;

        public SOneController(RabbitMQEventBusProducer eventBus)
        {
            _eventBus = eventBus;
        }
        [HttpPost]
        public void SendText(string queueName, string message)
        {
            _eventBus.PublishMessage(queueName, message);
        }

    }
}
