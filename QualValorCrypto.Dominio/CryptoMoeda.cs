using MongoDB.Bson;

namespace QualValorCrypto.Dominio
{
    public class CryptoMoeda : Entity
    {
        public decimal Valor { get; set; }
        public string Nome { get; set; }
        
        public CryptoMoeda(ObjectId id, string nome, decimal valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }        
    }
}