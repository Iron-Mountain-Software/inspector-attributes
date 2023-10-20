# Inspector Attributes
Version: 1.0.0
Custom attribute that extend basic inspector functionality.

## Use Cases:
* Make a field read-only
* Show a field conditionally based on other fields.
## Package Mirrors:
[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODk4LnBuZw==/original/Rv4m96.png'>](https://iron-mountain.itch.io/inspector-attributes)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODg3LnBuZw==/original/npRUfq.png'>](https://github.com/Iron-Mountain-Software/inspector-attributes.git)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODkyLnBuZw==/original/Fq0ORM.png'>]()
## Key Scripts & Components:
1. public class **ReadOnlyAttribute** : PropertyAttribute
1. public class **ShowIfAttribute** : PropertyAttribute
   * Properties: 
      * public String ***ComparedPropertyName***  { get; }
      * public Object ***ComparedValue***  { get; }
      * public ComparisonType ***Comparison***  { get; }
      * public DisablingType ***Disabling***  { get; }
### Tests
1. public class **ShowIfTestBooleans** : MonoBehaviour
1. public class **ShowIfTestEnumerations** : MonoBehaviour
1. public class **ShowIfTestFloats** : MonoBehaviour
1. public class **ShowIfTestIntegers** : MonoBehaviour
