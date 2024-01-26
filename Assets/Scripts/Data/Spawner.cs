using System.Net.Security;
using UnityEngine;


[SerializeField]


public class Spawner : MonoBehaviour
{
    // The GameObject to instantiate.
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public playerScriptableObject player;

    // This will be appended to the name of the created entities and increment when each is created.

    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {

        player.playerHP++;

        Debug.Log(player.playerHP);
    }
}
