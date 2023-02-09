using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class strike : MonoBehaviour
{
    public float MAXHp;
    float Hp;
    public Image blood_bar;
    float blood_bar_len;
    public Image redflash;
    float redflash_time=0;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        Hp = MAXHp;
        DontDestroyOnLoad(this.gameObject);
        body = this.gameObject.GetComponent<Rigidbody2D>();
        blood_bar_len = blood_bar.transform.localScale.x;
        blood_bar.transform.localScale = new Vector3( (Hp/MAXHp)*blood_bar_len, blood_bar.transform.localScale.y, blood_bar.transform.localScale.z);
        print("HAHA");
    }

    // Update is called once per frame
    void Update()
    {  
        if(redflash_time<=0) redflash.enabled = false;
        else redflash_time -= 1 * Time.deltaTime;
        if(Hp<=0){
            print("you died");
            body.bodyType = RigidbodyType2D.Static;
        }
        blood_bar.transform.localScale = new Vector3( (Hp/MAXHp)*blood_bar_len, blood_bar.transform.localScale.y, blood_bar.transform.localScale.z);
    }


    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="monster"){
            //Hp -= other.gameObject.;
            body.AddForce(new Vector2(0,300),ForceMode2D.Impulse);
            Hp -= 1;
            redflash.enabled = true;
            redflash_time = 0.2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="portal"){
            other.gameObject.GetComponent<portal>().ChangeScene();
            this.gameObject.transform.localPosition = new Vector3(-9.14999962f,0.589999974f,0);
        }
    }
}
