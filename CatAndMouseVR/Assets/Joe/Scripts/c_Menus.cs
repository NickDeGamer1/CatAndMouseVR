using UnityEngine;
using UnityEngine.UI;

public class c_Menus : MonoBehaviour
{
    [SerializeField]
    private RawImage bkgImg;
    [SerializeField]
    private float img_x, img_y;

    // Update is called once per frame
    void Update()
    {
        bkgImg.uvRect = new Rect(bkgImg.uvRect.position + new Vector2(img_x, img_y) * Time.deltaTime, bkgImg.uvRect.size);
    }
}
