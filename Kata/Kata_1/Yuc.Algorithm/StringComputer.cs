using System;
using System.Collections.Generic;

namespace Yuc.Algorithm
{
    public static class StringComputer
    {
        public static double Compute(string value)
        {
            var separateValue=" ";

            var valueSplitted= value.Split(separateValue);


            var values= GetValuesInDouble(valueSplitted);
            var operations= GetOperation(valueSplitted); 

            double returnValue= values[0];

            for(int i=0; i<operations.Length; i++){
                returnValue = ExecuteOperation(operations[i],returnValue, values[i+1]);
            }

            return returnValue;

        }

        private static double ExecuteOperation(string operation, double value1, double value2){
            try{
                double returnValue=0;
                    switch(operation){
                        case "+":
                            returnValue=value1+value2;
                            break;
                        case "-":
                            returnValue= value1-value2;
                            break;
                        case "*":
                            returnValue= value1 * value2;
                            break;
                        case "/":
                            returnValue= value1 / value2;
                            break;
                    }
                    return returnValue ;
            }catch{
                return value1;
            }
           
        }

        private static double[] GetValuesInDouble(string[] value){
            var list= new List<double>();
            foreach(string valueToParse in value ){
                double myValue;
                if(double.TryParse(valueToParse,out myValue))
                {
                    list.Add(myValue);
                }else{
                    break;
                }
            }
            return list.ToArray();
        }

        private static string[] GetOperation(string[] value){
            var operations = new List<string>();

            foreach(string operationToParse in value){
                if(IsValidOperation(operationToParse)){
                    operations.Add(operationToParse);
                }
            }

            operations.Reverse();
            return operations.ToArray();
        }

        private static bool IsValidOperation(string operationToValid){
            
            var listOfValidOPeration= new string[]{"+", "-", "*", "/"};
            foreach(string operation in listOfValidOPeration){
                if(operationToValid == operation)
                    return true;
            }
            return false;
            
        }
    }
}
