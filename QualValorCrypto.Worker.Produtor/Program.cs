using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Worker.Produtor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Enviando mensagens para o Rabbit **********");

            var produtorRabbitMq = new ClienteRabbitMqProdutor();
            
            var bitcoin = new CryptoMoeda("154654879879456", "Bitcoin", new decimal(656598.82));
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