using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveObjectController : XRBaseInteractable
{
	public float reachRange = 1.8f;
    public int objectNumber = 0;

    private Animator anim;
	private Camera fpsCam;
	private GameObject player;

	private const string animBoolName = "isOpen_Obj_";

	private bool playerEntered;

	private int rayLayerMask;

    void Start()
	{
		//Initialize moveDrawController if script is enabled.
		player = GameObject.FindGameObjectWithTag("Player");

		fpsCam = Camera.main;

		//create AnimatorOverrideController to re-use animationController for sliding draws.
		anim = GetComponent<Animator>(); 
		anim.enabled = false;  //disable animation states by default.  

		//the layer used to mask raycast for interactable objects only
		LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
		rayLayerMask = 1 << iRayLM.value;

		objectNumber = GetComponent<MoveableObject>().objectNumber;

		//setup GUI style settings for user prompts
		//setupGui();

	}
		
	void OnTriggerEnter(Collider other)
	{		
		if (other.gameObject == player)		//player has collided with trigger
		{			
			playerEntered = true;

		}
	}

	void OnTriggerExit(Collider other)
	{		
		if (other.gameObject == player)		//player has exited trigger
		{			
			playerEntered = false;	
		}
	}

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        string paramName = "isOpen_Obj_" + objectNumber;
        bool isOpen = anim.GetBool(paramName);
        anim.SetBool(paramName, !isOpen);
    }
}
