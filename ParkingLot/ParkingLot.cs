using System;
using System.Collections.Generic;

//I own a parking lot that can hold up to ’n’ cars at any given point in time.
//Each slot is given a number starting at 1 increasing with increasing distance from the entry point in steps of one. 
//I want to create an automated ticketing system that allows my customers to use my parking lot without human intervention.

//When a car enters my parking lot, I want to have a ticket issued to the driver. 
//The ticket issuing process includes us documenting the registration number (number plate) 
//and the color of the car and allocating an available parking slot to the car before actually 
//handing over a ticket to the driver (we assume that our customers are nice enough to always park in the slots allocated to them). 
//The customer should be allocated a parking slot that is nearest to the entry. At the exit, 
//the customer returns the ticket which then marks the slot they were using as being available.


namespace ParkingLot
{
    public class ParkingLot
    {
        public int _numberOfSlots;
        public List<Ticket> tickets;
        public bool[] slots;

        public ParkingLot(int numberOfSlots)
        {
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine("**********************  WELCOME TO PARKING SYSTEM APPLICATION  ************************");
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine("Creting parkinglot with {0} slots", numberOfSlots);
            _numberOfSlots = numberOfSlots;
            slots = new bool[_numberOfSlots];
            tickets = new List<Ticket>();
        }

        public int GetParkingSlot()
        {
            int slotNumber = int.MinValue;
            for (int i = 0; i < _numberOfSlots; i++)
            {
                if (!slots[i])
                {
                    slotNumber = i;
                    slots[i] = true;
                    break;
                }
            }
            return slotNumber;
        }

        public Ticket IssueTicket(string carNumber, string color)
        {
            int slot = GetParkingSlot();
            if (slot == int.MinValue)
            {
                Console.WriteLine("No parking slot is available");
            }
            else
            {
                Console.WriteLine("Allocated slot number: {0}", slot);
            }
            Ticket ticket = new Ticket(carNumber, color, slot, new DefaultParkingCostStrategy());
            tickets.Add(ticket);
            return ticket;
        }

        public void status()
        {
            Console.WriteLine();
            foreach (Ticket T in tickets)
            {
                Console.WriteLine("Slot No.  Registration No   Color");
                Console.WriteLine("{0}  {1}   {2}", T._slotNumber, T._carNumber, T._carColor);
            }
        }

        public decimal EixtParking(Ticket t)
        {
            slots[t._slotNumber] = false;
            tickets.Remove(t);
            Console.WriteLine("Exiting vhicle {0}", t._carNumber);
            Console.WriteLine("Generating Invoice for {0}", t._carNumber);
            return t._costStrategy.getParkingCost(2);
        }
    }
}

