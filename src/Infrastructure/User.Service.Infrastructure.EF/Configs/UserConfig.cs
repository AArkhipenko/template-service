using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF.Configs
{
	/// <summary>
	/// Класс для конифгурирования <see cref="TableExt.User"/> 
	/// </summary>
	internal class UserConfig : IEntityTypeConfiguration<TableExt.User>
	{
		/// <summary>
		/// Конифгурирования <see cref="TableExt.User"/> 
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		public void Configure(EntityTypeBuilder<TableExt.User> builder)
		{
			builder.ToTable("user", "general");

			builder
				.Property<int>(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<int>(x => x.IdCategory)
				.HasColumnName("id_category")
				.IsRequired();

			builder
				.Property<string>(x => x.Code)
				.HasColumnName("code")
				.IsRequired();

			builder
				.Property<string>(x => x.Name)
				.HasColumnName("name")
				.IsRequired();

			builder
				.Property<DateTime>(x => x.Created)
				.HasColumnName("created")
				.ValueGeneratedOnAdd();

			builder
				.Property<DateTime>(x => x.Edited)
				.HasColumnName("edited")
				.ValueGeneratedOnAddOrUpdate();

			builder
				.Property<string>(x => x.Email)
				.HasColumnName("email")
				.IsRequired();

			builder
				.Property<string>(x => x.Password)
				.HasColumnName("password")
				.IsRequired();
		}
	}
}
