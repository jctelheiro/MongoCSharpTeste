using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoTest.DomainModel;

namespace MongoTest
{
    public static class PersistenceMongoDB
    {
        public static void Configure()
        {
            var decimalPadrao = new Decimal128(0m);
            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));

            BsonClassMap.RegisterClassMap<FaixaValor>(map =>
            {
                map.AutoMap();
                map.MapCreator(f => new FaixaValor(f.ValorInicial, f.ValorFinal));
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.ValorInicial).SetIsRequired(true).SetDefaultValue(decimalPadrao);
                map.MapMember(x => x.ValorFinal).SetIsRequired(true).SetDefaultValue(decimalPadrao);
            });

            BsonClassMap.RegisterClassMap<Vigencia>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapCreator(v => new Vigencia(v.Id, v.Inicio, v.Termino, v.Nome, null));
                map.MapIdMember(x => x.Id).SetIdGenerator(GuidGenerator.Instance);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Inicio).SetIsRequired(true);
                map.MapMember(x => x.Termino).SetIsRequired(true);
                map.MapProperty(x => x.Version);
                map.MapField("faixaValores").SetElementName("Valores");
            });
        }
    }
}
