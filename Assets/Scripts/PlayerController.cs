using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject playerParents;
    private Animator animator;
    private float horizontal;
    private float vertical;

    public Joystick joystick;

    private string AnimationName = "Walk";
    private void Start()
    {
        animator = playerParents.transform.Find(PlayerInformationStatic.PrefabHero).gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.CompareTag("Player"))
        {
            GetInput();
        }
    }

    private void GetInput()
    {
        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;

        if (horizontal >= 0.5f)
        {
            transform.position += speed * Time.deltaTime * transform.right;
            animator.SetTrigger("NotBackWalk");
            animator.SetTrigger("NotLeftWalk");
            animator.SetTrigger("RightWalk");
            animator.SetTrigger("NotWalk");
            animator.SetTrigger("NotRun");
        }
        else if (horizontal <= -0.5f)
        {
            transform.position += speed * Time.deltaTime * -transform.right;
            animator.SetTrigger("NotBackWalk");
            animator.SetTrigger("NotRightWalk");
            animator.SetTrigger("LeftWalk");
            animator.SetTrigger("NotWalk");
            animator.SetTrigger("NotRun");
        }
        else if (vertical <= -0.5f)
        {
            transform.position += speed * Time.deltaTime * -transform.forward;
            animator.SetTrigger("NotWalk");
            animator.SetTrigger("NotRightWalk");
            animator.SetTrigger("NotLeftWalk");
            animator.SetTrigger("backWalk");
            animator.SetTrigger("NotRun");
        }
        else if (vertical >= 0.5f)
        {
            transform.position += speed * Time.deltaTime * transform.forward;
            animator.SetTrigger(AnimationName);
            animator.SetTrigger("NotRightWalk");
            animator.SetTrigger("NotLeftWalk");
            animator.SetTrigger("NotBackWalk");
        }
        else
        {
            animator.SetTrigger("NotWalk");
            animator.SetTrigger("NotBackWalk");
            animator.SetTrigger("NotRightWalk");
            animator.SetTrigger("NotLeftWalk");
            animator.SetTrigger("NotRun");
        }
    }

    public void PunchButtonClick()
    {
        animator.SetTrigger("Punch");
    }

    public void RunButtonDown()
    {
        AnimationName = "Run";
        speed = 9f;
    }

    public void RunButtonUp()
    { 
        AnimationName = "Walk";
        speed = 5f;
    }

    public void JumpButtonClick()
    {
        animator.SetTrigger("StayJump");
    }
}
