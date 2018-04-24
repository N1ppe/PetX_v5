using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuImageChanger : MonoBehaviour {

    public Sprite[] MenuImages;
    bool AllowImageChange;
    public bool IsFirstImage;

    // Use this for initialization
    void Start() {
        gameObject.GetComponent<Image>().sprite = MenuImages[3];
        AllowImageChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFirstImage == false)
        {
            StartCoroutine(SecondImageDelay());
        }

        else
        {
            while (AllowImageChange == true)
            {
                

                StartCoroutine(ImageDelay());
            }
        }
    }

    void ChangeImage()
    {
        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            gameObject.GetComponent<Image>().sprite = MenuImages[0];
        }
        else if (rand == 1)
        {
            gameObject.GetComponent<Image>().sprite = MenuImages[1];
        }
        else if (rand == 2)
        {
            gameObject.GetComponent<Image>().sprite = MenuImages[2];
        }
        else if (rand == 3)
        {
            gameObject.GetComponent<Image>().sprite = MenuImages[3];
        }
    }

    private IEnumerator SecondImageDelay()
    {
        yield return new WaitForSeconds(4f);
        IsFirstImage = true;
    }

    private IEnumerator ImageDelay()
    {
        AllowImageChange = false;

        yield return new WaitForSeconds(4f);

        this.gameObject.GetComponent<Image>().CrossFadeAlpha(0, 2f, false);

        yield return new WaitForSeconds(4f);

        this.gameObject.GetComponent<Image>().CrossFadeAlpha(1, 2f, false);

        ChangeImage();
        
        AllowImageChange = true;
    }
}
