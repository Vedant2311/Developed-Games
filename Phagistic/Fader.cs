using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public GameObject Holder;
    private NewFading OtherNewFading;
    public Image FadingImage;

    private void Awake()
    {
        FadingImage.color = new Color(0, 0, 0);

        OtherNewFading = Holder.GetComponent<NewFading>();
        StartCoroutine(FadeHelper());
    }

    IEnumerator FadeHelper()
    {
        OtherNewFading.Fade(false, 1.4f);

        yield return new WaitForSeconds(3f);
        OtherNewFading.Fade(true, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("mainMenu");
    }

}
