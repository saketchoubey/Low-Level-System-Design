﻿using System;

//I own a parking lot that can hold up to ’n’ cars at any given point in time.
//Each slot is given a number starting at 1 increasing with increasing distance from the entry point in steps of one. 
//I want to create an automated ticketing system that allows my customers to use my parking lot without human intervention.

//When a car enters my parking lot, I want to have a ticket issued to the driver. 
//The ticket issuing process includes us documenting the registration number (number plate) 
//and the color of the car and allocating an available parking slot to the car before actually 
//handing over a ticket to the driver (we assume that our customers are nice enough to always park in the slots allocated to them). 
//The customer should be allocated a parking slot that is nearest to the entry. At the exit, 
//the customer returns the ticket which then marks the slot they were using as being available.

//https://medium.com/@abhigulve06/parking-lot-low-level-design-in-java-2be46101daec


namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingLot p = new ParkingLot(100);
            p.IssueTicket("MH12KC6114", "Blue");
            p.IssueTicket("816249721654", "Blue");

            p.status();

            var ticket = p.tickets.Find(c => c._slotNumber == 1);
            decimal cost = p.EixtParking(ticket);
            p.status();

            Console.Read();
        }
    }
}

