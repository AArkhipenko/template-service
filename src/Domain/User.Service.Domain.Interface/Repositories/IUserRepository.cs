namespace User.Service.Domain.Interface.Repositories
{
	/// <summary>
	/// Репозяторий для работы с пользователями
	/// </summary>
    public interface IUserRepository
    {
		/// <summary>
		/// Простое создание пользователя
		/// </summary>
		/// <param name="email">электронная почта</param>
		/// <param name="password">пароль</param>
		/// <returns><see cref="Task"/></returns>
		Task<int> SimpleCreateUserAsync(string email, string password);
    }
}
