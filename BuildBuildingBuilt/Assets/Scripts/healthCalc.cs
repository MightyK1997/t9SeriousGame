using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class healthCalc : MonoBehaviour {

    public static float houseHealth = 50;
    static int roofHealth;
    static int foundationHealth;
    static int wall1Health;
    static int wall2Health;
    static int supportHealth;
    static string path;
    static TextureDetails tHealth;
    static Material[] allTextures;
    static TextureDetails[] tHealthList;
    static List<GameObject> allObjectsInScreen;
    static int prevHealth;
	// Use this for initialization
	void Start () {
        
        path = Application.streamingAssetsPath + "/TextureDetails.json";
        string jsonString = File.ReadAllText(path);
        tHealthList = FromJson(jsonString);
    }

    private void Update()
    {
        if (houseHealth <= 0)
        {
            SceneManager.LoadScene(2);
            houseHealth = 50;
            moneyCalc.totalMoney = 1000;
        }
    }

    // Update is called once per frame
    public static void newUpdate () {
        allTagsToList();
        foreach (var item in tHealthList)
        {
            //Debug.Log(item.money);
            //foreach (var texture in allTextures)
            //{
            //    if (item.name == texture.name)
            //    {
            //        if (texture.name.Contains("roof"))
            //        {
            //            roofHealth = item.health;
            //        }
            //        if (texture.name.Contains("foundation"))
            //        {
            //            foundationHealth = item.health;
            //        }
            //        if (texture.name.Contains("wall1"))
            //        {
            //            wall1Health = item.health;
            //        }
            //        if (texture.name.Contains("wall2"))
            //        {
            //            wall2Health = item.health;
            //        }
            //        if (texture.name.Contains("support"))
            //        {
            //            supportHealth = item.health;
            //        }
            //    }
            //}
            if (selectionScript.prevMaterial.name.StartsWith(item.name))
            {
                prevHealth = item.health;
            }
            foreach (var newObject in allObjectsInScreen)
            {
                Debug.Log(newObject);
                //Debug.Log(newObject.GetComponent<MeshRenderer>().material.name.StartsWith(item.name));
                if (newObject.GetComponent<MeshRenderer>().material.name.StartsWith(item.name))
                {
                    roofHealth = item.health;
                }
            }
        }
        houseHealth -= (5 * prevHealth);
        houseHealth += (5 * roofHealth);
        //houseHealth = (roofHealth + foundationHealth + wall1Health + wall2Health + supportHealth).ToString();
    }


    public void buttonClicked()
    {
        GameObject roof = GameObject.FindGameObjectWithTag("roof");
        GameObject foundation = GameObject.FindGameObjectWithTag("foundation");
        GameObject wall1 = GameObject.FindGameObjectWithTag("wall");
        GameObject wall2 = GameObject.FindGameObjectWithTag("extra");
        GameObject support = GameObject.FindGameObjectWithTag("support");

        if (roof.activeSelf && foundation.activeSelf && wall1.activeSelf && wall2.activeSelf && support.activeSelf)
        {
            int subtractHealth = 50;
            houseHealth = houseHealth - subtractHealth;
        }
    }
    static void allTagsToList()
    {
        allObjectsInScreen = new List<GameObject>();
        GameObject placeHolder;
        placeHolder = GameObject.FindGameObjectWithTag("roof");
        Debug.Log(placeHolder);
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

[System.Serializable]
public class TextureDetails
{
    public string name;
    public int health;
    public int money;
}

[System.Serializable]
public class Wrapper
{
    public TextureDetails[] textures;
}