using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public float TimetoAct = 5f;
    public float TimeCounter = 0f;
    public bool isGazed = false;
    public bool ActiveState = false;
    public int buttonType;
    public GameObject MenuOpciones;
    public AudioSource audioButton;

    public void SetGazedAt(bool gazedAt)
    {
        audioButton.Play();
        Debug.Log("Me estan mirando");
        isGazed = gazedAt;

        if(!gazedAt)
            TimeCounter = 0f;

    }

    public void DoSomething()
    {
        Debug.Log("Hice algo");
        
        switch(buttonType){
            case 0:
                IniciarNivel();
                break;
            case 1: 
                SalirApp();
                break;
            case 2:
                Reanudar();
                break;
            case 3: 
                SalirNivel();
                break;
        }

        
    }

    public void IniciarNivel()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void SalirApp()
    {
        Application.Quit();
    }

    public void Reanudar()
    {
        MenuOpciones.SetActive(false);
    }

    public void SalirNivel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    

    public void Update()
    {
        if(isGazed && !ActiveState)
        {
            if((TimeCounter += Time.deltaTime) >= TimetoAct)
            {
                DoSomething();
                TimeCounter = 0f;
            }
        }
    }
}
