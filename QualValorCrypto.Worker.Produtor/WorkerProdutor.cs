using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QualValorCrypto.Infra.Mensageria.RabbitMq;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Worker.Produtor
{
    class WorkerProdutor
    {   
        static void Main()
        {
            var produtorRabbitMq = ClienteRabbitMqFactory.Criar();
            
            var bitcoin = new CryptoMoeda("154654879879456", "Bitcoin", new decimal(696598.82));
            var moedasParaSeremAtualizadas = new List<CryptoMoeda>
            {
                bitcoin
            };
            
            moedasParaSeremAtualizadas.ForEach(m =>
            {
                var mensagem = JsonConvert.SerializeObject(m);
                produtorRabbitMq.Publicar(mensagem);
            });

            Console.ReadKey();
        }
    }
}