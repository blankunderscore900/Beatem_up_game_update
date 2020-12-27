using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] player;

    private void Awake()
    {
        int index = FindObjectOfType<GM>().characterIndex - 1;
        Instantiate(player[index], transform.position, transform.rotation);
    }

}
