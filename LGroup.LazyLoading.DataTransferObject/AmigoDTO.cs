using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGroup.LazyLoading.DataTransferObject
{
    public sealed class AmigoDTO
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public Int32 CodigoSexo { get; set; }
        public Int32 CodigoEstadoCivil { get; set; }

        public AmigoDTO()
        {
             
        }
        //Relacionamentos (Classes agregadas)
        private SexoDTO _sexo;
        public SexoDTO Sexo
        {
            get
            {
                if (_sexo == null)
                    _sexo = new SexoDTO();

                _sexo.Codigo = CodigoSexo;
                _sexo.Descricao = "Masculino";

                return _sexo; 
            }
        }
        private EstadoCivilDTO _civil;
        public EstadoCivilDTO EstadoCivil
        {
            get
            {
                if (_civil == null)
                    _civil = new EstadoCivilDTO();
                _civil.Codigo = CodigoEstadoCivil;
                _civil.Descricao = "Solteiro";
                return _civil;
            }
        }

        //Quando manipulamos CLASSES ou TABELAS se relacionam
        //Podemos trazer esses dados de 2 formas
        //Temos 1 classe ou tabela principal que chama classes ou tabelas
        //Relacionadas (secundarias)
        //Quando trazemos tudo de uma vez chamamos de EAGER LOADING
        //Carregamento Antecipado

        //Quando trazemos is dados secundario somente quando precisarmos, se chama
        //LAZY Loading
        //Carregamento tardio
        public IEnumerable<AmigoDTO> ListarAmigosEagerLoading()
        {
            var amigos = new List<AmigoDTO>();
            for (int i = 1; i <= 10; i++)
            {
                var amigo = new AmigoDTO();
                amigo.Nome = $"Erick {i}";
                amigo.Email = $"erick {i}@hotmail.com";
                amigo.CodigoSexo = 1;
                amigo.CodigoEstadoCivil = 1;

                //EAGER LOADING
                //Como a classe principal 'e a de AMIGO ja nos 
                //Antecipamos e trouxemos os dados das classes Relacionadas
                //  amigo.Sexo = new SexoDTO();
                amigo.Sexo.Codigo = 1;
                amigo.Sexo.Descricao = "Feminino";

                //amigo.EstadoCivil = new EstadoCivilDTO();
                amigo.EstadoCivil.Codigo = 1;
                amigo.EstadoCivil.Descricao = "Casado";

                amigos.Add(amigo);
            }
            return amigos;
        }
        public IEnumerable<AmigoDTO> ListarAmigosLazyLoading()
        {
            //O padrao LazyLoading Martin Fowler (2010)
            //A ideia 'e fazer os dados de tabelas ou classes relacionadas
            //Somente quando forem necessarios, nunca trazer tudo de uma vez
            //Cenario classico para aplicar o LAZY LOADING 'e atrav'es de Propriedades
            //somente com GET
            var amigos = new List<AmigoDTO>();
            for (int i = 1; i <= 10; i++)
            {
                //No LL s'o trazemos os dados da classe da tabela
                //Principal
                var amigo = new AmigoDTO();
                amigo.Nome = $"Erick {i}";
                amigo.Email = $"erick {i}@hotmail.com";
                amigo.CodigoSexo = 1;
                amigo.CodigoEstadoCivil = 1;

                amigos.Add(amigo);
            }
            return amigos;
        }
    }
}
