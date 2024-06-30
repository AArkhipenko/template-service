using FluentValidation.TestHelper;
using User.Service.Application.V10.Registration.DTO;
using User.Service.Application.V10.Registration.Validators;

namespace User.Service.Application.V10.Tests.Registration.Validators
{
	/// <summary>
	/// Тесты на <see cref="SignUpRequestValidator"/>
	/// </summary>
    public class SignUpRequestValidatorTests
    {
		private readonly SignUpRequestValidator _validator;

		/// <summary>
		/// Initializes a new instance of the <see cref="SignUpRequestValidatorTests"/> class.
		/// </summary>
		public SignUpRequestValidatorTests()
		{
			this._validator = new SignUpRequestValidator();
		}

		/// <summary>
		/// Все параметры заданы корректно
		/// Ошибок нет
		/// </summary>
		[Fact]
		public void It_should_return_no_errors()
		{
			// Arrange
			var request = new SignUpRequestDTO
			{
				Email = "null@null.null",
				Password = "password"
			};

			// Act
			var response = _validator.TestValidate(request);

			// Assert
			response.ShouldNotHaveAnyValidationErrors();
		}

		/// <summary>
		/// Не заполнена электронная почта
		/// Ошибок заполнения входных параметров
		/// </summary>
		/// <param name="email">электронная почта</param>
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void It_should_return_error_for_email_by_completion(string email)
		{
			// Arrange
			var request = new SignUpRequestDTO
			{
				Email = email,
				Password = "password"
			};

			// Act
			var response = _validator.TestValidate(request);

			// Assert
			response.ShouldHaveValidationErrorFor(x => x.Email);
		}

		/// <summary>
		/// Электронная почта не соответствует шаблону
		/// Ошибок заполнения входных параметров
		/// </summary>
		/// <param name="email">электронная почта</param>
		[Theory]
		[InlineData("null@null")]
		[InlineData("null.null")]
		public void It_should_return_error_for_email_by_template(string email)
		{
			// Arrange
			var request = new SignUpRequestDTO
			{
				Email = email,
				Password = "password"
			};

			// Act
			var response = _validator.TestValidate(request);

			// Assert
			response.ShouldHaveValidationErrorFor(x => x.Email);
		}

		/// <summary>
		/// Не заполнен пароль
		/// Ошибок заполнения входных параметров
		/// </summary>
		/// <param name="password">пароль</param>
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void It_should_return_error_for_password_by_completion(string password)
		{
			// Arrange
			var request = new SignUpRequestDTO
			{
				Email = "null@null.null",
				Password = password
			};

			// Act
			var response = _validator.TestValidate(request);

			// Assert
			response.ShouldHaveValidationErrorFor(x => x.Password);
		}

		/// <summary>
		/// Пароль имеет длину менее 8 симоволов
		/// Ошибок заполнения входных параметров
		/// </summary>
		/// <param name="password">пароль</param>
		[Theory]
		[InlineData("1234567")]
		public void It_should_return_error_for_password_by_template(string password)
		{
			// Arrange
			var request = new SignUpRequestDTO
			{
				Email = "null@null.null",
				Password = password
			};

			// Act
			var response = _validator.TestValidate(request);

			// Assert
			response.ShouldHaveValidationErrorFor(x => x.Password);
		}
	}
}
