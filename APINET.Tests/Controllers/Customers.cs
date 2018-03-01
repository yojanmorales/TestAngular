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
        private FachadaCustomers cityBussiness = null;


        [TestInitialize]
        public void InitializeTest()
        {
            this.cityDataMock = new Mock<ICustomerServices>();

            this.cityBussiness = new FachadaCustomers(this.cityDataMock.Object);
        }
        [TestMethod]
        public void TestMethod1()
        {
            List<Customer> listcustomers = new List<Customer>()
                {
                 new Customer()
                 {
                      CustomerId = 0,
                       Identification = "12",
                        Name = "Yojan"
                 }
            };


            this.cityDataMock.Setup(it => it.GetCustomers()).Returns(listcustomers);
            var customersActual = this.cityBussiness.GetCustomers();

            Assert.AreEqual(1, customersActual.Count);
        }
    }
}
