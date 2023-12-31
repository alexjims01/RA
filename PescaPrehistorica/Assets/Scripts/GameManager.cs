using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> pecesPrefabs;  // Lista de prefabs de enemigos
    private float pecesPescados;
    private float nivelSpawn;

    public float minPos = -2.5f;
    public float maxPos = 2.5f;

    public int maxPecesEnPantalla = 3;

    // Contador de peces en pantalla
    private int pecesEnPantalla = 0;

    public TextMeshProUGUI contadorPecesText;
    public TextMeshProUGUI contadorRondaText;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPeces();
        pecesPescados = 0;
        nivelSpawn = 1;

    }

    private float DeterminarRangoSpawn(GameObject pezPrefab)
    {
        switch (pezPrefab.name)
        {
            case "Pez 1":
                return Random.Range(3f, 6f);
            case "Pez 3":
                return Random.Range(7f, 10f);
            case "Pez 2":
                return Random.Range(10f, 15f);
            default:
                return 1f; // Un valor predeterminado
        }
    }


    // Método para spawnear enemigos en puntos específicos
    public void SpawnPeces()
    {
        if (pecesEnPantalla >= maxPecesEnPantalla)
        {
            return;
        }

        int cantidadPeces = Random.Range(1, 3);
        for (int i = 0; i < cantidadPeces; i++)
        {
            // Elegir un prefab de pez aleatorio
            GameObject randomPezPrefab = pecesPrefabs[Random.Range(0, pecesPrefabs.Count)];

            // Determinar el rango de spawn basado en el tipo de pez
            float spawnRange = DeterminarRangoSpawn(randomPezPrefab);

            // Generar una posición aleatoria dentro del rango de spawn
            Vector3 randomSpawnPosition = GenerarPosicionSpawn(spawnRange);

            GameObject newFish = Instantiate(randomPezPrefab, randomSpawnPosition, Quaternion.identity);
            newFish.GetComponent<MovimientoPeces>().enabled = true;
            pecesEnPantalla++;
        }
    }

    private Vector3 GenerarPosicionSpawn(float rango)
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float x = rango * Mathf.Cos(angle);
        float z = rango * Mathf.Sin(angle);
        float y = Random.Range(-1f, -0.55f); // Rango de profundidad desde la superficie hasta más abajo
        return new Vector3(x, y, z); // Coordenadas en el plano XZ con altura Y ajustada
    }


    public void DecrementarPecesEnPantalla()
    {
        pecesEnPantalla--;
    }

    public void IncrementarPecesPescados()
    {
        DecrementarPecesEnPantalla();
        pecesPescados = pecesPescados + 1;
        float nextLevel = nivelSpawn * 5;
        if(pecesPescados == nextLevel)
        {
            nivelSpawn = nivelSpawn + 1;
        }
        contadorPecesText.text = "Peces pescados: " + pecesPescados.ToString();
        contadorRondaText.text = "Ronda: " + nivelSpawn.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar lógica de actualización adicional si es necesario
    }
}
