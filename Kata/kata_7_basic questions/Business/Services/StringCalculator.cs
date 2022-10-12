namespace Services
{
    public class StringCalculator
    {
        public int Add(string Numbers){
            var sum= 0;
            if(!string.IsNullOrEmpty(Numbers)){
                char[] Separators;
                if(GetCustomSeparator(Numbers, out Separators)){
                    Numbers= Numbers.Substring(Numbers.IndexOf("\n")+1);
                }
                var NumbersSplitted= Numbers.Split(Separators);

                foreach(string number in NumbersSplitted){
                    int ValueToAdd=0;
                    if(int.TryParse(number, out ValueToAdd)){
                        sum=sum+ValueToAdd;
                    }
                }
            }
            return sum;
        }
        private bool GetCustomSeparator(string numbers,out char[] separators)
        {
            var separatorStarter= "//";
            var separatorEnding= "\n";
            var separator= string.Empty;
            bool hasCustomerSeparator= false;  
            separators= new char[]{',','\n',' '};
            if(numbers.StartsWith(separatorStarter)){
                separator= numbers.Substring(separatorStarter.Length, numbers.IndexOf(separatorEnding)-1+separatorEnding.Length -separatorStarter.Length);
                if(separator.Length==1){
                    separators= new char[]{separator[0]};
                    hasCustomerSeparator= true;
                }
            }
            return hasCustomerSeparator;
        }
        
    }
}