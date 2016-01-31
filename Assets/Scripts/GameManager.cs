using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int health = 10;
    private int totalBlocks=0;

    private AudioSource audio;
    public AudioClip[] audioClip;
    public AudioSource au;

    public Text hp;
    public Text score;
    public Text[] temporarios;

    private bool isFireEnabled = false;
    private int fireHealth = 3;

    private bool isAirEnabled = false;

    private bool wait = false;
    public float waitTime = 3f;
    private float oritime;

    private bool isEarthEnabled = false;

    private bool waitAgua = true;
    public float waitTimeAgua = 15f;
    private float oritimeAgua;
    private int aguaReset = 0;
    
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        oritime = waitTime;
        oritimeAgua = waitTimeAgua;
    }

    void PlaySound(int clip, bool loop = false)
    {
        if (loop)
            au.loop = true;
        au.clip = audioClip[clip];
        au.Play();
    }

    // Update is called once per frame
    void Update () {
        Waiter();
        WaiterAgua();
        temporarios[0].text = "Water Timer: "+(int)waitTimeAgua;
        temporarios[1].text = "Fire Turns: " + fireHealth;

        hp.text = "Turns: "+health;
        score.text = "Score: ";

        if (health <= 0 || fireHealth<=0)
        {
            Gameover();   
        }
	}

    void Waiter()
    {
        if (wait)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                wait = false;
                waitTime = oritime;
                GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("ResetSpecial",3);
            }
        }
    }

    void WaiterAgua()
    {
        if (waitAgua)
        {
            waitTimeAgua -= Time.deltaTime;
            if (waitTimeAgua <= 0)
            {
                waitAgua = false;
                waitTimeAgua = oritimeAgua;
                Gameover();
            }
        }
    }

    void removeBlocks()
    {
        totalBlocks--;
    }

    void addBlocks()
    {
        totalBlocks++;
    }

    void addScore()
    {

    }

    void Gameover()
    {
        SceneManager.LoadScene(0);
    }

    void OKombo(int element)
    {
        audio.Play();
        health--;

        if (isFireEnabled)
        {
            fireHealth--;
            if (element == 2)
            {
                fireHealth = 3;
                isFireEnabled = false;
                GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("ResetSpecial", 1);
            }
        }
        if (isAirEnabled && element == 4)
        {
            health += 2;
            isAirEnabled = false;
        }
        
        if (waitAgua && element == 1)
        {
            waitAgua = false;
            waitTimeAgua = oritimeAgua;
            GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("ResetSpecial", aguaReset);
        }

        if (isEarthEnabled)
        {

        }
           
    }

    void Specials(int element)
    {
        switch (element)
        {
            case 1:
                waitAgua = true;
                Debug.Log("ok");
                break;
            case 2:
                isFireEnabled = true;
                break;
            case 3:
                isEarthEnabled = true;
                break;
            case 4:
                if (!wait )
                {
                    isAirEnabled = true;
                    wait = true;
                }
                break;
            default:
                break;
        }
    }
}
