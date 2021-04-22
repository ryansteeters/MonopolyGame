using System.Collections;
using System.Collections.Generic;

namespace Monopoly
{
    public class BoardSpace
    {
        private string name;
        private int spaceNumber;
        private Player ownedBy;
        private int cost;
        private int rent;
        private int mortgage;
        private bool isMortgaged;
        private int numHouses;
        private int housePrice;

        public BoardSpace(string spaceName, int price, int house)
        {
            name = spaceName;
            cost = price;
            housePrice = house;
            mortgage = cost/2;
            isMortgaged = false;
            ownedBy = null;
        }

        public BoardSpace(string spaceName, int price)
        {
            name = spaceName;
            cost = price;
            housePrice = 0;
            mortgage = cost / 2;
            isMortgaged = false;
            ownedBy = null;
        }

        public string getName()
        {
            return name;
        }

        public int getSpaceNumber()
        {
            return spaceNumber;
        }

        public Player getOwner()
        {
            return ownedBy;
        }

        public int getCost()
        {
            return cost;
        }

        public int getNumHouses()
        {
            return numHouses;
        }

        public int getHousePrice()
        {
            return housePrice;
        }

        public int getRent()
        {
            switch (name)
            {
                //Properties
                case ("Mediterranean Avenue"):
                    switch (numHouses)
                    {
                        case (0):

                            rent = 2;
                            break;
                        case (1):
                            rent = 10;
                            break;
                        case (2):
                            rent = 30;
                            break;
                        case (3):
                            rent = 90;
                            break;
                        case (4):
                            rent = 160;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 250;
                            break;
                    }
                    break;
                case ("Baltic Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 4;
                            break;
                        case (1):
                            rent = 20;
                            break;
                        case (2):
                            rent = 60;
                            break;
                        case (3):
                            rent = 180;
                            break;
                        case (4):
                            rent = 320;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 450;
                            break;
                    }
                    break;
                case ("Oriental Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 6;
                            break;
                        case (1):
                            rent = 30;
                            break;
                        case (2):
                            rent = 90;
                            break;
                        case (3):
                            rent = 270;
                            break;
                        case (4):
                            rent = 400;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 550;
                            break;
                    }
                    break;
                case ("Vermont Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 6;
                            break;
                        case (1):
                            rent = 30;
                            break;
                        case (2):
                            rent = 90;
                            break;
                        case (3):
                            rent = 270;
                            break;
                        case (4):
                            rent = 400;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 550;
                            break;
                    }
                    break;
                case ("Connecticut Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 8;
                            break;
                        case (1):
                            rent = 40;
                            break;
                        case (2):
                            rent = 100;
                            break;
                        case (3):
                            rent = 300;
                            break;
                        case (4):
                            rent = 450;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 600;
                            break;
                    }
                    break;
                case ("St. Charles Place"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 10;
                            break;
                        case (1):
                            rent = 50;
                            break;
                        case (2):
                            rent = 150;
                            break;
                        case (3):
                            rent = 450;
                            break;
                        case (4):
                            rent = 625;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 750;
                            break;
                    }
                    break;
                case ("States Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 10;
                            break;
                        case (1):
                            rent = 50;
                            break;
                        case (2):
                            rent = 150;
                            break;
                        case (3):
                            rent = 450;
                            break;
                        case (4):
                            rent = 625;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 750;
                            break;
                    }
                    break;
                case ("Virginia Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 12;
                            break;
                        case (1):
                            rent = 60;
                            break;
                        case (2):
                            rent = 180;
                            break;
                        case (3):
                            rent = 500;
                            break;
                        case (4):
                            rent = 700;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 900;
                            break;
                    }
                    break;
                case ("St. James Place"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 14;
                            break;
                        case (1):
                            rent = 70;
                            break;
                        case (2):
                            rent = 200;
                            break;
                        case (3):
                            rent = 550;
                            break;
                        case (4):
                            rent = 750;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 950;
                            break;
                    }
                    break;
                case ("Tennessee Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 14;
                            break;
                        case (1):
                            rent = 70;
                            break;
                        case (2):
                            rent = 200;
                            break;
                        case (3):
                            rent = 550;
                            break;
                        case (4):
                            rent = 750;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 950;
                            break;
                    }
                    break;
                case ("New York Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 16;
                            break;
                        case (1):
                            rent = 80;
                            break;
                        case (2):
                            rent = 220;
                            break;
                        case (3):
                            rent = 600;
                            break;
                        case (4):
                            rent = 800;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1000;
                            break;
                    }
                    break;
                case ("Kentucky Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 18;
                            break;
                        case (1):
                            rent = 90;
                            break;
                        case (2):
                            rent = 250;
                            break;
                        case (3):
                            rent = 700;
                            break;
                        case (4):
                            rent = 875;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1050;
                            break;
                    }
                    break;
                case ("Indiana Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 18;
                            break;
                        case (1):
                            rent = 90;
                            break;
                        case (2):
                            rent = 250;
                            break;
                        case (3):
                            rent = 700;
                            break;
                        case (4):
                            rent = 875;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1050;
                            break;
                    }
                    break;
                case ("Illinois Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 20;
                            break;
                        case (1):
                            rent = 100;
                            break;
                        case (2):
                            rent = 300;
                            break;
                        case (3):
                            rent = 750;
                            break;
                        case (4):
                            rent = 925;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1100;
                            break;
                    }
                    break;
                case ("Atlantic Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 22;
                            break;
                        case (1):
                            rent = 110;
                            break;
                        case (2):
                            rent = 330;
                            break;
                        case (3):
                            rent = 800;
                            break;
                        case (4):
                            rent = 975;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1150;
                            break;
                    }
                    break;
                case ("Ventnor Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 22;
                            break;
                        case (1):
                            rent = 110;
                            break;
                        case (2):
                            rent = 330;
                            break;
                        case (3):
                            rent = 800;
                            break;
                        case (4):
                            rent = 975;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1150;
                            break;
                    }
                    break;
                case ("Marvin Gardens"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 24;
                            break;
                        case (1):
                            rent = 120;
                            break;
                        case (2):
                            rent = 360;
                            break;
                        case (3):
                            rent = 850;
                            break;
                        case (4):
                            rent = 1025;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1200;
                            break;
                    }
                    break;
                case ("Pacific Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 26;
                            break;
                        case (1):
                            rent = 130;
                            break;
                        case (2):
                            rent = 390;
                            break;
                        case (3):
                            rent = 900;
                            break;
                        case (4):
                            rent = 1100;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1275;
                            break;
                    }
                    break;
                case ("North Carolina Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 26;
                            break;
                        case (1):
                            rent = 130;
                            break;
                        case (2):
                            rent = 390;
                            break;
                        case (3):
                            rent = 900;
                            break;
                        case (4):
                            rent = 1100;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1275;
                            break;
                    }
                    break;
                case ("Pennsylvania Avenue"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 28;
                            break;
                        case (1):
                            rent = 150;
                            break;
                        case (2):
                            rent = 450;
                            break;
                        case (3):
                            rent = 1000;
                            break;
                        case (4):
                            rent = 1200;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1400;
                            break;
                    }
                    break;
                case ("Park Place"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 35;
                            break;
                        case (1):
                            rent = 175;
                            break;
                        case (2):
                            rent = 500;
                            break;
                        case (3):
                            rent = 1100;
                            break;
                        case (4):
                            rent = 1300;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 1500;
                            break;
                    }
                    break;
                case ("Boardwalk"):
                    switch (numHouses)
                    {
                        case (0):
                            //TODO - if Baltic owned by same player rent * 2
                            rent = 50;
                            break;
                        case (1):
                            rent = 200;
                            break;
                        case (2):
                            rent = 600;
                            break;
                        case (3):
                            rent = 1400;
                            break;
                        case (4):
                            rent = 1700;
                            break;
                        //5 houses = 1 hotel
                        case (5):
                            rent = 2000;
                            break;
                    }
                    break;
            }




            return rent;
        }

        public int getMortgage()
        {
            return mortgage;
        }

        public bool getMortgageStatus()
        {
            return isMortgaged;
        }

        public bool hasHouses()
        {
            if (numHouses > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setOwner(Player owner)
        {
            ownedBy = owner;
        }

        public void setSpaceNumber(int index)
        {
            spaceNumber = index;
        }

        public void setRent(int rentPrice)
        {
            rent = rentPrice;
        }

        public void setNumHouses(int num)
        {
            numHouses = num;
        }

        public void setMortgageStatus(bool mortgaged)
        {
            isMortgaged = mortgaged;
        }
       
    }
}
