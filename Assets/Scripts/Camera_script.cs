using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    public Player_script player;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * player.speed * Time.deltaTime);
    }
}
