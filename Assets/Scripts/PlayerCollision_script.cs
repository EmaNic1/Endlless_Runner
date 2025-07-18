using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision_script : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }
}
