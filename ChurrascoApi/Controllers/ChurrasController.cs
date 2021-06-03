using ChurrascoApi.Context;
using ChurrascoApi.Models;
using ChurrascoApi.Models.DTO;
using ChurrascoApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrascoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurrasController : ControllerBase
    {
        private readonly ChurrascoContext _context;
        private ChurrascoService _service;

        public ChurrasController(ChurrascoContext context)
        {
            _context = context;
            this._service = new ChurrascoService(context);
        }

        #region Churraco
        /// <summary>
        /// Retorna todos os Churrascos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult getAllChurrasco()
        {
            try
            {
                List<ChurrascoModel> churrascos = this._service.getChurrascos();
                return Ok(churrascos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Adicionar um novo churrasco
        /// </summary>
        /// <param name="churrasco"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult addChurrasco(ChurrascoModel churrasco)
        {
            try
            {
                churrasco = this._service.addChurrasco(churrasco);
                return Ok(churrasco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um churrasco
        /// </summary>
        /// <param name="churrasco"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult updChurrasco(ChurrascoModel churrasco)
        {
            try
            {
                this._service.updateChurrasco(churrasco);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar um churrasco
        /// </summary>
        /// <param name="churrasco"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult dltChurraco(ChurrascoModel churrasco)
        {
            try
            {
                this._service.deleteChurrasco(churrasco);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public IActionResult getChurrascoIntegrantes()
        {
            try
            {
                return Ok(this._service.getAllChurrascoIntegrantes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Integrante
        /// <summary>
        /// Retorna todos os Integrantes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult getAllIntegrante()
        {
            try
            {
                List<IntegranteChurrascoModel> churrascos = this._service.getIntegrantes();
                return Ok(churrascos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Adicionar um novo integrante
        /// </summary>
        /// <param name="integrante"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult addIntegrante(IntegranteChurrascoModel integrante)
        {
            try
            {
                integrante = this._service.addIntegrante(integrante);
                return Ok(integrante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um integrante
        /// </summary>
        /// <param name="integrante"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult updIntegrante(IntegranteChurrascoModel integrante)
        {
            try
            {
                this._service.updateIntegrante(integrante);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar um integrante
        /// </summary>
        /// <param name="integrante"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult dltIntegrante(IntegranteChurrascoModel integrante)
        {
            try
            {
                this._service.deleteIntegrante(integrante);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}

