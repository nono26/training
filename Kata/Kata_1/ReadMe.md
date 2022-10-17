# Kata - .Net  - Algorithm


Implements the method **Compute** in **StringComputer** to get the right result. 
Input will be a string like this "1 2 2 4 * - +"
1. You do not need to validate the input string.
2. Number must be read left to right.
3. Operators must be read right to left.
4. Each operator should be apply between the 2 number (current operation result and current number)
5. If one operation is not valid you should keep the previous result.
For the case "1 2 2  4* - +" will do ((1+2)-2)*4
1+2 = 3 Then 3-2=1 Then 1*4=4