using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamPickup : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Ship");

        float x = Random.Range(-5f, 5f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize +1);

        transform.position = pos;
    }

    void Update()
    {
        float speed = -2;

        Vector2 movement = new Vector2(0, speed) * Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize -1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && player.GetComponent<ShipController>().currentPickups <2){
            Destroy(this.gameObject);
            player.GetComponent<ShipController>().currentPickups ++;
            player.GetComponent<ShipController>().updatePickups();
            }
        
    }
}
