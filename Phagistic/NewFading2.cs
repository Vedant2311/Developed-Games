using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewFading2 : MonoBehaviour {

    public Image FadeImage;

    private float Speed;
    private float Transition;
    private bool IsInTransition;
    private bool IsShowing;

    public void Fade(bool Showing, float Speed)
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

        Transition += (IsShowing) ? Time.deltaTime * (1 / Speed) : -Time.deltaTime * (1 / Speed);
        FadeImage.color = Color.Lerp(new Color(255,255, 255, 0), Color.white, Transition);

        if ((Transition > 1) || (Transition < 0))
            IsInTransition = false;

    }

}
