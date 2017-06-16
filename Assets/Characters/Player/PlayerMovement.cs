using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (AICharacterControl))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    //float walkMoveStopRadius = 0.2f;
    //[SerializeField]
    //float attackMoveStopRadius = 5f;

    [SerializeField]
    const int walkableLayerNumber = 8;
    [SerializeField]
    const int enemyLayerNumber = 9;

    public VirtualJoystick moveJoystick;

    ThirdPersonCharacter thirdPersonCharacter = null;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster = null;
    Vector3 currentDestination, clickPoint;
//    AICharacterControl aiCharacterControl = null;
    GameObject walkTarget = null;

	bool isInDirectMode = false;



    void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
//        aiCharacterControl = GetComponent<AICharacterControl>();
        walkTarget = new GameObject("walkTarget");

//        cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;
    }

//    void ProcessMouseClick(RaycastHit raycastHit, int layerHit)
//    {
//        switch (layerHit)
//        {
//            case enemyLayerNumber:
//                // navigate to enemy
//                GameObject enemy = raycastHit.collider.gameObject;
//                aiCharacterControl.SetTarget(enemy.transform);
//                break;
//            case walkableLayerNumber:
//                // navigate to point on the ground
//                walkTarget.transform.position = raycastHit.point;
//                aiCharacterControl.SetTarget(walkTarget.transform);
//                break;
//            default:
//                Debug.LogWarning("Don't know how to handle mouse click for player movement");
//                return;
//        }
//    }

	// Fixed update is called in sync with physics
    void Update()
	{
//		if (Input.GetKeyDown (KeyCode.G)) 		// G for gamepad. TODO  add to menu
//		{		
//			isInDirectMode = !isInDirectMode; // toggle mode
//			currentDestination = transform.position; // clear the click target
//		}
//		if (isInDirectMode) {
			ProcessDirectMovement ();
//		} else 
//		{
//			ProcessMouseMovement ();
//		}
	}
    
 // TODO make this get called again
	void ProcessDirectMovement()
	{	
		float h, v;
//		print ("Direct movement");
		if (moveJoystick.InputDirection != Vector3.zero) {
			h = moveJoystick.InputDirection.x;
			v = moveJoystick.InputDirection.z;
		} else {
			h = CrossPlatformInputManager.GetAxis ("Horizontal");
			v = CrossPlatformInputManager.GetAxis("Vertical");
		}

		// If  implement to mobile, change Input to CrossPlatformInputManager 

//		bool crouch = Input.GetKey(KeyCode.C);

//		if (moveJoystick.InputDirection != Vector3.zero) {
//			movement = moveJoystick.InputDirection;
//			thirdPersonCharacter.Move (movement, false, false);
//		} else {
			// calculate camera relative direction to move:
			Vector3 cameraForward = Vector3.Scale (Camera.main.transform.forward, new Vector3 (1, 0, 1)).normalized;
			Vector3 movement = v * cameraForward + h * Camera.main.transform.right;

			thirdPersonCharacter.Move (movement, false, false);
//		}
	}

//	void ProcessMouseMovement ()
//	{
//		if (Input.GetMouseButton (0)) {
////			print ("Cursor raycast hit layer: " + cameraRaycaster.layerHit);
//			clickPoint = cameraRaycaster.hit.point;
//			switch (cameraRaycaster.currentLayerHit) {
//			case Layer.Walkable:
//				currentDestination = ShortDestination (clickPoint, walkMoveStopRadius); 
//				break;
//			case Layer.Enemy:
//				currentDestination = ShortDestination (clickPoint, attackMoveStopRadius);
//				break;
//			default:
//				print ("UNEXPECTED LAYER FOUND!");
//				return;
//			}
//		}

//		WalkToDestination ();
	
//	}

	//void WalkToDestination ()
	//{
	//	var playerToClickPoint = currentDestination - transform.position;
	//	if (playerToClickPoint.magnitude >= 0) {
	//		thirdPersonCharacter.Move (playerToClickPoint, false, false);
	//	}
	//	else {
	//		thirdPersonCharacter.Move (Vector3.zero, false, false);
	//	}
	//}

	//Vector3 ShortDestination (Vector3 destination, float shortening) {

	//	Vector3 reductionVector = (destination - transform.position).normalized * shortening;
	//	return destination - reductionVector;
	//}

	//void OnDrawGizmos () {

	//	// Draw movement gizmos
	//	Gizmos.color = Color.black;
	//	Gizmos.DrawLine (transform.position, currentDestination);
	//	Gizmos.DrawSphere (currentDestination, 0.1f);
	//	Gizmos.DrawSphere (clickPoint, 0.15f);

	//	// Draw attack sphere
	//	Gizmos.color = new Color(255f, 0f, 0, .5f);
	//	Gizmos.DrawWireSphere (transform.position, attackMoveStopRadius);

	//}
  
}

