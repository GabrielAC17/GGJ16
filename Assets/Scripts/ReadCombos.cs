using UnityEngine;
using System.Collections;

public class ReadCombos : MonoBehaviour
{
    //Valores aleatórios que gerarão os combos
    private int[] comboAgua;
    private int[] comboFogo;
    private int[] comboTerra;
    private int[] comboAr;

    //Preencherá as strings de acordo com os valores int gerados no começo
    private string[] SAgua;
    private string[] SFogo;
    private string[] STerra;
    private string[] SAr;

    private int j = 0;
    private bool isComboCreated = false;

    private KeyCombo CAgua;
    private KeyCombo CFogo;
    private KeyCombo CTerra;
    private KeyCombo CAr;

    private bool wait = false;
    public float waitTime = 1f;
    private float oritime;

    // Use this for initialization
    void Start()
    {
        oritime = waitTime;
        
        //Inicialização de arrays
        comboAgua = new int[4];
        comboFogo = new int[4];
        comboTerra = new int[4];
        comboAr = new int[4];

        SAgua = new string[4];
        SFogo = new string[4];
        STerra = new string[4];
        SAr = new string[4];
    }

    // Update is called once per frame
    void Update()
    {
        Waiter();

        GenerateCombos();
        //se terminou de gerar os combos
        if (GenerateComboStrings() && !isComboCreated)
        {
            CAgua = new KeyCombo(SAgua);
            CFogo = new KeyCombo(SFogo);
            CTerra = new KeyCombo(STerra);
            CAr = new KeyCombo(SAr);
            isComboCreated = true;
            Debug.Log("Created Random Combos!");
        }
        if (isComboCreated && CAgua.Check() && !wait)
        {
            Debug.Log("AGUA BREAKER");
            GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("destroyBlocks", 1);
            GameObject.FindGameObjectWithTag("GameManager").SendMessage("OKombo",1);
            wait = true;
        }
        else if (isComboCreated && CFogo.Check() && !wait)
        {
            Debug.Log("And everything changed when the fire nation attacked.");
            GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("destroyBlocks", 2);
            GameObject.FindGameObjectWithTag("GameManager").SendMessage("OKombo",2);
            wait = true;
        }
        else if(isComboCreated && CTerra.Check() && !wait)
        {
            Debug.Log("TERRA BREAKER");
            GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("destroyBlocks", 3);
            GameObject.FindGameObjectWithTag("GameManager").SendMessage("OKombo",3);
            wait = true;
        }
        else if(isComboCreated && CAr.Check() && !wait)
        {
            Debug.Log("AVATAR");
            GameObject.FindGameObjectWithTag("DestroyArea").SendMessage("destroyBlocks", 4);
            GameObject.FindGameObjectWithTag("GameManager").SendMessage("OKombo",4);
            wait = true;
        }
    }

    void GenerateCombos()
    {
        if (j == 0)
        {
            comboAgua[j] = Random.Range(1, 4);
            comboFogo[j] = Random.Range(1, 4);
            comboTerra[j] = Random.Range(1, 4);
            comboAr[j] = Random.Range(1, 4);
            j++;
        }
        if (j == 1)
        {
            comboAgua[j] = Random.Range(1, 4);
            comboFogo[j] = Random.Range(1, 4);
            comboTerra[j] = Random.Range(1, 4);
            comboAr[j] = Random.Range(1, 4);
            j++;
        }
        if (j == 2)
        {
            comboAgua[j] = Random.Range(1, 4);
            comboFogo[j] = Random.Range(1, 4);
            comboTerra[j] = Random.Range(1, 4);
            comboAr[j] = Random.Range(1, 4);
            j++;
        }
        if (j == 3)
        {
            comboAgua[j] = Random.Range(1, 4);
            comboFogo[j] = Random.Range(1, 4);
            comboTerra[j] = Random.Range(1, 4);
            comboAr[j] = Random.Range(1, 4);
            j++;
        }
    }

    bool GenerateComboStrings()
    {
        if (j == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                switch (comboAgua[i])
                {
                    case 1:
                        SAgua[i] = "B1";
                        break;
                    case 2:
                        SAgua[i] = "B2";
                        break;
                    case 3:
                        SAgua[i] = "B3";
                        break;
                    default:
                        break;
                }
                switch (comboFogo[i])
                {
                    case 1:
                        SFogo[i] = "B1";
                        break;
                    case 2:
                        SFogo[i] = "B2";
                        break;
                    case 3:
                        SFogo[i] = "B3";
                        break;
                    default:
                        break;
                }


                switch (comboTerra[i])
                {
                    case 1:
                        STerra[i] = "B1";
                        break;
                    case 2:
                        STerra[i] = "B2";
                        break;
                    case 3:
                        STerra[i] = "B3";
                        break;
                    default:
                        break;
                }


                switch (comboAr[i])
                {
                    case 1:
                        SAr[i] = "B1";
                        break;
                    case 2:
                        SAr[i] = "B2";
                        break;
                    case 3:
                        SAr[i] = "B3";
                        break;
                    default:
                        break;
                }
            }
        }
        return true;
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
            }
        }
    }
}
