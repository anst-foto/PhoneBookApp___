using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Dapper;

using Npgsql;

namespace PhoneBookApp.Model;

public class DbContext
{
    private readonly NpgsqlConnection _db;

    public DbContext(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentNullException();

        _db = new NpgsqlConnection(connectionString);

        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<IEnumerable<Person>> GetPersons()
    {
        await _db.OpenAsync();
        
        const string sql = "SELECT * FROM table_persons";
        var persons = await _db.QueryAsync<Person>(sql);
        
        await _db.CloseAsync();

        return persons;
    }
    
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