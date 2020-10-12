using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public bool Play = false;
    public GameObject spawnpoint;
    public Player player;
    public float bottom = -5;
    public bool safe = false;

    void Awake()
    {
        if (!safe)
        {
            foreach (PlayerSpawn p in FindObjectsOfType<PlayerSpawn>())
            {
                if (p.gameObject != this.gameObject && !p.safe)
                {
                    Destroy(p.gameObject);
                }
            }
        }
        if (Play)
        {
            Player clone;
            clone = Instantiate(player, spawnpoint.transform.position, transform.rotation);
            clone.spawnpoint = spawnpoint.transform.position;
            clone.bottom = bottom - 5f;
        }
    }
}
