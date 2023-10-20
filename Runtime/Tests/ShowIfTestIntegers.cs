using UnityEngine;

namespace IronMountain.InspectorAttributes.Tests
{
    public class ShowIfTestIntegers : MonoBehaviour
    {
        [Range(0,2)]
        public int integerValue;

        [ShowIf("integerValue", 0)]
        public int showIfIntegerEquals0;
    
        [ShowIf("integerValue", 1)]
        public int showIfIntegerEquals1;
        
        [ShowIf("integerValue", 2)]
        public int showIfIntegerEquals2;

        [ShowIf("integerValue", 1, ShowIfAttribute.ComparisonType.GreaterThan)]
        public int showIfIntegerGreaterThan1;
    
        [ShowIf("integerValue", 1, ShowIfAttribute.ComparisonType.GreaterThanOrEqual)]
        public int showIfIntegerGreaterThanOrEqual1;
        
        [ShowIf("integerValue", 1, ShowIfAttribute.ComparisonType.LessThan)]
        public int showIfIntegerLessThan1;
    
        [ShowIf("integerValue", 1, ShowIfAttribute.ComparisonType.LessThanOrEqual)]
        public int showIfIntegerLessThanOrEqual1;
        
    }
}