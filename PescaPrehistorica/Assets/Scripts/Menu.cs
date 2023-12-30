using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Método llamado cuando se presiona el botón
    public void OnPlayButtonPressed()
    {
        // Cargar la escena llamada "Game"
        SceneManager.LoadScene("Game");
    }
}
