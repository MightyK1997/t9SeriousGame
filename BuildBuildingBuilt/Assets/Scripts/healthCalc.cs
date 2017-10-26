using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class healthCalc : MonoBehaviour {

    public static string houseHealth;
    int roofHealth;
    int foundationHealth;
    int wall1Health;
    int wall2Health;
    int supportHealth;
    string path;
    Material[] allTextures;
    List<TextureHealth> tHealthList = new List<TextureHealth>();
	// Use this for initialization
	void Start () {
        allTextures = Resources.FindObjectsOfTypeAll(typeof(Material)) as Material[];
        path = Application.streamingAssetsPath + "/TextureHealth.json";
        string jsonString = File.ReadAllText(path);
        TextureHealth tHealth = JsonUtility.FromJson<TextureHealth>(jsonString);
        tHealthList.Add(tHealth);
        foreach (var item in tHealthList)
        {
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

            if (item.name == "Cube")
            {
                roofHealth = item.health;
            }
        }
        houseHealth = (5 * roofHealth).ToString();
            //houseHealth = (roofHealth + foundationHealth + wall1Health + wall2Health + supportHealth).ToString();

    }
	
	// Update is called once per frame
	void Update () {

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
            roofHealth -= 50;
            houseHealth = (5 * roofHealth).ToString();
        }
    }



}

[System.Serializable]
public class TextureHealth
{
    public string name;
    public int health;
}
