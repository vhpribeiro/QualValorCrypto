using System;
using System.Text;
using Newtonsoft.Json;
using QualValorCrypto.Aplicacao.CryptoMoedas.Comandos;
using QualValorCrypto.Dominio;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QualValorCrypto.Infra.Mensageria.RabbitMq
{
    public class ClienteRabbitMq
    {
        private const string UrlRabbitMq = "amqp://guest:guest@localhost:5672";
        private const string NomeDaFila = "RabbitMq-NetCore31-POC";
        private readonly IModel _modelo;
        private readonly IControleDeCryptoMoeda _controleDeCryptoMoeda;

        public ClienteRabbitMq(IControleDeCryptoMoeda controleDeCryptoMoeda)
        {
            var conexao = CriarConexao();
            _modelo = conexao.CreateModel();
            _controleDeCryptoMoeda = controleDeCryptoMoeda;
        }

        private static IConnection CriarConexao()
        {
            var conexaoFabrica = new ConnectionFactory
            {
                Uri = new Uri(UrlRabbitMq)
            };

            return conexaoFabrica.CreateConnection();
        }

        private static void ConfigurarFila(string nome, IModel modelo)
        {
            modelo.QueueDeclare(nome, false, false, false, null);
        }

        public void Consumir()
        {
            ConfigurarFila(NomeDaFila, _modelo);

            var consumidor = new EventingBasicConsumer(_modelo);
            consumidor.Received += (emissor, evento) =>
            {
                var corpo = evento.Body.ToArray();
                var mensagemDaFila = Encoding.UTF8.GetString(corpo);

                if (!string.IsNullOrWhiteSpace(mensagemDaFila))
                {
                    var cryptoMoeda = JsonConvert.DeserializeObject<CryptoMoeda>(mensagemDaFila);
                    _modelo.BasicAck(evento.DeliveryTag, true);
                    _controleDeCryptoMoeda.AtualizarCryptoMoeda(cryptoMoeda.Valor, cryptoMoeda.Nome);
                }
                
            };
            _modelo.BasicConsume(NomeDaFila, false, consumidor);
        }
        
        public void Publicar(string mensagem)
        {
            ConfigurarFila(NomeDaFila, _modelo);
            _modelo.BasicPublish("", NomeDaFila, null, Encoding.UTF8.GetBytes(mensagem));
        }
    }
}