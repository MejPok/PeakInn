using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCamera : MonoBehaviour
{
    public static ControlCamera Instance;
    public GameObject camera;
    public Transform lobbyTransform;
    public Transform roomsTransform;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public bool ShowingLobby = true;
    public float cameraMoveSpeed;
    public float yPositionDifference = 0f;
    public float maxYPosition;
    public float minYPosition;
    public GameObject[] directionMoveCamera;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (ShowingLobby)
        {
            rightArrow.SetActive(true);
            leftArrow.SetActive(false);
            camera.transform.position = new Vector3(lobbyTransform.position.x, lobbyTransform.position.y, -10);
            yPositionDifference = 0;

            foreach (var obj in directionMoveCamera)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(true);
            camera.transform.position = new Vector3(roomsTransform.position.x, roomsTransform.position.y + (cameraMoveSpeed*yPositionDifference), -10);
            

            if(yPositionDifference >= maxYPosition)
            {
                yPositionDifference = maxYPosition;
            }
            if (yPositionDifference <= minYPosition)
            {
                yPositionDifference = minYPosition;
            }

            foreach(var obj in directionMoveCamera)
            {
                obj.SetActive(true);
            }
        }
    }

    public void ShowLobby(bool showingLobby)
    {
        ShowingLobby = showingLobby;
    }


}
