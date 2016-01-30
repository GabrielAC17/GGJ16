using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetCombo : MonoBehaviour
{

    //Variáveis do timer (definível no editor)
    private bool wait = false;
    public float waitTime = 3.0f;
    private float oritime;

    //salva a atual combinação de teclas
    private int[] currentCombo;

    //diz qual é a rodada
    private int row = 1;

    // Use this for initialization
    void Start()
    {
        oritime = waitTime;
        currentCombo = new int[4];
        for (int i = 0; i < 4; i++)
        {
            currentCombo[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar a primeira tecla do combo
        if (Input.GetButtonDown("B1") && !wait)
        {
            currentCombo[0] = 1;
            Debug.Log(currentCombo[0]);
            wait = true;
        }
        else if (Input.GetButtonDown("B2") && !wait)
        {
            currentCombo[0] = 2;
            Debug.Log(currentCombo[0]);
            wait = true;
        }
        else if (Input.GetButtonDown("B3") && !wait)
        {
            currentCombo[0] = 3;
            Debug.Log(currentCombo[0]);
            wait = true;
        }

        

        //Verifica a segunda tecla do combo
        if (Input.GetButtonDown("B1") && wait && currentCombo[0] != 0 && row == 2)
        {
            currentCombo[1] = 1;
            Debug.Log(currentCombo[1]);
            ResetWaiter();
        }
        else if (Input.GetButtonDown("B2") && wait && currentCombo[0] != 0 && row == 2)
        {
            currentCombo[1] = 2;
            Debug.Log(currentCombo[1]);
            ResetWaiter();
        }
        else if (Input.GetButtonDown("B3") && wait && currentCombo[0] != 0 && row == 2)
        {
            currentCombo[1] = 3;
            Debug.Log(currentCombo[1]);
            ResetWaiter();
        }

        

        //Verifica a terceira tecla do combo
        if (Input.GetButtonDown("B1") && wait && currentCombo[0] != 0 && currentCombo[1] != 0 && row == 3)
        {
            currentCombo[2] = 1;
            ResetWaiter();
            Debug.Log(currentCombo[2]);
        }
        else if (Input.GetButtonDown("B2") && wait && currentCombo[0] != 0 && currentCombo[1] != 0 && row == 3)
        {
            currentCombo[2] = 2;
            ResetWaiter();
            Debug.Log(currentCombo[2]);
        }
        else if (Input.GetButtonDown("B3") && wait && currentCombo[0] != 0 && currentCombo[1] != 0 && row == 3)
        {
            currentCombo[2] = 3;
            ResetWaiter();
            Debug.Log(currentCombo[2]);
        }

        // Verifica a quarta tecla do combo
        if (Input.GetButtonDown("B1") && wait && currentCombo[0] != 0 && currentCombo[1] != 0 && currentCombo[2] != 0 && row == 4)
        {
            currentCombo[3] = 1;
            ResetWaiter();
            Debug.Log(currentCombo[3]);
            wait = false;
            Debug.Log(currentCombo);
        }
        else if (Input.GetButtonDown("B2") && wait && currentCombo[0] != 0 && currentCombo[1] != 0 && currentCombo[2] != 0 && row == 4)
        {
            currentCombo[3] = 2;
            ResetWaiter();
            Debug.Log(currentCombo[3]);
            wait = false;
            Debug.Log(currentCombo);
        }
        else if (Input.GetButtonDown("B3") && wait && currentCombo[0] != 0 && currentCombo[1] != 0 && currentCombo[2] != 0 && row == 4)
        {
            currentCombo[3] = 3;
            ResetWaiter();
            Debug.Log(currentCombo[3]);
            wait = false;
            Debug.Log(currentCombo);
        }


        //Verifica assim que o combo de 3 teclas foi pressionado
        if (currentCombo[0] != 0 && currentCombo[1] != 0 && currentCombo[2] != 0 && currentCombo[3] != 0)
        {
            //Definir quais serão as combinações de teclas referentes ao elemento desejado
            if (currentCombo[0] == 1 && currentCombo[1] == 2 && currentCombo[2] == 3 && currentCombo[3] == 1)
            {
                Debug.Log("Winner!");
            }
        }

        //libera a segunda tecla
        if (currentCombo[0] == 1 && Input.GetButtonUp("B1"))
        {
            row++;
        }
        else if (currentCombo[0] == 2 && Input.GetButtonUp("B2"))
        {
            row++;
        }
        else if (currentCombo[0] == 3 && Input.GetButtonUp("B3"))
        {
            row++;
        }

        //libera a terceira tecla
        if (currentCombo[1] != 1 && Input.GetButtonUp("B1"))
        {
            row++;
        }
        else if (currentCombo[1] != 2 && Input.GetButtonUp("B2"))
        {
            row++;
        }
        else if (currentCombo[1] != 3 && Input.GetButtonUp("B3"))
        {
            row++;
        }

        //libera a quarta tecla
        if (currentCombo[2] != 1 && Input.GetButtonUp("B1"))
        {
            row++;
        }
        else if (currentCombo[2] != 2 && Input.GetButtonUp("B2"))
        {
            row++;
        }
        else if (currentCombo[2] != 3 && Input.GetButtonUp("B3"))
        {
            row++;
        }

        //diminui e faz controle do tempo
        Waiter();
    }

    void Waiter()
    {
        //Faz a contagem regressiva do tempo
        if (wait)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                row = 1;
                ResetWaiter();
                Debug.Log("Don't Think too much!");
                for (int i = 0; i < 4; i++)
                {
                    currentCombo[i] = 0;
                }
            }
        }
    }

    void ResetWaiter()
    {
        //Volta o tempo para o original (default 3 segundos)
        wait = false;
        waitTime = oritime;
    }
}
