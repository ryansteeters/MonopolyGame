using System.Collections;
using System.Collections.Generic;

namespace Monopoly
{
    public class Player
    {
        private string name;
        private int money;
        private int currentSpace;
        private List<BoardSpace> properties;
        private int GOOJcards;//get out of jail cards
        private bool inJail;
        private int timeInJail;

        public Player(string playerName)
        {
            name = playerName;
            money = 1500;
            currentSpace = 0;
            properties = new List<BoardSpace>();
            GOOJcards = 0;
            inJail = false;
        }

        public string getName()
        {
            return name;
        }

        public int getMoney()
        {
            return money;
        }

        public int getSpace()
        {
            return currentSpace;
        }

        public List<BoardSpace> getProperties()
        {
            return properties;
        }

        public int getGOOJ()
        {
            return GOOJcards;
        }

        public bool playerJailed()
        {
            return inJail;
        }

        public int getTimeInJail()
        {
            return timeInJail;
        }

        public void setMoney(int amount)
        {
            money = amount;
        }

        public void setCurrentSpace(int index)
        {
            currentSpace = index;
        }

        public void addProperty(BoardSpace property)
        {
            properties.Add(property);
        }

        public void setGOOJ(int num)
        {
            GOOJcards = num;
        }

        public void setJailStatus(bool state)
        {
            inJail = state;
        }

        public void resetJailTime()
        {
            timeInJail = 0;
        }

        public void addJailTime()
        {
            timeInJail++;
        }

        public void removeProperty(BoardSpace toRemove)
        {
            properties.Remove(toRemove);
        }
    }
}

