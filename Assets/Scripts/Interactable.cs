using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Interactable : MonoBehaviour
    {

        private Vector3 startingPosition;
        public float TimetoAct = 5f;
        public float TimeCounter = 0f;
        public bool isGazed = false;

        public void DistanceIdentifier()
        {

        }

        void OnTriggerEnter(Collider c)
        {
         if(c.gameObject.name == "Player")
             Debug.Log ("Player triggered");
         else
             Debug.Log ("Something else triggered");
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
        }

        public void Update()
        {
            if(isGazed)
            {
                if((TimeCounter += Time.deltaTime) >= TimetoAct)
                {
                    DoSomething();
                    TimeCounter = 0f;
                }
            }
        }

        private void Start()
        {
           /* startingPosition = transform.localPosition;
            myRenderer = GetComponent<Renderer>();
            SetGazedAt(false);*/
        }
    }
