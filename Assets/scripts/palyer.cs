using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
public class palyer : MonoBehaviour
{
    private int score;
    public Text scoretext;

    private Vector3 mov;
    private int score_red=100;
    public Text scoretext_red;

    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject last_round;

    public Camera pick_camera;

    private AudioSource run_music;

    private AudioClip music_game;
    public AudioClip lose_game;
    public AudioClip win_game;
    public AudioClip red_pick;
    public AudioClip blue_pick;
    public AudioClip new_level;
    public AudioClip jumb_music;
   

    void FixedUpdate()
    {

        run_music = pick_camera.GetComponent<AudioSource>();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

         mov = new Vector3(moveHorizontal,0, moveVertical);
      //  mov.x = moveHorizontal;
      //  mov.z = moveVertical;

        Rigidbody e = this.GetComponent<Rigidbody>();
        e.AddForce(mov*1200*Time.deltaTime);

        if (this.transform.position.y <= -9)
        {
            run_music.Stop();
            Thread.Sleep(1000);
            run_music.PlayOneShot(lose_game);
            Thread.Sleep(3000);
            SceneManager.LoadScene(2);
        }
    }
    

        void OnTriggerEnter(Collider x)
        {
        
        if (x.tag == "packup")
        {
            x.gameObject.SetActive(false);
            score++;
            scoretext.text = "Score: " + score;

             run_music = pick_camera.GetComponent<AudioSource>();
             run_music.PlayOneShot(blue_pick);

            if (score == 7)
            {
                
                level2.gameObject.SetActive(true);
                run_music.PlayOneShot(new_level);
                
            }
            else if (score == 14)
            {
                level3.gameObject.SetActive(true);
                run_music.PlayOneShot(new_level);
            }
            else if (score == 21)
            {
                level4.gameObject.SetActive(true);
                run_music.PlayOneShot(new_level);
            }
            else if (score == 28)
            {
                last_round.gameObject.SetActive(true);
                run_music.PlayOneShot(new_level);
            }
        }
        if (x.tag == "packup_red")
        {
            x.gameObject.SetActive(false);
            score_red -= 25;
            scoretext_red.text = "Healthy:" + score_red + "%";
            run_music.PlayOneShot(red_pick);
            if (score_red <= 0)
            {
              
                run_music.Stop();
                run_music.PlayOneShot(lose_game);
                Thread.Sleep(3000);
                SceneManager.LoadScene(2);
            }
        }
        if (x.tag == "green")
        {
            Vector3 jumb = new Vector3(220.0f,1000.0f,200.0f);
            GetComponent<Rigidbody>().AddForce(mov+jumb);
            run_music.PlayOneShot(jumb_music);
        }
        if (x.tag == "finial")
        {
            run_music.Stop();
            run_music.PlayOneShot(win_game);
            Thread.Sleep(3000);
            SceneManager.LoadScene(3);

        }



    }
}
