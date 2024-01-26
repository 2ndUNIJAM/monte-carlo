using System.Net.Security;
using UnityEngine;


public class test : MonoBehaviour
{
    // The GameObject to instantiate.
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public playerScriptableObject player;

    // This will be appended to the name of the created entities and increment when each is created.

    private void Awake()
    {
        player.playerHP = 1;
    }

    void Start()
    {
        AddHP();
    }

    void AddHP()
    {
        player.playerHP++;

        Debug.Log(player.playerHP);
    }
}
