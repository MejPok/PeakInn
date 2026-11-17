using Assets.Code.Customers;
using Assets.Code.Player;
using Assets.Code.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;
    public GameObject CustomerPrefab;
    public Transform LastCustomerSpawnPointPosition;
    public int Reputation;
    public string currentEvent;
    public int WarmthRequiredMultiplier;
    
    public int CustomersInQueue;

    public List<CustomerBehaviour> customersHosted = new List<CustomerBehaviour>();

    public int maxId;
    private void Start()
    {
        Instance = this;
        RoundControl.Instance.startDayEvent += NewDay;
    }

    public void CustomerServed()
    {
        Debug.Log("Customer Served");
        CustomersInQueue--;
    }

    public void NewDay()
    {
        UpdateCustomersStay();

        var random = new System.Random();
        CustomersInQueue = random.Next(2, Math.Max(2 , Reputation / 2));

        for(int i = 0; i < CustomersInQueue; i++)
        {
            CreateAnCustomer();
        }


    }
    public void CreateAnCustomer()
    {
        var customer = Instantiate(CustomerPrefab, transform.position, Quaternion.identity);
        var behaviour = customer.GetComponent<CustomerBehaviour>();
        behaviour.Needs = NewCustomerNeed();
        maxId += 1;
        behaviour.id = maxId;
        GetComponent<QueueControl>().customersInQueue.Add(customer);
    }

    public CustomerNeed NewCustomerNeed()
    {
        var random = new System.Random();

        var needs = new CustomerNeed();

        needs.MinWarmthRequired = Math.Min( random.Next(10, WarmthRequiredMultiplier * 50) ,100);
        needs.FoodRequiredPerNight = random.Next(1, 5);
        needs.StayForDays = random.Next(1, 4);
        needs.MoneyPerNight = random.Next(10, (int)(20 * Math.Max(1f, ((float)Reputation / (float)4) ) ));

        return needs;

    }

    public void UpdateCustomersStay()
    {
        for(int i = 0; i < customersHosted.Count; i++)
        {
            var customer = customersHosted[i];
            customer.Needs.StayForDays -= 1;
            PlayerMoney.Instance.Money += customer.Needs.MoneyPerNight;
            if (customer.Needs.StayForDays <= 0)
            {
                customersHosted.Remove(customer);
                i--;
            }
        }
    }
}
