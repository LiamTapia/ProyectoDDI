using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class TemperatureSensor : MonoBehaviour {

    //public string brokerIpAddress = "";
	public string brokerEndPoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala/temperatura";
    public string hourTopic = "casa/sala/hora";
	private MqttClient client;

    private float reportRate = 5f;
    private float reportTimer;
    public float temperatureValue = 20.3f;
    public float hourValue = 14;
	
	// Use this for initialization
	void Start () {
		// create client instance 
		client = new MqttClient(brokerEndPoint, brokerPort, false, null); 
        //client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 		
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
		
	}

	void Update()
	{
        if(!client.IsConnected)
        {
            Debug.LogWarning("No conectado");
        }
		else if((reportTimer += Time.deltaTime) >= reportRate)
        {
            reportTimer = 0f;
            Debug.Log($"sending to topic {temperatureTopic}, value {temperatureValue}");
			string message = temperatureValue.ToString();
            client.Publish(temperatureTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            
            hourValue = ( hourValue + 2 ) % 24;
            Debug.Log($"sending to topic {hourTopic}, value {hourValue}");
			message = hourValue.ToString();
            client.Publish(hourTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            Debug.Log("sent");
        }
	}

    
    public void changeTemp(float aux)
    {
        temperatureValue += aux;
    }

}