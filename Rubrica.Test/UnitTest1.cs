using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryMock;
using System;
using Xunit;

namespace Rubrica.Test
{
    public class UnitTest1
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new ContattiRepositoryMock(), new IndirizziRepositoryMock());

        [Fact]
        public void Test1()
        {
            string res = bl.InserisciNuovoContatto(new Contatto()
            {
                Nome = " Luca",
                Cognome = "Bianchi",

            });
            Assert.NotNull(res);
            Assert.Equal("Contatto aggiunto correttamente", res);
        }
    }
}

