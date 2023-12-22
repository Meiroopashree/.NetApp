using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class BookController : Controller
    {
        // private string connectionString = "Your_Connection_String_Here";
        private string connectionString = "User ID=sa;password=examlyMssql@123;server=bfdeeddcedfabcfacbdcbaeadbebabcdebdca-0;Database=CRUDOperations;trusted_connection=false;Persist Security Info=False;Encrypt=False";

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Book (Id,Name, Author, Language, Type, Title) " +
                                       "VALUES (@Id, @Name, @Author, @Language, @Type, @Title)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Id", newBook.Id);
                        command.Parameters.AddWithValue("@Name", newBook.Name);
                        command.Parameters.AddWithValue("@Author", newBook.Author);
                        command.Parameters.AddWithValue("@Language", newBook.Language);
                        command.Parameters.AddWithValue("@Type", newBook.Type);
                        command.Parameters.AddWithValue("@Title", newBook.Title);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("Index", GetBookListFromDatabase());
                        }
                    }
                }
                else
                {
                    // Log ModelState errors
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Log or handle the exception appropriately
            }

            return View(newBook);
        }

        public IActionResult Index()
        {
            List<Book> bookList = GetBookListFromDatabase();
            Console.WriteLine(bookList);
            return View(bookList);
        }

        private List<Book> GetBookListFromDatabase()
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Author, Language, Type, Title FROM Book";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book book = new Book
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Author = reader["Author"].ToString(),
                            Language = reader["Language"].ToString(),
                            Type = reader["Type"].ToString(),
                            Title = reader["Title"].ToString()
                        };

                        bookList.Add(book);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle the exception if needed
                }
            }

            return bookList;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Book WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle the exception if needed
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Book bookToUpdate = GetBookById(id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            return View(bookToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Book updatedBook)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Book SET Name = @Name, Author = @Author, " +
                               "Language = @Language, Type = @Type, Title = @Title WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", updatedBook.Name);
                command.Parameters.AddWithValue("@Author", updatedBook.Author);
                command.Parameters.AddWithValue("@Language", updatedBook.Language);
                command.Parameters.AddWithValue("@Type", updatedBook.Type);
                command.Parameters.AddWithValue("@Title", updatedBook.Title);
                command.Parameters.AddWithValue("@Id", updatedBook.Id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle the exception if needed
                }
            }

            return View("Update", updatedBook);
        }

        private Book GetBookById(int id)
        {
            Book book = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Author, Language, Type, Title FROM Book WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        book = new Book
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Author = reader["Author"].ToString(),
                            Language = reader["Language"].ToString(),
                            Type = reader["Type"].ToString(),
                            Title = reader["Title"].ToString()
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle the exception if needed
                }
            }

            return book;
        }
    }
}
