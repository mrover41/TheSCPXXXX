using UnityEngine;

[CreateAssetMenu(fileName = "NewSettingsPreset", menuName = "Scriptable Objects/Settings")]
public class ScriptableObjectSetting : ScriptableObject {
    [Header("Keyboard Settings")]
    public KeyCode toggleKey = KeyCode.E;
}
