using UnityEngine;

namespace IronMountain.InspectorAttributes.Tests
{
    public class ShowIfTestBooleans : MonoBehaviour
    {
        public bool boolValue;

        [ShowIf("boolValue", true)]
        public int showIfBoolTrue;
    
        [ShowIf("boolValue", false)]
        public int showIfBoolFalse;

        [ShowIf("boolValue", true, ShowIfAttribute.ComparisonType.NotEqual)]
        public int showIfBoolNotTrue;
    
        [ShowIf("boolValue", false, ShowIfAttribute.ComparisonType.NotEqual)]
        public int showIfBoolNotFalse;
        
        [ShowIf("boolValue", true, disabling: ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfBoolTrueOtherwiseReadOnly;
    
        [ShowIf("boolValue", false, disabling: ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfBoolFalseOtherwiseReadOnly;
        
        [ShowIf("boolValue", true, ShowIfAttribute.ComparisonType.NotEqual, ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfBoolNotTrueOtherwiseReadOnly;
    
        [ShowIf("boolValue", false, ShowIfAttribute.ComparisonType.NotEqual, ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfBoolNotFalseOtherwiseReadOnly;
    }
}
