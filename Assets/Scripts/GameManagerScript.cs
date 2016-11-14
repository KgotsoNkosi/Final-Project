﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManagerScript : NetworkManager
{

    public int chosenCharacter = 0;

    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        Debug.Log("server add with message " + selectedClass);

        if (selectedClass == 0)
        {
            GameObject player = Instantiate(Resources.Load("AirShipNetwork(camera)", typeof(GameObject)) ) as GameObject;
            player.name = "AirShipCNetwork(camera)";
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            //ClientScene.RegisterPrefab(player);
        }

        if (selectedClass == 1)
        {
            GameObject player = Instantiate(Resources.Load("groundCarNetwork(camera)", typeof(GameObject))) as GameObject;
            player.name = "groundCarNetwork(camera)";
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
           // ClientScene.RegisterPrefab(player);

        }
    }


    public override void OnClientConnect(NetworkConnection conn)
    {
        NetworkMessage test = new NetworkMessage();
        test.chosenClass = chosenCharacter;

        ClientScene.AddPlayer(conn, 0, test);
    }


    public void btn1()
    {
        chosenCharacter = 0;
    }

    public void btn2()
    {
        chosenCharacter = 1;
    }
}
