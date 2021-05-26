using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class MQTTButton : MonoBehaviour
{
    //public string brokerIpAddress = "";
    public string brokerEndPoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala/temperatura";
    public string hourTopic = "casa/sala/hora";
    private MqttClient client;
    string lastMessage;
    /*public GameObject acObject;
    volatile bool acState = false;
    bool actualACState = true;
    volatile bool dayState = true;
    public float temperatureUpperThreshold = 30f;
    public float temperatureLowerThreshold = 25f;
    public float dayHour = 6f;
    public float nightHour = 19f;
    public Light[] lights; */


    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(brokerEndPoint, brokerPort, false, null); 
        //client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 

        client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        client.Subscribe(new string[] { hourTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        /*if(dayState)
            for(int i = 0; i < lights.Length; i++)
                lights[i].enabled= false;*/
    }

    // Update is called once per frame
    void Update()
    {
       /* if(dayState != acObject.activeSelf)
        {
            acObject.SetActive(dayState);
            for(int i = 0; i < lights.Length; i++)
                lights[i].enabled= !dayState;
        }

        if(acState != actualACState)
        {
            actualACState = acState;
            lights[1].color = Color.red;
            for(int i = 0; i < lights.Length; i++)
            {
                if(acState)
                    lights[i].color = Color.red;
                else
                    lights[i].color = Color.blue;

            }
        }*/
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		
        if(e.Topic.Equals(hourTopic))
        {
            /*float hora;
            float.TryParse(lastMessage, out hora);*/
            
            Debug.Log("Hola");
            /*if(hora >= dayHour && hora < nightHour)
            {
                dayState = true;
                Debug.Log("dia");
            }
            else 
            {
                dayState = false;
                Debug.Log("noche");
            }*/
        }

        if(e.Topic.Equals(temperatureTopic))
        {
            /*float temp;
            float.TryParse(lastMessage, out temp);*/
            Debug.Log("Caca");
            /*if(temp >= temperatureUpperThreshold)
            {
                acState = true;
            }
            else if(temp <= temperatureLowerThreshold)
            {
                acState = false;
            }*/
        }
        
	}

}

