using UnityEditor;
using UnityEngine;

namespace IronMountain.InspectorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfPropertyDrawer : PropertyDrawer
    {
        private ShowIfAttribute _showIf;
        private SerializedProperty _comparedField;
 
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!ShouldShow(property) && _showIf.Disabling == ShowIfAttribute.DisablingType.Hidden)
                return 0f;
            return base.GetPropertyHeight(property, label);
        }

        private bool HandleBooleanValue()
        {
            switch (_showIf.Comparison)
            {
                case ShowIfAttribute.ComparisonType.Equals:
                    return _comparedField.boolValue.Equals((bool) _showIf.ComparedValue);
                case ShowIfAttribute.ComparisonType.NotEqual:
                    return !_comparedField.boolValue.Equals((bool) _showIf.ComparedValue);
                default:
                    Debug.LogError("Error: " + _showIf.Comparison + " is not supported for Boolean values.");
                    return true;
            }
        }
        
        private bool HandleEnumerationValue()
        {
            switch (_showIf.Comparison)
            {
                case ShowIfAttribute.ComparisonType.Equals:
                    return _comparedField.enumValueIndex.Equals((int)_showIf.ComparedValue);
                case ShowIfAttribute.ComparisonType.NotEqual:
                    return !_comparedField.enumValueIndex.Equals((int)_showIf.ComparedValue);
                default:
                    Debug.LogError("Error: " + _showIf.Comparison + " is not supported for Enum values.");
                    return true;
            }
        }

        private bool HandleIntegerValue()
        {
            switch (_showIf.Comparison)
            {
                case ShowIfAttribute.ComparisonType.Equals:
                    return _comparedField.intValue.Equals((int) _showIf.ComparedValue);
                case ShowIfAttribute.ComparisonType.NotEqual:
                    return !_comparedField.intValue.Equals((int) _showIf.ComparedValue);
                case ShowIfAttribute.ComparisonType.GreaterThan:
                    return _comparedField.intValue > (int)_showIf.ComparedValue;
                case ShowIfAttribute.ComparisonType.GreaterThanOrEqual:
                    return _comparedField.intValue >= (int)_showIf.ComparedValue;
                case ShowIfAttribute.ComparisonType.LessThan:
                    return _comparedField.intValue < (int)_showIf.ComparedValue;
                case ShowIfAttribute.ComparisonType.LessThanOrEqual:
                    return _comparedField.intValue <= (int)_showIf.ComparedValue;
                default:
                    Debug.LogError("Error: " + _showIf.Comparison + " is not supported for Enum values.");
                    return true;
            }
        }
        
        private bool HandleFloatValue()
        {
            switch (_showIf.Comparison)
            {
                case ShowIfAttribute.ComparisonType.Equals:
                    return _comparedField.floatValue.Equals((float) _showIf.ComparedValue);
                case ShowIfAttribute.ComparisonType.NotEqual:
                    return !_comparedField.floatValue.Equals((float) _showIf.ComparedValue);
                case ShowIfAttribute.ComparisonType.GreaterThan:
                    return _comparedField.floatValue > (float)_showIf.ComparedValue;
                case ShowIfAttribute.ComparisonType.GreaterThanOrEqual:
                    return _comparedField.floatValue >= (float)_showIf.ComparedValue;
                case ShowIfAttribute.ComparisonType.LessThan:
                    return _comparedField.floatValue < (float)_showIf.ComparedValue;
                case ShowIfAttribute.ComparisonType.LessThanOrEqual:
                    return _comparedField.floatValue <= (float)_showIf.ComparedValue;
                default:
                    Debug.LogError("Error: " + _showIf.Comparison + " is not supported for Enum values.");
                    return true;
            }
        }

        private bool ShouldShow(SerializedProperty property)
        {
            _showIf = attribute as ShowIfAttribute;
            if (_showIf == null) return true;
            string path = property.propertyPath.Contains(".") ? System.IO.Path.ChangeExtension(property.propertyPath, _showIf.ComparedPropertyName) : _showIf.ComparedPropertyName;
            _comparedField = property.serializedObject.FindProperty(path);
            if (_comparedField == null)
            {
                Debug.LogError("Cannot find property with name: " + path);
                return true;
            }
        
            switch (_comparedField.type)
            {
                case "bool":
                    return HandleBooleanValue();
                case "Enum":
                    return HandleEnumerationValue();
                case "int":
                    return HandleIntegerValue();
                case "float":
                    return HandleFloatValue();
                default:
                    Debug.LogError("Error: " + _comparedField.type + " is not a supported type of " + path);
                    return true;
            }
        }
 
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            switch (_showIf.Disabling)
            {
                case ShowIfAttribute.DisablingType.None:
                    EditorGUI.PropertyField(position, property, label, true);
                    break;
                case ShowIfAttribute.DisablingType.ReadOnly:
                    if (ShouldShow(property))
                    {
                        EditorGUI.PropertyField(position, property, label, true);
                    }
                    else
                    {
                        GUI.enabled = false;
                        EditorGUI.PropertyField(position, property, label, true);
                        GUI.enabled = true;
                    }
                    break;
                case ShowIfAttribute.DisablingType.Hidden:
                    if (ShouldShow(property))
                        EditorGUI.PropertyField(position, property, label, true);
                    break;
                default:
                    EditorGUI.PropertyField(position, property, label, true);
                    break;
            }
        }
    }
}