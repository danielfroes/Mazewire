using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaMorte : MonoBehaviour
{
    public void VoltarMenuInicial () {
        SceneManager.LoadScene(0);
    }

    public void RestartGameplay() {
        Debug.Log("Just Kidding, you just can't");
    }
}
