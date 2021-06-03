using ChurrascoApi.Context;
using ChurrascoApi.Models;
using ChurrascoApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrascoApi.Service
{
    public class ChurrascoService
    {
        private ChurrascoContext _context;

        public ChurrascoService(ChurrascoContext context)
        {
            _context = context;
        }

        #region Churrasco
        public ChurrascoModel addChurrasco(ChurrascoModel churrascoModel)
        {
            return this._context.Create(churrascoModel);
        }

        public List<ChurrascoModel> getChurrascos()
        {
            return this._context.GetChurrascos();
        }

        public void updateChurrasco(ChurrascoModel churrasco)
        {
            this._context.Update(churrasco);
        }

        public void deleteChurrasco(ChurrascoModel churrasco)
        {
            this._context.Remove(churrasco);
        }

        public List<ChurrascoDTO> getAllChurrascoIntegrantes()
        {
            List<ChurrascoDTO> churrascosDTO = new List<ChurrascoDTO>();
            List<ChurrascoModel> churrascos = this._context.GetChurrascos();
            List<IntegranteChurrascoModel> integrantes = this._context.GetIntegrantes();
            foreach (ChurrascoModel churrasco in churrascos)
            {
                ChurrascoDTO churrascoDTO = new ChurrascoDTO()
                {
                    Id = churrasco.Id,
                    Data = churrasco.Data,
                    Descricao = churrasco.Descricao,
                    ObservacoesAdicionais = churrasco.ObservacoesAdicionais,
                    Integrantes = integrantes.Where(w => w.ChurrascoId == churrasco.Id).ToList()
                };

                churrascosDTO.Add(churrascoDTO);
            }

            return churrascosDTO;
        }
        #endregion

        #region Integrante
        public IntegranteChurrascoModel addIntegrante(IntegranteChurrascoModel integrante)
        {
            return this._context.Create(integrante);
        }
        public List<IntegranteChurrascoModel> getIntegrantes()
        {
            return this._context.GetIntegrantes();
        }

        public void updateIntegrante(IntegranteChurrascoModel integrante)
        {
            this._context.Update(integrante);
        }

        public void deleteIntegrante(IntegranteChurrascoModel integrante)
        {
            this._context.Remove(integrante);
        }
        #endregion
    }
}
