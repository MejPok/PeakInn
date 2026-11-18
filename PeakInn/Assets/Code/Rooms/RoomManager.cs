using Assets.Code.Player;
using Assets.Code.Rooms;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    
    public List<Room> createdRooms = new List<Room>();
    public List<RoomType> roomTypes = new List<RoomType>();
    public Transform roomRoot;

    private void Awake() {
        Instance = this;
    }
    private void Start()
    {
        CreateNewRoom("Basic Room");
        CreateNewRoom("Basic Room");
    }

    Vector2 newRoomPosition()
    {
        int roomCount = createdRooms.Count;
        int rows = createdRooms.Count / 2;
        Vector2 position = new Vector2();
        if (roomCount % 2 == 0)
        {
            position.x = -4;
        } else
        {
            position.x = 4;
        }

        return new Vector2(roomRoot.position.x + position.x, roomRoot.position.y - (rows * 5));
    }


    public void CreateNewRoom(string roomType)
    {
        RoomType type = roomTypes.FirstOrDefault(x => x.Name == roomType);

        if(PlayerMoney.Instance.Money >= type.Cost)
        {
            var room = Instantiate(type.prefab, newRoomPosition(), Quaternion.identity);
            var roomComponent = room.GetComponent<Room>();

            roomComponent.roomId = createdRooms.Count;
            roomComponent.roomType = type;
            roomComponent.customersOccupying = 0;

            createdRooms.Add(roomComponent);

        }
        
    }


}
