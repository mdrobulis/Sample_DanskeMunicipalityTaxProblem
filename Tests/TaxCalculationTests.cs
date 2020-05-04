using System;
using System.Collections.Generic;
using Xunit;
using service.Interfaces;
using service.Services;
using service.Data;

namespace Tests
{
    public class TaxCalculationTests
    {
        IDataProvider data;
        ITaxCalculator calc;

        IEnumerable<TaxRecord> taxRecords;
        public TaxCalculationTests()
        {
            data = new FileDataProvider("../../../../init.csv");
            taxRecords =data.GetMunicipalityTaxRecords("Vilnius");
            calc = new PeriodicTaxCalculator();            
            
        }

        private double Test(DateTime date)
        {
            var r =new TaxRequest(){Municipality="Vilnius",Date = date };
            return calc.Calculate(taxRecords,r);
        }


        [Fact]
        public void Test1()
        {
            Assert.Equal(0.1,Test(new DateTime(2016,1,1)));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(0.4,Test(new DateTime(2016,5,2)));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(0.2,Test(new DateTime(2016,7,10)));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(0.2,Test(new DateTime(2016,3,16)));
        }
    }
}
