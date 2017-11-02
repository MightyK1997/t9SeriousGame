using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class selectionScript : MonoBehaviour {
    MeshFilter[] roofs = new MeshFilter[5];
    MeshFilter[] walls = new MeshFilter[5];
    MeshFilter[] foundations = new MeshFilter[5];
    MeshFilter[] supports = new MeshFilter[5];
    //MeshFilter[] extras = new MeshFilter[5];
    MeshFilter[][] arrays = new MeshFilter[5][];

    Material[] roofMat = new Material[5];
    Material[] wallMat = new Material[5];
    Material[] foundationMat = new Material[5];
    Material[] supportMat = new Material[5];
    //Material[] extraMat = new Material[5];
    Material[][] matArray = new Material[5][];

    healthCalc hCalc;
    moneyCalc mCalc;

    public static Material prevMaterial;

    void Start() {
        arrays[0] = roofs;
        arrays[1] = walls;
        arrays[2] = foundations;
        arrays[3] = supports;
        //arrays[4] = extras;

        matArray[0] = roofMat;
        matArray[1] = wallMat;
        matArray[2] = foundationMat;
        matArray[3] = supportMat;
        //matArray[4] = extraMat;
    }

    public void selectPart(int choice) {
        int category;
        GameObject[] placeHolder = null;

        //Initialize meshes
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 5; j++) {
                 arrays[i][j] = GameObject.Find("BrickMatReplace").GetComponent<MeshFilter>();
            }
        }

        //Initialize materials
        for (int i = 0; i < 4; i++) {
            //for (int j = 0; j < 2; j++) {
            //    matArray[i][j] = GameObject.Find("test2").GetComponent<Renderer>().material;
            //}
            //for(int j = 2; j < 5; j++)
            //{
            //    matArray[i][j] = GameObject.Find("test3").GetComponent<Renderer>().material;
            //}

            matArray[i][0] = GameObject.Find("BrickMatReplace").GetComponent<Renderer>().material;
            matArray[i][1] = GameObject.Find("ConcreteMatReplace").GetComponent<Renderer>().material;
            matArray[i][2] = GameObject.Find("HouseWallMatReplace").GetComponent<Renderer>().material;
            matArray[i][3] = GameObject.Find("WoodMatReplace").GetComponent<Renderer>().material;
            matArray[i][4] = GameObject.Find("MetalMatReplace").GetComponent<Renderer>().material;
        }
        


        if (choice > 9 && choice < 20) {
            choice -= 10;
            category = 1;
        } else if (choice > 19 && choice < 30) {
            choice -= 20;
            category = 2;
        } else if (choice > 29 && choice < 40) {
            choice -= 30;
            category = 3;
        } else if (choice > 39) {
            choice -= 40;
            category = 4;
        } else {
            category = 0;
        }

        switch (category) {
            case 0:
                placeHolder = GameObject.FindGameObjectsWithTag("roof");
                break;
            case 1:
                placeHolder = GameObject.FindGameObjectsWithTag("wall");
                break;
            case 2:
                placeHolder = GameObject.FindGameObjectsWithTag("foundation");
                break;
            case 3:
                placeHolder = GameObject.FindGameObjectsWithTag("support");
                break;
            //case 4:
            //    placeHolder = GameObject.FindGameObjectsWithTag("extra");
            //    break;
        }
        foreach (var item in placeHolder)
        {


            prevMaterial = item.GetComponent<MeshRenderer>().material;
            Debug.Log(item.GetComponent<MeshRenderer>().enabled);
            //item.GetComponent<MeshFilter>().mesh = arrays[category][choice].mesh;
            item.GetComponent<MeshRenderer>().enabled = true;
            item.GetComponent<MeshRenderer>().material = matArray[category][choice];
            healthCalc.newUpdate(item);
            moneyCalc.newUpdate(item);
            if (moneyCalc.totalMoney < 0)
            {
                item.GetComponent<MeshRenderer>().material = prevMaterial;
                prevMaterial = matArray[category][choice];
                healthCalc.newUpdate(item);
                moneyCalc.newUpdate(item);
            }
        }
    }
}
