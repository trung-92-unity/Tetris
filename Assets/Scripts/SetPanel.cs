using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanel : MonoBehaviour
{
    public GameObject panel;
    public static bool panelIsActive;
    public void GetPanel()
    {
        panel.SetActive(true);
        panelIsActive = true;
    }
}
