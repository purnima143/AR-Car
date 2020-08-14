using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoPanel : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();

    }

    public void playSlide()
    {
        anim.Play("infoAnim");
    }
    public void closeSlide()
    {
        anim.Play("infoAnimReverse");
    }

}
