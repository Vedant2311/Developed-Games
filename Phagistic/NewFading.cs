using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewFading : MonoBehaviour {

    public Image FadeImage;

    private float Speed;
    private float Transition;
    private bool IsInTransition;
    private bool IsShowing;

    public void Fade (bool Showing, float Speed)
    {
        this.Speed = Speed;
        IsShowing = Showing;
        IsInTransition = true;

        Transition = (IsShowing) ? 0 : 1;

    }

    private void Update()
    {
        if (!IsInTransition)
            return;

        Transition += (IsShowing) ? Time.deltaTime * (1/Speed) : -Time.deltaTime * (1 / Speed);
        FadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, Transition);

        if ((Transition > 1) || (Transition < 0))
            IsInTransition = false;

    }



}
