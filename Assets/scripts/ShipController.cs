using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    int maxHp = 100;

    public int currentHp;

    public int maxPickups = 2;

    public int currentPickups;

    [SerializeField]
    float speed = 5; // rutor per sekund

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform gunPosition;

    float shotTimer = 0;

    [SerializeField]
    float timeBetweenShots = 0.40f;

    [SerializeField]
    Slider healthSlider;

    [SerializeField]
    TMP_Text healthText;

    [SerializeField]
    TMP_Text pickupText;

    void Awake(){
        currentHp = maxHp;
        currentPickups = 0;
        updateHealthSlider();
        updatePickups();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveX, moveY).normalized * speed * Time.deltaTime;
        transform.Translate(movement);


        shotTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire2") > 0 && shotTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            shotTimer = 0;
        }

        if (Input.GetAxisRaw("Fire1") > 0 && currentPickups > 0){
            currentPickups --;

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){
            currentHp -= 10;
            updateHealthSlider();
        }
        if(other.gameObject.tag == "health" && currentHp > 0 && currentHp < maxHp){
            currentHp += 10;
            updateHealthSlider();
        }
    }

    public void updateHealthSlider(){
        healthSlider.maxValue = maxHp;
        healthSlider.value = currentHp;
        healthText.text = currentHp + "/" + maxHp;
        if (currentHp <= 0){
            SceneManager.LoadScene(1);
        }
    }

    public void updatePickups(){
        pickupText.text = currentPickups + "/" + maxPickups;
    }
}
