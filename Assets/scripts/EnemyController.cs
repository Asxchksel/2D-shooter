using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject Explosion;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Ship");

        float x = Random.Range(-10f, 10f);
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
            player.GetComponent<ShipController>().currentHp -= 10;
            player.GetComponent<ShipController>().updateHealthSlider();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bolt" || other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            GameObject explosionObject = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(explosionObject, 0.8f);
        }
    }
}
