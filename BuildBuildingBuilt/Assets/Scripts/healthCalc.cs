using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class healthCalc : MonoBehaviour {

    public static float houseHealth = 500;
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
    public GameObject originVersion;
    public GameObject destroyedVersion;

    int woodMultiplier = 750;
    int brickMultiplier = 1500;
    int wallMultiplier = 1400;
    int metalMultiplier = 2000;
    int concreteMultiplier = 700;
    // Use this for initialization
    void Start() {

        path = Application.streamingAssetsPath + "/TextureDetails.json";
        string jsonString = File.ReadAllText(path);
        tHealthList = FromJson(jsonString);
    }

    private void Update() {
        if (houseHealth <= 0) {

            //Instantiate(destroyedVersion, transform.position, transform.rotation);
            //originVersion.SetActive(false);
            //Destroy(originVersion);
            StartCoroutine(loadNextScreen(2));

        }

        if (houseHealth > 500 && SceneManager.GetActiveScene().name.Equals("MainGameBuild"))
        {
            GameObject test = GameObject.Find("TestButton");
            test.GetComponent<CanvasGroup>().alpha = 1.0f;
            test.GetComponent<CanvasGroup>().interactable = true;
            test.GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
    }
    public void reset(int i)
    {
        StartCoroutine(loadOtherScreen(i));
    }
    IEnumerator loadNextScreen(int i)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(i);
        houseHealth = 500;
        moneyCalc.totalMoney = 5000;
    }

    IEnumerator loadOtherScreen(int i)
    {
        SceneManager.LoadScene(i);
        houseHealth = 500;
        moneyCalc.totalMoney = 5000;
        yield return new WaitForSeconds(0.0f);
    }
    // Update is called once per frame
    public static void newUpdate(GameObject newObject) {
        allTagsToList();
        foreach (var item in tHealthList) {
            if (selectionScript.prevMaterial.name.StartsWith(item.name)) {
                prevHealth = item.health;
            }
            if (newObject.GetComponent<MeshRenderer>().material.name.StartsWith(item.name)) {
                roofHealth = item.health;
            }
        }

        houseHealth -= (5 * prevHealth);
        houseHealth += (5 * roofHealth);
        prevHealth = 0;
        //houseHealth = (roofHealth + foundationHealth + wall1Health + wall2Health + supportHealth).ToString();
    }


    public void buttonClicked() {
        GameObject roof = GameObject.FindGameObjectWithTag("roof");
        GameObject foundation = GameObject.FindGameObjectWithTag("foundation");
        GameObject wall1 = GameObject.FindGameObjectWithTag("wall");
       // GameObject wall2 = GameObject.FindGameObjectWithTag("extra");
        GameObject support = GameObject.FindGameObjectWithTag("support");

        GameObject[] rObjects = GameObject.FindGameObjectsWithTag("roof");
        GameObject[] fObjects = GameObject.FindGameObjectsWithTag("foundation");
        GameObject[] wObjects = GameObject.FindGameObjectsWithTag("wall");
        GameObject[] sObjects = GameObject.FindGameObjectsWithTag("support");

        int woodCount = 0, metalCount= 0, wallCount = 0, concCount =0, brickCount = 0;

        foreach (var roofs in rObjects)
        {
            if (roofs.GetComponent<MeshRenderer>().material.name.StartsWith("wood"))
            {
                woodCount++;
            }
            if (roofs.GetComponent<MeshRenderer>().material.name.StartsWith("metal"))
            {
                metalCount++;
            }
            if (roofs.GetComponent<MeshRenderer>().material.name.StartsWith("brick"))
            {
                brickCount++;
            }
            if (roofs.GetComponent<MeshRenderer>().material.name.StartsWith("houseWall"))
            {
                wallCount++;
            }
            if (roofs.GetComponent<MeshRenderer>().material.name.StartsWith("concrete"))
            {
                concCount++;
            }
        }
        foreach (var foundations in fObjects)
        {
            if (foundations.GetComponent<MeshRenderer>().material.name.StartsWith("wood"))
            {
                woodCount++;
            }
            if (foundations.GetComponent<MeshRenderer>().material.name.StartsWith("metal"))
            {
                metalCount++;
            }
            if (foundations.GetComponent<MeshRenderer>().material.name.StartsWith("brick"))
            {
                brickCount++;
            }
            if (foundations.GetComponent<MeshRenderer>().material.name.StartsWith("houseWall"))
            {
                wallCount++;
            }
            if (foundations.GetComponent<MeshRenderer>().material.name.StartsWith("concrete"))
            {
                concCount++;
            }
        }
        foreach (var walls in wObjects)
        {
            if (walls.GetComponent<MeshRenderer>().material.name.StartsWith("wood"))
            {
                woodCount++;
            }
            if (walls.GetComponent<MeshRenderer>().material.name.StartsWith("metal"))
            {
                metalCount++;
            }
            if (walls.GetComponent<MeshRenderer>().material.name.StartsWith("brick"))
            {
                brickCount++;
            }
            if (walls.GetComponent<MeshRenderer>().material.name.StartsWith("houseWall"))
            {
                wallCount++;
            }
            if (walls.GetComponent<MeshRenderer>().material.name.StartsWith("concrete"))
            {
                concCount++;
            }
        }
        foreach (var supports in sObjects)
        {
            if (supports.GetComponent<MeshRenderer>().material.name.StartsWith("wood"))
            {
                woodCount++;
            }
            if (supports.GetComponent<MeshRenderer>().material.name.StartsWith("metal"))
            {
                metalCount++;
            }
            if (supports.GetComponent<MeshRenderer>().material.name.StartsWith("brick"))
            {
                brickCount++;
            }
            if (supports.GetComponent<MeshRenderer>().material.name.StartsWith("houseWall"))
            {
                wallCount++;
            }
            if (supports.GetComponent<MeshRenderer>().material.name.StartsWith("concrete"))
            {
                concCount++;
            }
        }


        if (roof.activeSelf && foundation.activeSelf && wall1.activeSelf && support.activeSelf) {
            houseHealth = houseHealth - ((woodCount * woodMultiplier) + (metalCount * metalMultiplier) + (brickCount * brickMultiplier) + (wallCount * wallMultiplier) + (concCount * concreteMultiplier));
        }

        StartCoroutine(sceneLoad());
    }

    IEnumerator sceneLoad()
    {
        yield return new WaitForSeconds(4);

        if(houseHealth > 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    static void allTagsToList() {
        allObjectsInScreen = new List<GameObject>();
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

    public static TextureDetails[] FromJson(string json) {
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