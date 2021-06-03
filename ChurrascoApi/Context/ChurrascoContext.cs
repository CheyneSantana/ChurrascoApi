using ChurrascoApi.Interfaces;
using ChurrascoApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrascoApi.Context
{
    public class ChurrascoContext
    {
        private readonly IMongoCollection<ChurrascoModel> _churrasco;
        private readonly IMongoCollection<IntegranteChurrascoModel> _integrante;

        public ChurrascoContext(IChurrascostoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this._churrasco = database.GetCollection<ChurrascoModel>("Churrasco");
            this._integrante = database.GetCollection<IntegranteChurrascoModel>("IntegranteChurrasco");
        }
        #region Churrasco
        public List<ChurrascoModel> GetChurrascos() => this._churrasco.Find(f => true).ToList();

        public ChurrascoModel GetChurrasco(string id) => this._churrasco.Find<ChurrascoModel>(f => f.Id == id).FirstOrDefault();

        public ChurrascoModel Create(ChurrascoModel churrasco)
        {
            this._churrasco.InsertOne(churrasco);
            return churrasco;
        }

        public void Update(ChurrascoModel churrasco) => this._churrasco.ReplaceOne(r => r.Id == churrasco.Id, churrasco);

        public void Remove(ChurrascoModel churrasco) => this._churrasco.DeleteOne(d => d.Id == churrasco.Id);
        #endregion

        #region Integrante
        public List<IntegranteChurrascoModel> GetIntegrantes() => this._integrante.Find(f => true).ToList();

        public List<IntegranteChurrascoModel> GetIntegrantesByIdChurrasco(string id) => this._integrante.Find(f => f.ChurrascoId == id).ToList();

        public IntegranteChurrascoModel GetIntegrante(string id) => this._integrante.Find<IntegranteChurrascoModel>(f => f.Id == id).FirstOrDefault();

        public IntegranteChurrascoModel Create(IntegranteChurrascoModel integrante)
        {
            this._integrante.InsertOne(integrante);
            return integrante;
        }

        public void Update(IntegranteChurrascoModel integrante) => this._integrante.ReplaceOne(r => r.Id == integrante.Id, integrante);

        public void Remove(IntegranteChurrascoModel integrante) => this._integrante.DeleteOne(d => d.Id == integrante.Id);
        #endregion
    }
}
