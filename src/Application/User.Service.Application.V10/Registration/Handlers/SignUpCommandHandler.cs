using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using User.Service.Application.V10.Registration.Commands;
using User.Service.Domain.Core.Exceptions;
using User.Service.Domain.Core.Logging;
using User.Service.Domain.Interface.Repositories;

namespace User.Service.Application.V10.Registration.Hadlers
{
	/// <summary>
	/// Выполнение <see cref="SignUpCommand"/>
	/// </summary>
	internal class SignUpCommandHandler : LoggerWrapper, IRequestHandler<SignUpCommand, Unit>
	{
		private readonly IUserRepository _userRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="SignUpCommandHandler"/> class.
		/// </summary>
		/// <param name="userRepository"><see cref="IUserRepository"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public SignUpCommandHandler(
			IUserRepository userRepository,
			ILogger<SignUpCommandHandler> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor)
		{
			this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		/// <inheritdoc/>
		public async Task<Unit> Handle(SignUpCommand request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				await this._userRepository.SimpleCreateUserAsync(request.Email, request.Password);
				return Unit.Value;
			}
		}
	}
}
