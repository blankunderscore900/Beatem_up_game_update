using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public float xMargin = 1f; // Distance in the x axis the player can move before the camera will move
    public float yMargin = 1f;
    public float xSmooth = 8f; // How smoothly the camera will move in the x axis with the player
    public float ySmooth = 8f;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    private Transform m_Player; // reference to the player tag/object

    // Use this for initialization
    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private bool CheckXMargin()
    {
        return (transform.position.x - m_Player.position.x) < xMargin;
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
    }

    private void TrackPlayer()
    {

        float targetX = transform.position.x;
        float targetY = transform.position.y;


        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth = Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

    }
}
