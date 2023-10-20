using UnityEngine;

namespace IronMountain.InspectorAttributes.Tests
{
    public class ShowIfTestEnumerations : MonoBehaviour
    {
        public enum ShowIfEnum
        {
            None,
            Value1,
            Value2
        }
    
        public ShowIfEnum enumValue = ShowIfEnum.None;
    
        [ShowIf("enumValue", ShowIfEnum.Value1)]
        public int showIfEnumValue1;
    
        [ShowIf("enumValue", ShowIfEnum.Value2)]
        public int showIfEnumValue2;
        
        [ShowIf("enumValue", ShowIfEnum.Value1, ShowIfAttribute.ComparisonType.NotEqual)]
        public int showIfEnumNotValue1;
    
        [ShowIf("enumValue", ShowIfEnum.Value2, ShowIfAttribute.ComparisonType.NotEqual)]
        public int showIfEnumNotValue2;
        
        [ShowIf("enumValue", ShowIfEnum.Value1, disabling: ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfEnumValue1OtherwiseReadOnly;
    
        [ShowIf("enumValue", ShowIfEnum.Value2, disabling: ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfEnumValue2OtherwiseReadOnly;
        
        [ShowIf("enumValue", ShowIfEnum.Value1, ShowIfAttribute.ComparisonType.NotEqual, ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfEnumNotValue1OtherwiseReadOnly;
    
        [ShowIf("enumValue", ShowIfEnum.Value2, ShowIfAttribute.ComparisonType.NotEqual, ShowIfAttribute.DisablingType.ReadOnly)]
        public int showIfEnumNotValue2OtherwiseReadOnly;
    }
}