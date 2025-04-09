using UnityEngine;
using UnityEngine.InputSystem;

public class c_CatCameras : MonoBehaviour
{

    public Camera[] catCams = new Camera[] {null, null, null, null};

    public void UpdateCams(int catIndex)
    {
        switch (catIndex){

        case 1:

            catCams[0].rect = new Rect(0, 0, 1, 1);
            break;

        case 2:
            catCams[0].rect = new Rect(0, 0, 0.5f, 1);
            catCams[1].rect = new Rect(0.5f, 0, 0.5f, 1);
            break;

        case 3:
            catCams[0].rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            catCams[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            catCams[2].rect = new Rect(0.25f, 0, 0.5f, 0.5f);
            break;

        case 4:
            catCams[0].rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            catCams[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            catCams[2].rect = new Rect(0, 0, 0.5f, 0.5f);
            catCams[3].rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            break;
        }
    }
}
