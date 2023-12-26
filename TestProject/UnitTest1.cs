using System;
using NUnit.Framework;
using System.Reflection;
// using dotnetapp.Models;
using dotnetapp.Controllers;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // [Test]
        // public void Book_ClassExists()
        // {
        //     string assemblyName = "dotnetapp"; 
        //     string typeName = "dotnetapp.Models.Book";
        //     Assembly assembly = Assembly.Load(assemblyName);
        //     Type bookType = assembly.GetType(typeName);
        //     Assert.IsNotNull(bookType);
        //     var book = Activator.CreateInstance(bookType);
        //     Assert.IsNotNull(book);
        // }

         [Test]
        public void BookController_CreateMethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.BookController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
            Type[] parameterTypes = new Type[] { typeof(Book) };
            MethodInfo createMethod = controllerType.GetMethod("Create", parameterTypes);
            Assert.IsNotNull(createMethod);
        }
    }
}
