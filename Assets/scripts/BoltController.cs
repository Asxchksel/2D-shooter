using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        float speed = 12; 

        Vector2 movement = new Vector2(0, speed) * Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.y > Camera.main.orthographicSize +1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){
            Destroy(this.gameObject);
        }
    }

}
