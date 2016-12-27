using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour
{
    public Canvas Menu;
    public Canvas Stage1;
    public Canvas Stage2;

    public void GoBack()
    {
        Menu.sortingOrder = 0;
        Stage1.sortingOrder = -1;
        Stage2.sortingOrder = -2;
    }
}