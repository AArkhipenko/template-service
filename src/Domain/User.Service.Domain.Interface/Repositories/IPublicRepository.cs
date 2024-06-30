using User.Service.Domain.Interface.Models;

namespace User.Service.Domain.Interface.Repositories
{
	/// <summary>
	/// Репозяторий для работы с базовыми таблицами
	/// </summary>
    public interface IPublicRepository
	{
		/// <summary>
		/// Простое создание пользователя
		/// </summary>
		/// <param name="code">электронная почта</param>
		/// <returns><see cref="Category"/></returns>
		Task<Category> FindCategoryByCodeAsync(string code);
    }
}
