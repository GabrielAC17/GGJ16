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
    private int fireHealth = 2;

    private bool isAirEnabled = false;

    private bool wait = false;
    public float waitTime = 3f;
    private float oritime;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        oritime = waitTime;
    }
	
	// Update is called once per frame
	void Update () {
        Waiter();

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
                GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("ResetSpecialAir");
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
                fireHealth = 2;
                isFireEnabled = false;
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
