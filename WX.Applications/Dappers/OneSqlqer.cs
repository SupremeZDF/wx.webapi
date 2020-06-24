using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace WX.Applications.Dappers
{

    public class T_User
    {
        public string FName { get; set; }

        public string FPsword { get; set; }

        public string FSex { get; set; }

        public string FAge { get; set; }
    }




    public class OneSqlqer
    {
        SqlConnection Connection = new SqlConnection();


        public static void DataClass()
        {
            SqlConnection sql = new SqlConnection("Data Source=.;Initial Catalog=Dapper;Integrated Security=True");
            var result = sql.Execute("insert into T_User(FName,FPsword,FSex,FAge) values(@FName,@FPsword,@FSex,@FAge)", new { FName = "麻子", FPsword = "dasda", FSex = "中", FAge = "12" });
        }

        public static void InsertList()
        {
            var usersList = Enumerable.Range(0, 10).Select(i => new T_User()
            {
                FName = i + "qq.com",
                FPsword = "安徽",
                FSex = i + "jack"
                //FAge = $"{i}"
            });
            SqlConnection sql = new SqlConnection("Data Source=.;Initial Catalog=Dapper;Integrated Security=True");
            sql.Execute("insert into T_User(FName,FPsword,FSex,FAge) values(@FName,@FPsword,@FSex,@FAge)", usersList);
        }

        public static void SelectUser() 
        {
            SqlConnection sql = new SqlConnection("Data Source=.;Initial Catalog=Dapper;Integrated Security=True");
            var data = sql.Query<T_User>("select * from T_User where FID=@FID", new { FID="1"}).ToList();
        }

        public static void InSelect() 
        {

            var sql = "select * from Person; select * from Book";

            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Dapper;Integrated Security=True");
            var multiReader = connection.QueryMultiple(sql);

            //var personList = multiReader.Read<Person>();
            //var bookList = multiReader.Read<Book>();

            SqlConnection sqls = new SqlConnection("Data Source=.;Initial Catalog=Dapper;Integrated Security=True");

            var data = sqls.Query<T_User>("select * from T_User where FID in @FIDs", new { FIDs =  new int[3]{1,2,3 } }).ToList();
        }


        public static void Name() 
        {


            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Dapper;Integrated Security=True");

            var sql = @"select b.id,b.bookName,p.id,p.name,p.remark
                        from Person as p
                        join Book as b
                        on p.id = b.personId
                        where b.id = @id;";
            //var result = connection.Query<BookWithPerson, Person, BookWithPerson>(sql,
            //(bookWithPerson, person) =>
            //{
            //    bookWithPerson.Pers = person;
            //    return bookWithPerson;
            //},
            //book);
        }

       
    }

    public class BookWithPerson
    {
        public int ID { get; set; }
        public Person Pers { get; set; }
        public string BookName { get; set; }
    }

    public class Person 
    {
    
    }
}
