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

    // [Test]
    //     public void BookController_ClassExists()
    //     {
    //         string assemblyName = "dotnetapp";
    //         string typeName = "dotnetapp.Controllers.BookController";
    //         Assembly assembly = Assembly.Load(assemblyName);
    //         Type controllerType = assembly.GetType(typeName);
    //         Assert.IsNotNull(controllerType);
    //         var controller = Activator.CreateInstance(controllerType);
    //         Assert.IsNotNull(controller);
    //     }

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
    
}