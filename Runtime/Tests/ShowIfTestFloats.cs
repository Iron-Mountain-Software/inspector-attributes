using UnityEngine;

namespace IronMountain.InspectorAttributes.Tests
{
    public class ShowIfTestFloats : MonoBehaviour
    {
        [Range(0f,2f)]
        public float floatValue;

        [ShowIf("floatValue", 0f)]
        public int showIfIntegerEquals0;
    
        [ShowIf("floatValue", 1f)]
        public int showIfIntegerEquals1;
        
        [ShowIf("floatValue", 2f)]
        public int showIfIntegerEquals2;

        [ShowIf("floatValue", 1f, ShowIfAttribute.ComparisonType.GreaterThan)]
        public int showIfIntegerGreaterThan1;
    
        [ShowIf("floatValue", 1f, ShowIfAttribute.ComparisonType.GreaterThanOrEqual)]
        public int showIfIntegerGreaterThanOrEqual1;
        
        [ShowIf("floatValue", 1f, ShowIfAttribute.ComparisonType.LessThan)]
        public int showIfIntegerLessThan1;
    
        [ShowIf("floatValue", 1f, ShowIfAttribute.ComparisonType.LessThanOrEqual)]
        public int showIfIntegerLessThanOrEqual1;
    }
}