using System;
using UnityEngine;

namespace IronMountain.InspectorAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public enum ComparisonType
        {
            Equals,
            NotEqual,
            GreaterThan,
            GreaterThanOrEqual,
            LessThan,
            LessThanOrEqual
        }
        
        public enum DisablingType
        {
            None,
            ReadOnly,
            Hidden
        }
        
        public string ComparedPropertyName { get; }
        public object ComparedValue { get; }
        public ComparisonType Comparison { get; }
        public DisablingType Disabling { get; }

        public ShowIfAttribute(string comparedPropertyName, object comparedValue, ComparisonType comparison = ComparisonType.Equals, DisablingType disabling = DisablingType.Hidden)
        {
            ComparedPropertyName = comparedPropertyName;
            ComparedValue = comparedValue;
            Comparison = comparison;
            Disabling = disabling;
        }
    }
}