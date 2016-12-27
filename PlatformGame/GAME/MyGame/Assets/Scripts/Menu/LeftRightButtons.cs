using UnityEngine;
using System.Collections;

public class LeftRightButtons : MonoBehaviour
{
    public Canvas Stage1;
    public Canvas Stage2;

    public void GoRight()
    {
        Stage1.sortingOrder = -1;
        Stage2.sortingOrder = 2;
    }

    public void GoLeft()
    {
        Stage1.sortingOrder = 1;
        Stage2.sortingOrder = -2;
    }
}
