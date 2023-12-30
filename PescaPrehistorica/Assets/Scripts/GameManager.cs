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
            // Posición aleatoria dentro de los rangos definidos
            Vector3 randomSpawnPosition = new Vector3(Random.Range(minPos, maxPos), -1f, Random.Range(minPos, maxPos));

            // Elegir un prefab de pez aleatorio
            GameObject randomPezPrefab = pecesPrefabs[Random.Range(0, pecesPrefabs.Count)];

            // Spawnear el pez en la posición aleatoria y en el punto de spawn
            //Instantiate(randomPezPrefab, randomSpawnPosition, Quaternion.identity);

            GameObject newFish = Instantiate(randomPezPrefab, randomSpawnPosition, Quaternion.identity);
            newFish.GetComponent<MovimientoPeces>().enabled = true;
            pecesEnPantalla++;
        }
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
