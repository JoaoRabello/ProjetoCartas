using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    public void EndDay()
    {
        _winScreen.SetActive(true);
    }
}
