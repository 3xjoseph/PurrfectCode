
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    public void ShowPanelOPtions()
    {
        panel.SetActive(true);
    }
}
