using Algorithm.Logic.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace Algorithm.Logic.Services
{
    public class ValidationService : IValidationService
    {
        private const string FullPattern = @"^(((S\d{0,10})|(N\d{0,10})|(L\d{0,10})|(O\d{0,10})|X)+)$";
        public bool IsValid(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(input, FullPattern);
            }
        }
    }
}
