using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Dapper;

using Npgsql;

namespace PhoneBookApp.Model;

/// <summary>
/// Представляет контекст базы данных для работы с телефонной книгой.
/// Использует Dapper и Npgsql для доступа к PostgreSQL.
/// </summary>
public class DbContext
{
    private readonly NpgsqlConnection _db;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="DbContext"/>.
    /// </summary>
    /// <param name="connectionString">Строка подключения к базе данных PostgreSQL.</param>
    /// <exception cref="ArgumentNullException">Выбрасывается, если строка подключения пуста или состоит из пробелов.</exception>
    public DbContext(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentNullException();

        _db = new NpgsqlConnection(connectionString);

        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    /// <summary>
    /// Асинхронно получает список всех контактов из таблицы <c>table_persons</c>.
    /// </summary>
    /// <returns>Задача, результат которой содержит коллекцию объектов <see cref="Person"/>.</returns>
    public async Task<IEnumerable<Person>> GetPersons()
    {
        await _db.OpenAsync();
        
        const string sql = "SELECT * FROM table_persons";
        var persons = await _db.QueryAsync<Person>(sql);
        
        await _db.CloseAsync();

        return persons;
    }
    
    /// <summary>
    /// Асинхронно добавляет новый контакт в таблицу <c>table_persons</c>.
    /// </summary>
    /// <param name="person">Данные контакта (фамилия и имя).</param>
    /// <returns>Задача, результат которой — <c>true</c>, если запись успешно добавлена; иначе <c>false</c>.</returns>
    public async Task<bool> AddPerson(Person person)
    {
        await _db.OpenAsync();

        const string sql = """
                           INSERT INTO table_persons (last_name, first_name)
                           VALUES (@lastName, @firstName)
                           """;
        var result = await _db.ExecuteAsync(sql, person);
        
        await _db.CloseAsync();
        
        return result == 1;
    }
}