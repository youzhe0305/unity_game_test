using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strike_monster : MonoBehaviour
{
    public float speed;
    public float overwatch_distance;
    public float MAXHp;
    float Hp;
    public GameObject blood_bar;
    float blood_bar_len;
    public Transform player_transform;
    enum Status {idle, walk, chase, flee};
    enum Direction {right,left};
    Status statu;
    Direction direction;
    void Start()
    {   
        speed = 1;
        overwatch_distance = 5;
        MAXHp = 10;
        Hp = MAXHp;
        blood_bar_len =  blood_bar.transform.localScale.x;
        statu = Status.idle;
        if(this.gameObject.GetComponent<SpriteRenderer>().flipX){
            direction = Direction.right;
        }
        else{
            direction = Direction.left;
        }
        player_transform = GameObject.Find("mainchracteractor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player_transform.position.x - this.gameObject.transform.position.x;
        switch(statu){
            case Status.idle:
                if(Math.Abs(distance)<= overwatch_distance && Hp>3 ) statu = Status.chase;
                if(Math.Abs(distance)<= overwatch_distance && Hp<=3 ) statu = Status.flee;
                break;
            case Status.walk:
                print(Math.Abs(distance)+" "+overwatch_distance);
                if(Math.Abs(distance)<= overwatch_distance && Hp>3 ) statu = Status.chase;
                if(Math.Abs(distance)<= overwatch_distance && Hp<=3 ) statu = Status.flee;
                switch(direction){
                    case Direction.right:
                        this.gameObject.transform.position += new Vector3(speed * Time.deltaTime,0,0);
                        break;
                    case Direction.left:
                            this.gameObject.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
                        break;
                }
                break;
            case Status.chase:
                if(distance>0){ // player at right
                    if(direction==Direction.right){
                        this.gameObject.transform.position += new Vector3(speed * Time.deltaTime,0,0);
                    }
                    else{
                        direction = Direction.right;
                        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        this.gameObject.transform.position += new Vector3(speed * Time.deltaTime,0,0);
                    }
                }
                else if(distance==0){
                    print("player at top");// do nothing
                }
                else{ // player at left
                    if(direction==Direction.left){
                        this.gameObject.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
                    }
                    else{
                        direction = Direction.left;
                        this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        this.gameObject.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
                    }
                }
                break;
            case Status.flee:
                if(distance>0){ // player at right
                    if(direction==Direction.left){
                        this.gameObject.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
                    }
                    else{
                        direction = Direction.left;
                        this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        this.gameObject.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
                    }
                }
                else if(distance==0){
                    // do nothing
                }
                else{ // player at left
                    if(direction==Direction.right){
                        this.gameObject.transform.position += new Vector3(speed * Time.deltaTime,0,0);
                    }
                    else{
                        direction = Direction.right;
                        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        this.gameObject.transform.position += new Vector3(speed * Time.deltaTime,0,0);
                    }
                }
                break;
        }
        if(Hp <= 0){
            Destroy(this.gameObject);
        }
        blood_bar.transform.localScale = new Vector3( blood_bar_len*(Hp/MAXHp), blood_bar.transform.localScale.y, blood_bar.transform.localScale.y  ); 
    }

    void OnTriggerEnter2D(Collider2D other) {
        print(other.gameObject.name);
        if(other.gameObject.tag=="bullet"){
            print("triggercol");
            Hp -= 1;
            Destroy(other.gameObject);
        }
    }

}
