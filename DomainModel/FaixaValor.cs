namespace MongoTest.DomainModel
{
    public class FaixaValor
    {
        public FaixaValor(decimal valorInicial, 
            decimal valorFinal)
        {
            ValorInicial = valorInicial;
            ValorFinal = valorFinal;
        }

        public decimal ValorInicial { get; protected set; }
        public decimal ValorFinal { get; protected set; }
    }
}
