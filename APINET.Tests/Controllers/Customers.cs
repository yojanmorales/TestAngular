using System;
using System.Collections.Generic;
using APINET.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloNet;
using ModeloNet.Repository;
using ModeloNet.Servicio;
using Moq;

namespace APINET.Tests.Controllers
{
    [TestClass]
    public class Customers
    {

        private Mock<ICustomerServices> cityDataMock = null;
        private CustomerServices cityBussiness = null;
        Mock<IRepository<Customer>> _mockUnitWork;

        [TestInitialize]
        public void InitializeTest()
        {
            this.cityDataMock = new Mock<ICustomerServices>();
            _mockUnitWork = new Mock<IRepository<Customer>>();
            this.cityBussiness = new CustomerServices(_mockUnitWork.Object);
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
