using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int health = 10;
    private int totalBlocks=0;

    private AudioSource audio;

    public Text hp;
    public Text score;

    private bool isFireEnabled = false;
    private int fireHealth = 3;

    private bool isAirEnabled = false;

    private bool wait = false;
    public float waitTime = 3f;
    private float oritime;

    private bool waitAgua = false;
    public float waitTimeAgua = 15f;
    private float oritimeAgua;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        oritime = waitTime;
        oritimeAgua = waitTimeAgua;
    }
	
	// Update is called once per frame
	void Update () {
        Waiter();
        WaiterAgua();

        hp.text = "Jogadas: "+health;
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
                GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("ResetSpecial", 0);
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
            health += 3;
            isAirEnabled = false;
        }
            
    }

    void Specials(int element)
    {
        switch (element)
        {
            case 1:
                if (!waitAgua)
                    waitAgua = true;
                break;
            case 2:
                isFireEnabled = true;
                break;
            case 3:
                
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
