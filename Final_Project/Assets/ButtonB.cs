using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonB : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public Animator anim;

    void Start()
    {
        id = transform.GetSiblingIndex();
    }

    void OnMouseDown()
    {
       if (!GameController.simonIsSaying)
        {
            Action();
            GameController.Instance.PlayerAction(this);
        }
        
    }

    // Update is called once per frame
    public void Action()
    {
        anim.enabled = true;
        anim.SetTrigger("pop");
    }
}
