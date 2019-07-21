using MongoTest.DomainModel;
using MongoTest.Repository;
using System;

namespace MongoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongoUri = "mongodb://localhost:32769";
            var mongoDatabaseName = "Teste";
            var context = new MongoContext(mongoUri, mongoDatabaseName);
            PersistenceMongoDB.Configure();
            var uow = new UnitOfWork(context);
            var vigenciaRepository = new VigenciaRepository(context);

            //var vigenciaId = Guid.NewGuid();
            //var vigenciaInicio = new DateTime(2019, 1, 1);
            //var vigenciaTermino = vigenciaInicio.AddDays(250);
            //var vigenciaNome = "Teste";

            //var vigencia = new Vigencia(vigenciaId, vigenciaInicio, vigenciaTermino, vigenciaNome);
            //vigencia.AdicionarFaixa(0, 100);
            //vigencia.AdicionarFaixa(101, 500);
            //vigencia.AdicionarFaixa(501, 2000);

            //vigenciaRepository.Add(vigencia);

            //var commited = uow.Commit()
            //    .GetAwaiter()
            //    .GetResult();

            //Console.WriteLine($"Commited: {commited}");

            var guid = Guid.Parse("b5be40f9-c3e2-2c43-a3d9-c3549f14a011");

            var vigencia2 = vigenciaRepository.GetById(guid)
                .GetAwaiter()
                .GetResult();

            Console.WriteLine("Pressione qq tecla para sair...");
            Console.Read();
        }
    }
}
