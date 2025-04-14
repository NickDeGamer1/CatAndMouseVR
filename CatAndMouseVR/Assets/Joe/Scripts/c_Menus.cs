using UnityEngine;
using UnityEngine.UI;

public class c_Menus : MonoBehaviour
{
    [SerializeField]
    private RawImage bkgImg;
    [SerializeField]
    private float img_x, img_y;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        bkgImg.uvRect = new Rect(bkgImg.uvRect.position + new Vector2(img_x, img_y) * Time.deltaTime, bkgImg.uvRect.size);

        //if (GameObject.FindWithTag("Player") != null)
        //{
            //bkgImg.CrossFadeColor(darkerColor, 2, true, false);
        //}
    }
}
