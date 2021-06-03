using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrascoApi.Models.DTO
{
    public class ChurrascoDTO
    {
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string ObservacoesAdicionais { get; set; }
        public List<IntegranteChurrascoModel> Integrantes { get; set; }

        public ChurrascoDTO()
        {
            Integrantes = new List<IntegranteChurrascoModel>();
        }
    }
}
