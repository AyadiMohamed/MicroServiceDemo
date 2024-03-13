using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DemoMicroService.ServiceOne
{
    public class testEntity : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public testEntity(string name ) {
            Name = name;
        }
    }
}
