using System;
using NUnit.Framework;
using System.Reflection;
using dotnetapp.Models;

namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
        public void Book_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type rideType = assembly.GetType(typeName);
            Assert.IsNotNull(rideType);
            var ride = Activator.CreateInstance(rideType);
            Assert.IsNotNull(ride);
        }

    [Test]
        public void BookController_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.BookController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
            Assert.IsNotNull(controllerType);
            var controller = Activator.CreateInstance(controllerType);
            Assert.IsNotNull(controller);
        }
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
            [Test]
            public void BookController_UpdateMethodExists()
            {
                string assemblyName = "dotnetapp";
                string typeName = "dotnetapp.Controllers.BookController";
                Assembly assembly = Assembly.Load(assemblyName);
                Type controllerType = assembly.GetType(typeName);

                Type[] parameterTypes = new Type[] { typeof(Book) };

                MethodInfo updateMethod = controllerType.GetMethod("Update", parameterTypes);
                Assert.IsNotNull(updateMethod);
            }
            [Test]
            public void BookController_ReadMethodExists()
            {
                string assemblyName = "dotnetapp";
                string typeName = "dotnetapp.Controllers.BookController";
                Assembly assembly = Assembly.Load(assemblyName);
                Type controllerType = assembly.GetType(typeName);
            
                MethodInfo readMethod = controllerType.GetMethod("Index");
                Assert.IsNotNull(readMethod);
            }
            [Test]
            public void BookController_DeleteMethodExists()
            {
                string assemblyName = "dotnetapp";
                string typeName = "dotnetapp.Controllers.BookController";
                Assembly assembly = Assembly.Load(assemblyName);
                Type controllerType = assembly.GetType(typeName);
                
                MethodInfo deleteMethod = controllerType.GetMethod("Delete");
                Assert.IsNotNull(deleteMethod);
            }
  
}