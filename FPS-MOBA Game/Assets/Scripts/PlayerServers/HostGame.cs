using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour {

    [SerializeField]
    private uint matchSize = 10;

    private string matchName;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;

        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetMatchName (string _name)
    {
        matchName = _name;
    }

    public void CreateMatch ()
    {
        if (matchName != "" && matchName != null)
        {
            Debug.Log("Creating Match: " + matchName + " with room for " + matchSize + " players.");

            networkManager.matchMaker.CreateMatch(matchName, matchSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
    }

}
