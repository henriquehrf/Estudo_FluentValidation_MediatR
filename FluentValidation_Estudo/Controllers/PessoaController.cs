using FluentValidation_Estudo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FluentValidation_Estudo.Controllers
{
	[ApiController]
	[Route("/api/pessoas")]
	public class PessoaController : Controller
	{

		private readonly ILogger<PessoaController> _logger;

		public PessoaController(ILogger<PessoaController> logger)
		{
			_logger = logger;
		}

		[HttpPost("inserir")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PessoaViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult InserirPessoa(PessoaViewModel pessoaVm)
		{
			try
			{
				return Created(nameof(InserirPessoa), pessoaVm);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
			}

			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
}
