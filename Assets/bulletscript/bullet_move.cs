using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 3;
    public SpriteRenderer player_sprite;
    public GameObject player;
    bool direction;
    void Start()
    {
        player = GameObject.Find("mainchracteractor");
        print(player.name);
        player_sprite = player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        //player_sprite = player.GetComponentInChildren<SpriteRenderer>();
        print(player_sprite.name);
        this.gameObject.transform.rotation = Quaternion.Euler(0,0,270);
        direction = player_sprite.flipX;
    }

    // Update is called once per frame
    void Update()
    {   
        if(direction==false) this.gameObject.transform.position += new Vector3(8f * Time.deltaTime,0,0);
        else this.gameObject.transform.position += new Vector3(-8f * Time.deltaTime,0,0);
        timer -= Time.deltaTime;
        if(timer <= 0 ){
            Destroy(this.gameObject);
        }
    }
}
