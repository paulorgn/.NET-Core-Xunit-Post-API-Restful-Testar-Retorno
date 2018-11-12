using System;
using Xunit;
using Testando.DTOs;
using Testando.Servicos;
using System.Net;

namespace Testando
{
    public class Testando
    {
        [Fact]
        public void DADO_oRetornoDaApi_QUANDO_oIdRetornadoFor101_ENTAO_oTesteTeraSucesso()
        {
            ApiDeTeste apiDeTeste = new ApiDeTeste();

            DtoObjetoExemplo dtoObjetoExemplo = new DtoObjetoExemplo();
            dtoObjetoExemplo.userId = "10001";
            dtoObjetoExemplo.title = "test paul";
            dtoObjetoExemplo.body = "tudo ok";

            var retornoDaAPI = apiDeTeste.PegarRetornoDaAPI(dtoObjetoExemplo);

            Assert.Equal(101, retornoDaAPI.id);
        }
    }
}
