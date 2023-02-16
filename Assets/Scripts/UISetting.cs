using UnityEngine;

public class UISetting : MonoBehaviour
{
    public void Back()
    {
        UIManager.Instance.SetMenuOn();
        UIManager.Instance.SetSettingOff();
    }
}
