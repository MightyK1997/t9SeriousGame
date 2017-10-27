using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class moneyCalc : MonoBehaviour {

    static int subtractMoney;
    static string path;
    public static float totalMoney = 1000;
    static TextureDetails[] tDetails;
    static List<GameObject> allObjectsInScreen = new List<GameObject>();
    // Use this for initialization
    void Start () {
        allTagsToList();
        path = Application.streamingAssetsPath + "/TextureDetails.json";
        string jsonString = File.ReadAllText(path);
        tDetails = FromJson(jsonString);
        Debug.Log(tDetails);
    }
	
	// Update is called once per frame
	public static void newUpdate () {
        foreach (var item in tDetails)
        {
            Debug.Log(item.money);
            foreach (var newObject in allObjectsInScreen)
            {
                //Debug.Log(newObject.GetComponent<MeshRenderer>().material.name);
                if (newObject.GetComponent<MeshRenderer>().material.name.StartsWith(item.name))
                {
                    subtractMoney = item.money;
                }
            }
        }
        totalMoney -= subtractMoney;
	}

    void allTagsToList()
    {
        GameObject placeHolder;
        placeHolder = GameObject.FindGameObjectWithTag("roof");
        allObjectsInScreen.Add(placeHolder);
        placeHolder = GameObject.FindGameObjectWithTag("wall");
        allObjectsInScreen.Add(placeHolder);
        placeHolder = GameObject.FindGameObjectWithTag("foundation");
        allObjectsInScreen.Add(placeHolder);
        placeHolder = GameObject.FindGameObjectWithTag("support");
        allObjectsInScreen.Add(placeHolder);
        placeHolder = GameObject.FindGameObjectWithTag("extra");
        allObjectsInScreen.Add(placeHolder);
    }


    public static TextureDetails[] FromJson(string json)
    {
        Wrapper wrapper = UnityEngine.JsonUtility.FromJson<Wrapper>(json);
        return wrapper.textures;
    }
}
