using System;
using System.Collections.Generic;
using ExternalLib.PulledFromNuget.FraudDetection;
namespace Yuc.Contract.Business
{
    public class ContractAnalyzer
    {
        public List<ViolationType> Violations{get;set;}

        public ContractAnalyzer(FraudDetector fraudDetector){
            Violations= new List<ViolationType>();
        }

        public List<ViolationType> Analyze(Contract contract){

           if ( (DateTime.Now.Year  - contract.User.DateOfBirth.Year < 18)  )
            {
                Violations.Add(ViolationType.UnderAge);
            }

            FraudDetector fraudDetector= new FraudDetector();
            if(fraudDetector.IsCustomerDeclaredAsFraud(contract.User.FirstName, contract.User.LastName, contract.User.DateOfBirth))
            {
                Violations.Add(ViolationType.Fraud);
            }

            return Violations;

        }

    }
}