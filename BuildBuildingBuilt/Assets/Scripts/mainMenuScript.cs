using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenuScript : MonoBehaviour {
    CanvasGroup[] groups;
    CanvasGroup[] ddGroups;
    int numberOfMenuObjects = 4;
    // Use this for initialization
    void Start () {
        groups = new CanvasGroup[] { GameObject.Find("roofButton").GetComponent<CanvasGroup>(), GameObject.Find("wallButton").GetComponent<CanvasGroup>(),
            GameObject.Find("foundationButton").GetComponent<CanvasGroup>(), GameObject.Find("supportButton").GetComponent<CanvasGroup>()/*, GameObject.Find("extraButton").GetComponent<CanvasGroup>()*/ };

        ddGroups = new CanvasGroup[] { GameObject.Find("RoofDD").GetComponent<CanvasGroup>(), GameObject.Find("WallDD").GetComponent<CanvasGroup>(), GameObject.Find("FoundationDD").GetComponent<CanvasGroup>(),
             GameObject.Find("SupportDD").GetComponent<CanvasGroup>()/*, GameObject.Find("ExtraDD").GetComponent<CanvasGroup>()*/ };


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void dropDown(int button) {
        if (ddGroups[button].alpha == 1.0f) {
            for (int i = 0; i < numberOfMenuObjects; i++) {
                groups[i].alpha = 1.0f;
                ddGroups[i].alpha = 0;
                ddGroups[i].interactable = false;
                ddGroups[i].blocksRaycasts = false;
            }
        } else {
            switch (button) {
                case 0:
                    for (int i = 1; i < numberOfMenuObjects ; i++) {
                        groups[i].alpha = 0.5f;
                        ddGroups[i].alpha = 0;
                        ddGroups[i].interactable = false;
                        ddGroups[i].blocksRaycasts = false;
                    }

                    break;
                case 1:
                    for (int i = 0; i < numberOfMenuObjects; i++) {
                        groups[i].alpha = 0.5f;
                        ddGroups[i].alpha = 0;
                        ddGroups[i].interactable = false;
                        ddGroups[i].blocksRaycasts = false;
                    }
                    break;
                case 2:
                    for (int i = 0; i < numberOfMenuObjects; i++) {
                        groups[i].alpha = 0.5f;
                        ddGroups[i].alpha = 0;
                        ddGroups[i].interactable = false;
                        ddGroups[i].blocksRaycasts = false;
                    }
                    break;
                case 3:
                    for (int i = 0; i < numberOfMenuObjects; i++) {
                        groups[i].alpha = 0.5f;
                        ddGroups[i].alpha = 0;
                        ddGroups[i].interactable = false;
                        ddGroups[i].blocksRaycasts = false;
                    }
                    break;
                //case 4:
                //    for (int i = 0; i < 5; i++) {
                //        groups[i].alpha = 0.5f;
                //        ddGroups[i].alpha = 0;
                //        ddGroups[i].interactable = false;
                //        ddGroups[i].blocksRaycasts = false;
                //    }
                //    break;
            }
            ddGroups[button].alpha = 1.0f;
            ddGroups[button].interactable = true;
            ddGroups[button].blocksRaycasts = true;
            groups[button].alpha = 1.0f;
        }
    }
}
