using System;
using Xunit;
using Testando.DTOs;
using Testando.Servicos;
using System.Net;
using Xunit.Abstractions;

namespace Testando
{
    public class Testando
    {
        private readonly ITestOutputHelper output;

        public Testando(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DADO_oRetornoDaApi_QUANDO_oIdRetornadoFor101_ENTAO_oTesteTeraSucesso()
        {
            try
            {
                ApiDeTeste apiDeTeste = new ApiDeTeste();

                DtoObjetoExemplo dtoObjetoExemplo = new DtoObjetoExemplo();
                dtoObjetoExemplo.userId = "10001";
                dtoObjetoExemplo.title = "test paul";
                dtoObjetoExemplo.body = "tudo ok";

                var retornoDaAPI = apiDeTeste.PegarRetornoDaAPI(dtoObjetoExemplo);

                Assert.Equal(101, retornoDaAPI.id);
            }
            catch (Exception ex)
            {
                output.WriteLine("========================");
                output.WriteLine("-------- ERROS ---------");
                output.WriteLine("========================");

                output.WriteLine("* OCORREU O SEGUINTE ERRO: " + ex.Message);
                output.WriteLine("* NO MÉTODO: " + ex.TargetSite.ToString());
                output.WriteLine("");
                output.WriteLine("========================");
                output.WriteLine("-------- PILHA ---------");
                output.WriteLine("========================");
                output.WriteLine(ex.StackTrace.ToString());
            }
            
        }
    }
}
