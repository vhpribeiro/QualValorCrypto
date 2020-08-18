using System;
using System.Text;
using RabbitMQ.Client;

namespace QualValorCrypto.Worker.Produtor
{
    public class ClienteRabbitMqProdutor
    {
        private const string UrlRabbitMq = "amqp://guest:guest@localhost:5672";
        private const string NomeDaFila = "RabbitMq-NetCore31-POC";
        private readonly IModel _modelo;

        public ClienteRabbitMqProdutor()
        {
            var conexao = CriarConexao();
            _modelo = conexao.CreateModel();
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

        public void Publicar(string mensagem)
        {
            ConfigurarFila(NomeDaFila, _modelo);
            _modelo.BasicPublish("", NomeDaFila, null, Encoding.UTF8.GetBytes(mensagem));
        }
    }
}