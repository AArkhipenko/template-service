using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Net.Http.Json;
using User.Service.Application.V10.Registration.DTO;
using User.Service.Domain.Interface.Repositories;
using Xunit.Abstractions;
using Controller = User.Service.API.Controllers.V10.ExampleController;

namespace User.Service.API.Tests.Controllers.V10.ExampleController
{
	/// <summary>
	/// Тесты на метод <see cref="Controller.GetAsync(CancellationToken)"/>
	/// </summary>
    public class SignUpAsyncTests : TestBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SignUpAsyncTests"/> class.
		/// </summary>
		/// <param name="testOutputHelper"><see cref="ITestOutputHelper"/></param>
		public SignUpAsyncTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

		/// <summary>
		/// Корректное выполнение АПИ
		/// </summary>
		/// <returns>OK</returns>
		[Fact]
		public async Task It_should_return_new_user_id()
		{
			// Настройки приложения
			var request = new SignUpRequestDTO
			{
				Email = "null@null.null",
				Password = "password"
			};
			var testClient = CreateClient(ConfigureService);

			// Выполнение запроса
			var response = await testClient.PostAsJsonAsync<SignUpRequestDTO>("/registration/v10/sign-up", request);

			// Тесты результата
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			var userId = await response.ReadAsJsonAsync<int>();

			Assert.True(userId > 0);
		}

		/// <summary>
		/// Конфигурирование сервиса
		/// </summary>
		/// <param name="services">хранилище DI</param>
		private void ConfigureService(IServiceCollection services)
		{
			var userRepositoryMock = new Mock<IUserRepository>();
			userRepositoryMock
				.Setup(x => x.SimpleCreateUserAsync(It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync(1);

			services.AddSingleton(userRepositoryMock.Object);
		}
    }
}
