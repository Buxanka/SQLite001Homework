using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SQLite001Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection _sqlite = new SQLiteConnection("Data source = human.db; Version = 3; Mode=ReadWriteCreate;");
            try
            {
                _sqlite.Open();
                Console.WriteLine("Подключение прошло успешно...");

                SQLiteCommand cmd = _sqlite.CreateCommand();
                cmd.CommandText = "CREATE TABLE cat (id INTEGER PRIMARY KEY ASC AUTOINCREMENT," +
                    "nameHuman VARCHAR (1, 50), nameCat VARCHAR (1, 50), species VARCHAR (2, 100)," +
                    "height INTEGER (15, 70), weight INTEGER (1, 15) );";
                SQLiteDataReader _sql = cmd.ExecuteReader();
                Console.WriteLine("Создание таблицы прошло успешно...");
                _sql.Close();

                cmd.CommandText = "INSERT INTO cat (nameHuman, nameCat, species, height, weight)" +
                    "VALUES ('Bob', 'Murzik', 'British', '30', '10');";
                _sql = cmd.ExecuteReader();
                _sql.Close();

                cmd.CommandText = "INSERT INTO cat (nameHuman, nameCat, species, height, weight)" +
                    "VALUES ('Alexsandr', 'Stitch', 'Without', '43', '13');";
                _sql = cmd.ExecuteReader();
                _sql.Close();
                Console.WriteLine("Заполнение таблицы прошло успешно...\n");

                cmd.CommandText = "SELECT * FROM cat";
                _sql = cmd.ExecuteReader();
                if (_sql.HasRows)
                {
                    string _text = "";
                    while (_sql.Read())
                    {
                        _text += "id: " + _sql["id"] + "\tИмя хозяина: " + _sql["nameHuman"]
                            + "\tИмя кота:" + _sql["nameCat"] + "\tПорода:" + _sql["species"]
                            + "\tВысота:" + _sql["height"] + "\tВес: " + _sql["weight"] + "\n";
                    }
                    Console.WriteLine(_text);
                }
                else
                {
                    Console.WriteLine("Ничего не найдено...");
                }
                _sql.Close();

                cmd.CommandText = "DROP TABLE cat;";
                _sql = cmd.ExecuteReader();
                Console.WriteLine("Удаление таблицы прошло успешно...");
                _sql.Close();
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так...");
                throw;
            }
        }
    }
}
