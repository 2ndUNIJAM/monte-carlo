using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/playerScriptableObject", order = 1)]
public class playerScriptableObject : ScriptableObject
{
    public int playerHP;
    public bool playerAttack;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}
