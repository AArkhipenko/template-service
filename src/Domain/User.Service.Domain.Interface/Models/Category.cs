using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Service.Domain.Interface.Models
{
	/// <summary>
	/// Категория элемента словаря
	/// </summary>
	public class Category
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Category"/> class.
		/// </summary>
		/// <param name="id"><inheritdoc cref="Id" path="/summary"/></param>
		/// <param name="code"><inheritdoc cref="Code" path="/summary"/></param>
		public Category(int id, string code)
		{
			this.Id = id;
			this.Code = code;
		}

		/// <summary>
		/// Ид записи
		/// </summary>
		public int Id { get; }

		/// <summary>
		/// Код категории
		/// </summary>
		public string Code { get; }
	}
}
