using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refresh : MonoBehaviour
{
    public GameObject panel;

    public void Respawn()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
}
