using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    public Material normal;
    public Material active;
    private Renderer myRenderer;
    private Vector3 startingPosition;
    public float TimetoAct = 5f;
    public float TimeCounter = 0f;
    public bool isGazed = false;
    public bool ActiveState = false;
    public Interactable anterior;
    public MovimientoPuente puente;
    public int optionPuente;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    public void SetGazedAt(bool gazedAt)
    {
        Debug.Log("Me estan mirando");
        isGazed = gazedAt;

        if(!gazedAt)
            TimeCounter = 0f;

    }

    public void DoSomething()
    {
        Debug.Log("Hice algo");
        if(!ActiveState)
        {
            if(anterior == null)
            {
                ActiveState = true;
                myRenderer.material = active;
                puente.ActivateMovement(optionPuente);
            }
            else if(anterior.ActiveState == true)
            {
                ActiveState = true;
                myRenderer.material = active;
                puente.ActivateMovement(optionPuente);
            }

        }
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
