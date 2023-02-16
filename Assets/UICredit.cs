using UnityEngine;

public class UICredit : MonoBehaviour
{
    public void Back()
    {
        UIManager.Instance.SetMenuOn();
        UIManager.Instance.SetCreditOff();
    }
}
