using MongoTest.Repository;
using System;
using System.Collections.Generic;

namespace MongoTest.DomainModel
{
    public class Vigencia : IEntity<Vigencia>
    {
        protected List<FaixaValor> faixaValores;
        
        public Vigencia(Guid id, 
            DateTime inicio,
            DateTime termino, 
            string nome,
            IEnumerable<FaixaValor> faixas = null)
        {
            Inicio = inicio;
            Termino = termino;
            Nome = nome;
            Id = id;
            faixaValores = new List<FaixaValor>();

            if (faixas != null)
            {
                foreach (var faixa in faixas)
                {
                    AdicionarFaixa(faixa.ValorInicial, faixa.ValorFinal);
                }
            }
        }

        public int? Version { get; set; }
        public DateTime Inicio { get; protected set; }
        public DateTime Termino { get; protected set; }
        public string Nome { get; protected set; }
        public Guid Id { get; protected set; }
        public IReadOnlyCollection<FaixaValor> Valores => faixaValores;
            
        public void AdicionarFaixa(decimal valorInicial, 
            decimal valorFinal)
        {
            var faixa = new FaixaValor(valorInicial, valorFinal);
            faixaValores.Add(faixa);
        }
    }
}
