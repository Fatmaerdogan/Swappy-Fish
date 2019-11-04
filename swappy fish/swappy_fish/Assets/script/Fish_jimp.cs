using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class Fish_jimp : MonoBehaviour
{
    public float jimp;

    Rigidbody2D Rigidbody;
    public Rigidbody Camera_Rigidbody;
    public float hiz;
    public int skor = 0;
    public int i=5;
    public Text text;
    public GameObject FinishPanel;
    public Text FinishText;
    public GameObject klon1;
    public GameObject klon2;
    public GameObject klon3;
    public GameObject blackground;
    public int b;
    //public GameObject blackground;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.5f;
        FinishPanel.SetActive(false);
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = Vector2.right * hiz * Time.deltaTime;
        Camera_Rigidbody.velocity = Vector2.right * hiz * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody.velocity += new Vector2(0, jimp);
        }
     //   for(int i = 0; i < 13; i++)
     //   {
         //Debug.Log(x);
       //     if (x > (i * 5))
       //     {
       //         skor+=10;
     //           Debug.Log(skor);
        text.text = ""+skor;
        PuanArttır();
    //        }
    //    }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "klon" )
        {
            FinishText.text =""+ skor;
            FinishPanel.SetActive(true);
            // EditorApplication.isPaused = true;
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "gecis")
        {
            skor=skor + 10;
        }
    }
    private void PuanArttır()
    {
        Debug.Log("posisyon:" + this.transform.position.x + "i:" + i);
        if(this.transform.position.x >= i )
        {
            
            if (i / 15 == 0)
            {
                Instantiate(blackground, new Vector3(b+21, 0, 0), new Quaternion(0, 0, 0, 0));
                b = b + 21;
            }
            skor += 10;
            i += 5;
            Random rand = new Random();
            
            int a = rand.Next(0, 3);
            Debug.Log(a);
            if(a==1)
               Instantiate(klon1, new Vector3(i + 10, 0, 0),new Quaternion(0,0,0,0));
            else if(a==2)
               Instantiate(klon2, new Vector3(i + 10, 0, 0), new Quaternion(0, 0, 0, 0));
            else if(a==0)
               Instantiate(klon3, new Vector3(i + 10, 0, 0), new Quaternion(0, 0, 0, 0));
        }
        if(this.transform.position.x >= 70 || this.transform.position.y <=-5)
        {
            FinishText.text = "SKOR:" + skor;
            FinishPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
