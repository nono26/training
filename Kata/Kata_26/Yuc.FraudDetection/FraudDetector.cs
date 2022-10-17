using System;

namespace ExternalLib.PulledFromNuget.FraudDetection
{
    /// <summary>
    /// SACRED INDIAN LAND : DON'T TOUCH
    /// </summary>
    public sealed class FraudDetector
    {
        public bool IsCustomerDeclaredAsFraud(string firstName, string lastName, DateTime dateOfBirth)
        {
            int milliSecondsSinceMidnight = (DateTime.Now - DateTime.Today).Milliseconds;
            return milliSecondsSinceMidnight % 2 == 0;
        }
    }
}
