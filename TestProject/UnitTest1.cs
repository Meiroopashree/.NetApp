using System;
using NUnit.Framework;
using System.Reflection;
using dotnetapp.Controllers; // Make sure this namespace is correct and the reference is added

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BookController_CreateMethodExists()
        {
            string assemblyName = "dotnetapp"; // Replace with your actual assembly name if different
            string typeName = "dotnetapp.Controllers.BookController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
            
            // Check if the controller type exists
            Assert.IsNotNull(controllerType);

            // Check if the 'Create' method with Book parameter exists
            Type[] parameterTypes = new Type[] { typeof(Book) };
            MethodInfo createMethod = controllerType.GetMethod("Create", parameterTypes);
            Assert.IsNotNull(createMethod);
        }
    }
}
