using UnityEngine;

public class UIHowToPlay : MonoBehaviour
{
    public void Back()
    {
        UIManager.Instance.SetMenuOn();
        UIManager.Instance.SetHowToPlayOff();
    }
}
