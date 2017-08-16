using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botanmanager : MonoBehaviour
{	
    [SerializeField]
    Animator animator;
    //public GameObject leftbutton, rightbutton,
	public GameObject camer;
	public GameObject touch;

	touch script;

    void Start()
    {
		script = touch.GetComponent<touch> ();
        animator = camer.GetComponent<Animator>();
    }

    public int muki = 0;
	int touchinfo;

	void Update(){
		touchinfo = script.GetTouch ();
		if (touchinfo == 2) {
			rightchange ();
		}
		if (touchinfo == 1) {
			leftchange ();
		}
		if (touchinfo == -1) {
			mannnakabutton ();
		}
	}

	public void leftchange(){
        if (muki == 0)
        {
            //leftbutton.SetActive(false);
            animator.SetTrigger("centertolefttrigger");
            animator.SetInteger("where", 1);
        }
        if (muki == 1)
        {
            //rightbutton.SetActive(true);
            animator.SetTrigger("righttocentertrigger");
            animator.SetInteger("where", 4);
        }
        muki--;
		if (muki == -2) {
			muki = 2;
		}
    }
    public void rightchange()
    {
        if (muki == 0)
        {
            //rightbutton.SetActive(false);
            animator.SetTrigger("centertorighttrigger");
            animator.SetInteger("where", 3);
        }
        if (muki == -1)
        {
            //leftbutton.SetActive(true);
            animator.SetTrigger("lefttocentertrigger");
            animator.SetInteger("where", 2);
        }
        muki++;

    }
    public void mannnakabutton()
    {
        if (muki == 0)
        {
            SceneManager.LoadScene("StageSelect");
        }
         if (muki == -1)
         {
             SceneManager.LoadScene("automaticselectlevel");
         }
    }


}
