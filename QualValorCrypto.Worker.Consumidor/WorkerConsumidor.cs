using System;
using QualValorCrypto.Infra.Mensageria.RabbitMq;

namespace QualValorCrypto.Worker.Consumidor
{
    class WorkerConsumidor
    {   
        static void Main()
        {
            var consumidorRabbitMq = ClienteRabbitMqFactory.Criar();
            consumidorRabbitMq.Consumir();

            Console.ReadKey();
        }
    }
}