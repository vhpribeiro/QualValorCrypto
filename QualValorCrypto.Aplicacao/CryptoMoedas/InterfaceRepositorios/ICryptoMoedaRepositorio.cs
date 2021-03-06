﻿using System.Threading.Tasks;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios
{
    public interface ICryptoMoedaRepositorio
    {
        public CryptoMoeda ObterPeloIdentificador(string id);
        public Task InserirItemAsync(CryptoMoeda item);
        public Task AtualizarValorPeloNomeAsync(decimal novoValor, string nomeDaMoeda);
    }
}