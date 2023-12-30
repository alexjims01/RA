using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PescarPez : MonoBehaviour
{
    // Método llamado cuando se toca la pantalla
    void Update()
    {
        // Verificar si hay toques en la pantalla
        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            Touch touch = Input.GetTouch(0);

            // Obtener la cámara principal que representa la cámara de AR
            Camera arCamera = Camera.main;

            if (arCamera != null)
            {
                Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 0f);
                Ray ray = arCamera.ScreenPointToRay(touchPosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject && touch.phase == TouchPhase.Ended)
                    {
                        // Solo eliminar el pez si el toque ha terminado
                        Destroy(gameObject);
                        FindObjectOfType<GameManager>().SpawnPeces();
                        FindObjectOfType<GameManager>().IncrementarPecesPescados();
                    }
                }
            }
            else
            {
                Debug.LogError("La cámara de AR no está configurada correctamente.");
            }
        }
    }
}

