using MongoTest.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoTest.Repository
{
    public class VigenciaRepository : BaseRepository<Vigencia>, IVigenciaRepository
    {
        public VigenciaRepository(IMongoContext context) 
            : base(context)
        {
        }
    }
}
