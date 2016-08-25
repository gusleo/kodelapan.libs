using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Validator
{

    public class DoNotAllowHtmlAttribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new NotImplementedException(nameof(context));
            var _displayName = context.ModelMetadata.GetDisplayName();
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-donotallowhtml", String.Format("The {0} not allowed html tags", _displayName));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            String str = (String)value;
            var instance = validationContext.MemberName; // which is instance of ModelClass
            var instanceType = validationContext.ObjectType; //which is typeof(ModelClass)
            var dispayName = validationContext.DisplayName; //which is value of Display attribute

            Regex regex = new Regex(@"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
            if ( String.IsNullOrEmpty(str) == false )
            {
                if ( regex.IsMatch(str) )
                {
                    string _displayName = String.IsNullOrEmpty(dispayName) == true ? instance : dispayName;
                    string message = String.Format("The {0} not allowed html tags, ", _displayName);
                    return new ValidationResult(message);
                }
            }
            
            return ValidationResult.Success;
        }
        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if ( attributes.ContainsKey(key) )
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }
    }
}
