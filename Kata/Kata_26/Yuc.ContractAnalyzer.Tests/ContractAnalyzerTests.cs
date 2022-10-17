using NUnit.Framework;
using Yuc.Contract.Business;
using System;

namespace Yuc.Contract.Business.Tests
{
    public class ContractAnalyzerTests
    {

        private ContractAnalyzer _sut;

        public ContractAnalyzerTests(){
            _sut= new ContractAnalyzer();

        }

        [Test]
        public void hasContractAnalyserAViolationList()
        {

            //act
            var myValueToCheck= _sut.Violations;

            //assert

            Assert.AreEqual(myValueToCheck.Count,0);
        }

        [Test]
        public void hasNotUnderAgeViolation(){

            //arrange
            var contract= new Contract{
                User= new User{
                    DateOfBirth= new DateTime(2000,1,1)                    
                }
            };

            //act

            var myViolationsToCheck= _sut.Analyze(contract);

            //assert

            Assert.AreEqual(myViolationsToCheck.Count,0);

        }

        [Test]
        public void hasUnderAgeViolation(){
            //arrange
            var contract= new Contract{
                User= new User{
                    DateOfBirth= new DateTime(2004,01,01)                    
                }
            };

            //act

            var myViolationsToCheck= _sut.Analyze(contract);

            //assert

            Assert.AreEqual(myViolationsToCheck.Count,1);
            Assert.AreEqual(myViolationsToCheck[0], ViolationType.UnderAge);
        }


    }
}