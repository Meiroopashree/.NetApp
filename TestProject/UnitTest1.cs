using dotnetapp.Models;
using System;
using NUnit.Framework;
using System.Reflection;

using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;
using Deliveryboy.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Deliveryboy.Models;
 
namespace TestProject;
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
    
}