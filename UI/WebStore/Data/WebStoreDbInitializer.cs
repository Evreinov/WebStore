using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Identity;

namespace WebStore.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDB _db;
        private readonly ILogger<WebStoreDbInitializer> _Logger;
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleManager;

        public WebStoreDbInitializer( WebStoreDB db, ILogger<WebStoreDbInitializer> Logger, UserManager<User> UserManager, RoleManager<Role> RoleManager)
        {
            _db = db;
            _Logger = Logger;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }
        public void Initialize()
        {
            var timer = Stopwatch.StartNew();
            //_db.Database.EnsureDeleted();
            //_db.Database.EnsureCreated();

            _Logger.LogInformation("Инициализация базы данных...");

            var dbContext = _db.Database;

            if (dbContext.GetPendingMigrations().Any())
            {
                _Logger.LogInformation("Выполнение миграций...");
                dbContext.Migrate();
                _Logger.LogInformation("Миграция выполнена успешно. [{0:0.6##} c]", timer.Elapsed.TotalSeconds);
            }
            else
            {
                _Logger.LogInformation("База данных находится в актуальном состоянии.");
            }

            try
            {
                InitializeProduct();
                InitializeIndentity().Wait();
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "Ошибка инициализации базы данных.");
                throw;
            }

            _Logger.LogInformation("Инициализация базы данных выполнено успешно. [{0:0.6##} c]", timer.Elapsed.TotalSeconds);
        }

        private void InitializeProduct()
        {
            var timer = Stopwatch.StartNew();

            if (_db.Products.Any())
            {
                _Logger.LogInformation("Инициализация товаров не требуется.");
                return;
            }

            _Logger.LogInformation("Инициализация товаров...");

            _Logger.LogInformation("Добавление секций...");

            using (_db.Database.BeginTransaction())
            {
                TestData.LoadSections();

                _db.Sections.AddRange(TestData.Sections);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Добавление брендов...");

            using (_db.Database.BeginTransaction())
            {
                TestData.LoadBrands();

                _db.Brands.AddRange(TestData.Brands);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Добавление Товаров...");

            using (_db.Database.BeginTransaction())
            {
                TestData.LoadProducts();

                _db.Products.AddRange(TestData.Products);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Инициализация товаров выполнено успешно. [{0:0.6##} c]", timer.Elapsed.TotalSeconds);
        }

        private async Task InitializeIndentity()
        {
            var timer = Stopwatch.StartNew();

            _Logger.LogInformation("Инициализация системы indentity...");

            async Task CheckRole(string RoleName)
            {
                if (!await _RoleManager.RoleExistsAsync(RoleName))
                {
                    _Logger.LogInformation($"Роль {RoleName} отсутсвует. Создание...");
                    await _RoleManager.CreateAsync(new Role { Name = RoleName });
                    _Logger.LogInformation($"Роль {RoleName} создано успешно.");
                }
            }

            await CheckRole(Role.Administrators);
            await CheckRole(Role.Users);

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                _Logger.LogInformation("Отсутствует учетная запись администратора. Создание учетной записи по умолчанию...");
                var admin = new User
                {
                    UserName = User.Administrator
                };
            

                var creation_result = await _UserManager.CreateAsync(admin, User.DefaultAdminPassword);

                if (creation_result.Succeeded)
                    await _UserManager.AddToRoleAsync(admin, Role.Administrators);
                else
                {
                    var errors = creation_result.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Ошибка при создании учётной записи администратора: {string.Join(", ", errors)}");
                }
                _Logger.LogInformation("Учетная запись администратора создана успешно.");

            }
            _Logger.LogInformation("Инициализация системы indentity выполнено успешно. [{0:0.6##} c]", timer.Elapsed.TotalSeconds);
        }
    }
}
