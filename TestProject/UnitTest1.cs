using System;
// using dotnetapp.Controllers;
using NUnit.Framework;
using System.Reflection;
using dotnetapp.Models;

namespace TestProject  

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Book_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type bookType = assembly.GetType(typeName);
            Assert.IsNotNull(bookType);
            var book = Activator.CreateInstance(bookType);
            Assert.IsNotNull(book);
        }
    }
}