using Asp.Versioning;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Service.Application.V10.Example.Queries;
using User.Service.Application.V10.Registration.Commands;
using User.Service.Application.V10.Registration.DTO;
using User.Service.Domain.Core.Exceptions;

namespace User.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер регистрации и аутентификации пользователей
	/// </summary>
    [ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("registration/v{version:apiVersion}")]
	public class RegistrationController : ApiBaseController
    {
		private readonly IMediator _mediator;
		private readonly IValidator<SignUpRequestDTO> _signUpValidator;

		/// <summary>
		/// Initializes a new instance of the <see cref="RegistrationController"/> class.
		/// </summary>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="signUpValidator">валидатор для <see cref="SignUpRequestDTO"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public RegistrationController(
			IMediator mediator,
			IValidator<SignUpRequestDTO> signUpValidator,
			ILogger<RegistrationController> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor)
        {
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
			this._signUpValidator = signUpValidator ?? throw new ArgumentNullException(nameof(signUpValidator));
		}

		/// <summary>
		/// Ргеистрация пользователя
		/// </summary>
		/// <param name="request"><see cref="SignUpRequestDTO"/></param>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>ИД созданного пользователя</returns>
		[HttpPost("sign-up")]
        public async Task<ActionResult<int>> SignUpAsync(
			[FromBody] SignUpRequestDTO request,
			CancellationToken cancellationToken = default)
        {
			using(_ = base.BeginLoggingScope())
			{
				if (request == null)
				{
					throw new BadRequestException("Отсутствует запрос");
				}

				var validationResult = await this._signUpValidator.ValidateAsync(request, cancellationToken);
				if(!validationResult.IsValid)
				{
					throw new BadRequestException(string.Join("; ", validationResult.Errors.Select(x => x.ErrorMessage)));
				}

				var result = await this._mediator.Send(new SignUpCommand(request.Email, request.Password), cancellationToken);
				return Ok(result);
			}
		}
	}
}