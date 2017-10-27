using UnityEngine;
using System.Collections;

public class selectionScript : MonoBehaviour {
    MeshFilter[] roofs = new MeshFilter[5];
    MeshFilter[] walls = new MeshFilter[5];
    MeshFilter[] foundations = new MeshFilter[5];
    MeshFilter[] supports = new MeshFilter[5];
    MeshFilter[] extras = new MeshFilter[5];
    MeshFilter[][] arrays = new MeshFilter[5][];

    Material[] roofMat = new Material[5];
    Material[] wallMat = new Material[5];
    Material[] foundationMat = new Material[5];
    Material[] supportMat = new Material[5];
    Material[] extraMat = new Material[5];
    Material[][] matArray = new Material[5][];

    healthCalc hCalc;
    moneyCalc mCalc;

    void Start() {
        arrays[0] = roofs;
        arrays[1] = walls;
        arrays[2] = foundations;
        arrays[3] = supports;
        arrays[4] = extras;

        matArray[0] = roofMat;
        matArray[1] = wallMat;
        matArray[2] = foundationMat;
        matArray[3] = supportMat;
        matArray[4] = extraMat;
    }

    public void selectPart(int choice) {
        int category;
        GameObject placeHolder = null;

        //Initialize meshes
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                 arrays[i][j] = GameObject.Find("test2").GetComponent<MeshFilter>();
            }
        }

        //Initialize materials
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 2; j++) {
                matArray[i][j] = GameObject.Find("test2").GetComponent<Renderer>().material;
            }
            for(int j = 2; j < 5; j++)
            {
                matArray[i][j] = GameObject.Find("test3").GetComponent<Renderer>().material;
            }
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
                placeHolder = GameObject.FindGameObjectWithTag("roof");
                break;
            case 1:
                placeHolder = GameObject.FindGameObjectWithTag("wall");
                break;
            case 2:
                placeHolder = GameObject.FindGameObjectWithTag("foundation");
                break;
            case 3:
                placeHolder = GameObject.FindGameObjectWithTag("support");
                break;
            case 4:
                placeHolder = GameObject.FindGameObjectWithTag("extra");
                break;
        }

        placeHolder.GetComponent<MeshFilter>().mesh = arrays[category][choice].mesh;
        placeHolder.GetComponent<Renderer>().enabled = true;
        placeHolder.GetComponent<Renderer>().material = matArray[category][choice];
        healthCalc.newUpdate();
        moneyCalc.newUpdate();
    }
}
