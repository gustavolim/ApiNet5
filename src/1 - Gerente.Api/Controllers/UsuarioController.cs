using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gerente.Api.Uteis;
using Gerente.Api.ViewModels;
using Gerente.Core.Excecoes;
using Gerente.Servico.DTO;
using Gerente.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gerente.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServico usuarioServico, IMapper mapper)
        {
            _usuarioServico = usuarioServico;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<ActionResult<CriarUsuarioViewModel>> PostUsuario([FromBody] CriarUsuarioViewModel model)
        {
           try
           {
               var usuarioDTO = _mapper.Map<UsuarioDTO>(model);
               var criarUsuario = await _usuarioServico.Create(usuarioDTO);

               return Ok(new ResultViewModel
               {
                   Message = "Usuário criado com Sucesso!",
                   Success = true,
                   Data = criarUsuario
               });
           }
           catch (ExecoesDominio ex)
           {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
           }  
           catch (Exception)
           {
               
               return StatusCode(500, Responses.ApplicationErrorMessage());
           }  
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] EditarUsuarioViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UsuarioDTO>(userViewModel);

                var userUpdated = await _usuarioServico.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (ExecoesDominio ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUsuario(long id)
        {
            try
            {
                await _usuarioServico.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (ExecoesDominio ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarioId(long id)
        {
            try
            {
                var user = await _usuarioServico.Get(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o ID informado.",
                        Success = true,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (ExecoesDominio ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetListUsuario()
        {
            try
            {
                var allUsers = await _usuarioServico.GetList();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (ExecoesDominio ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetByEmailUsuario([FromQuery] string email)
        {
            try
            {
                var user = await _usuarioServico.GetEmail(email);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o email informado.",
                        Success = true,
                        Data = user
                    });


                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (ExecoesDominio ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetNomeUsuario([FromQuery] string name)
        {
            try
            {
                var allUsers = await _usuarioServico.GetListNome(name);

                if (allUsers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o nome informado",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (ExecoesDominio ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetEmailUsuario([FromQuery] string email)
        {
            try
            {
                var allUsers = await _usuarioServico.GetListEmail(email);

                if (allUsers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o email informado",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (ExecoesDominio ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

    }
}