using LGroup.LazyLoading.DataTransferObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGroup.LazyLoading
{
    [TestFixture]
    public sealed class AmigoTest
    {
        [Test]
        public void Testar_Amigos_EagerLoading()
        {
            //O problema do EagerLoading (Mais classico do dia a dia)
            //'E a performance, trazemos dados muitas vezes desnecessarios
            //Nao vamos usar naquele momento mas trouxemos
            //Ja nos antecipamos
            var amigo = new AmigoDTO();
            var amigos = amigo.ListarAmigosEagerLoading();

        }

        [Test]
        public void Testar_Amigos_LazyLoading()
        {
            var amigo = new AmigoDTO();
            var amigos = amigo.ListarAmigosLazyLoading();

            var primeiroAmigo = amigos.First();

            //Neste momento buscamos os dados das tabelas, classes
            //Relacionadas
            var sexo = primeiroAmigo.Sexo;
            var civi = primeiroAmigo.EstadoCivil;


        }
        [Test]
        public void Testar_Variavel_LayLoading()
        {
            //Sempre que criamos uma variavel damos um New
            //Sempre que damos u new, ocupamos memoria RAM
            //Estamos consumindo memoria da maquina (pente de memoria)
            //a forma mais performatica do mundo para criar variaveis
            //E criar utilizando a classe LAZY (.NET 4.5)
            //LazyLoading de qualquer tipo de variavel

            //Enquanto nao usamos nada da classe 
            //ela nao 'e inicializada, nao sobe pra memoria
            //so pra quando usarmos alguma PROPRIEDADE e que ela sobe pra memoria

            var amigo = new Lazy<AmigoDTO>();
            var status = amigo.IsValueCreated;
            amigo.Value.Nome = "Zina";

            var status1 = amigo.IsValueCreated;
            
            
        }

    }
}
