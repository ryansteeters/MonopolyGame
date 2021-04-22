using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    class Program
    {
        static BoardSpace[] boardSpaces = new BoardSpace[40];

        static ModifierCard[] chanceCards = new ModifierCard[16];

        static ModifierCard[] communityChestCards = new ModifierCard[16];

        static List<Player> playerList = new List<Player>();

        static Random rand = new Random();

        //Initialize each property/space of game board boardSpaces[]
        static void populateBoard()
        {
            boardSpaces[0] = new BoardSpace("Go", 0);
            boardSpaces[1] = new BoardSpace("Mediterranean Avenue", 60, 50);
            boardSpaces[2] = new BoardSpace("Community Chest", 0);
            boardSpaces[3] = new BoardSpace("Baltic Avenue", 60, 50);
            boardSpaces[4] = new BoardSpace("Income Tax", 0);
            boardSpaces[5] = new BoardSpace("Reading Railroad", 200);
            boardSpaces[6] = new BoardSpace("Oriental Avenue", 100, 50);
            boardSpaces[7] = new BoardSpace("Chance", 0);
            boardSpaces[8] = new BoardSpace("Vermont Avenue", 100, 50);
            boardSpaces[9] = new BoardSpace("Connecticut Avenue", 120, 50);
            boardSpaces[10] = new BoardSpace("Jail", 0);
            boardSpaces[11] = new BoardSpace("St. Charles Place", 140, 100);
            boardSpaces[12] = new BoardSpace("Electric Company", 150);
            boardSpaces[13] = new BoardSpace("States Avenue", 140, 100);
            boardSpaces[14] = new BoardSpace("Virginia Avenue", 160, 100);
            boardSpaces[15] = new BoardSpace("Pennsylvania Railroad", 200);
            boardSpaces[16] = new BoardSpace("St. James Place", 180, 100);
            boardSpaces[17] = new BoardSpace("Community Chest", 0);
            boardSpaces[18] = new BoardSpace("Tennessee Avenue", 180, 100);
            boardSpaces[19] = new BoardSpace("New York Avenue", 200, 100);
            boardSpaces[20] = new BoardSpace("Free Parking", 0);
            boardSpaces[21] = new BoardSpace("Kentucky Avenue", 220, 150);
            boardSpaces[22] = new BoardSpace("Chance", 0);
            boardSpaces[23] = new BoardSpace("Indiana Avenue", 220, 150);
            boardSpaces[24] = new BoardSpace("Illinois Avenue", 240, 150);
            boardSpaces[25] = new BoardSpace("B. & O. Railroad", 200);
            boardSpaces[26] = new BoardSpace("Atlantic Avenue", 260, 150);
            boardSpaces[27] = new BoardSpace("Ventnor Avenue", 260, 150);
            boardSpaces[28] = new BoardSpace("Water Works", 150);
            boardSpaces[29] = new BoardSpace("Marvin Gardens", 280, 150);
            boardSpaces[30] = new BoardSpace("Go To Jail", 0);
            boardSpaces[31] = new BoardSpace("Pacific Avenue", 300, 200);
            boardSpaces[32] = new BoardSpace("North Carolina Avenue", 300, 200);
            boardSpaces[33] = new BoardSpace("Community Chest", 0);
            boardSpaces[34] = new BoardSpace("Pennsylvania Avenue", 320, 200);
            boardSpaces[35] = new BoardSpace("Short Line", 200);
            boardSpaces[36] = new BoardSpace("Chance", 0);
            boardSpaces[37] = new BoardSpace("Park Place", 350, 200);
            boardSpaces[38] = new BoardSpace("Luxury Tax", 0);
            boardSpaces[39] = new BoardSpace("Boardwalk", 400, 200);
        }

        //Assign index parameter of each space on board
        static void setIndexes()
        {
            for (int i = 0; i < 40; i++)
            {
                boardSpaces[i].setSpaceNumber(i);
            }
        }

        static void setChance()
        {
            chanceCards[0] = new ModifierCard("chance", "Advance to GO", "moveTo00");
            chanceCards[1] = new ModifierCard("chance", "Advance to Illinois Avenue. If you pass GO collect $200", "moveTo24");
            chanceCards[2] = new ModifierCard("chance", "Advance to St. Charles Place If you pass GO collect $200", "moveTo16");
            chanceCards[3] = new ModifierCard("chance", "Advance token to the nearest Utility. If unowned, you may buy it from the Bank.\n If owned, throw dice and pay owner a total of 10 times the amount thrown.", "moveToUT");
            chanceCards[4] = new ModifierCard("chance", "Advance to the nearest Railroad. If unowned, you may buy it from the Bank.\n If owned, pay owner twice the rental to which they are otherwise entitled.", "moveToRR");
            chanceCards[5] = new ModifierCard("chance", "Bank pays you a dividend of $50", "add+050");
            chanceCards[6] = new ModifierCard("chance", "Get out of Jail free", "gooj");
            chanceCards[7] = new ModifierCard("chance", "Go Back 3 Spaces", "index-3");
            chanceCards[8] = new ModifierCard("chance", "Go To Jail-Go directly to Jail-Do not pass GO, do not collect $200", "jail");
            chanceCards[9] = new ModifierCard("chance", "Make general repairs on all your property: For each house pay $25, For each hotel pay $100", "generalRepair");
            chanceCards[10] = new ModifierCard("chance", "Pay poor tax of $15", "add-015");
            chanceCards[11] = new ModifierCard("chance", "Take a trip to Reading Railroad. If you pass GO, collect $200", "moveTo05");
            chanceCards[12] = new ModifierCard("chance", "Take a walk on the Boardwalk. Advance token to Boardwalk", "moveTo39");
            chanceCards[13] = new ModifierCard("chance", "You have been elected Chairman of the Board. Pay each player $50", "payPlayers");
            chanceCards[14] = new ModifierCard("chance", "Your building and loan matures. Collect $150", "add+150");
            chanceCards[15] = new ModifierCard("chance", "You have won a crossword competition. Collect $100", "add+100");
            shuffleCards(chanceCards);
        }

        static void setCommunityChest()
        {
            communityChestCards[0] = new ModifierCard("communityChest", "Advance to GO", "moveTo00");
            communityChestCards[1] = new ModifierCard("communityChest", "Bank error in your favor. Collect $200", "add+200");
            communityChestCards[2] = new ModifierCard("communityChest", "Doctor's Fees. Pay $50", "add-050");
            communityChestCards[3] = new ModifierCard("communityChest", "From sale of stock you get $50", "add+050");
            communityChestCards[4] = new ModifierCard("communityChest", "Get out of jail free", "gooj");
            communityChestCards[5] = new ModifierCard("communityChest", "Go To Jail-Go directly to Jail-Do not pass GO, do not collect $200", "jail");
            communityChestCards[6] = new ModifierCard("communityChest", "Grand Opera Night. Collect $50 from every player for opening night seats", "playersPay50");
            communityChestCards[7] = new ModifierCard("communityChest", "Holiday Fund Matures. Receive $100", "add+100");
            communityChestCards[8] = new ModifierCard("communityChest", "Income tax refund. Collect $20", "add+020");
            communityChestCards[9] = new ModifierCard("communityChest", "You inherit $100", "add+100");
            communityChestCards[10] = new ModifierCard("communityChest", "Life insurances matures - Collect $100", "add+100");
            communityChestCards[11] = new ModifierCard("communityChest", "Hospital Fees - Pay $50", "add-050");
            communityChestCards[12] = new ModifierCard("communityChest", "School fees. Pay $50", "add-050");
            communityChestCards[13] = new ModifierCard("communityChest", "Receive $25 consultancy fee", "add+25");
            communityChestCards[14] = new ModifierCard("communityChest", "You are assessed for street repairs: For each house pay $40, For each hotel pay $115", "streetRepair");
            communityChestCards[15] = new ModifierCard("communityChest", "You have won second prize in a beauty contest. Collect $10", "add+010");
            shuffleCards(communityChestCards);
        }

        //Standard shuffle algorithm
        static void shuffleCards(ModifierCard[] deck)
        {
            System.Random r = new System.Random();

            for (int i = 0; i < deck.Length; i++)
            {

                int j = r.Next(i, deck.Length);
                ModifierCard tmp = deck[i];
                deck[i] = deck[j];
                deck[j] = tmp;

            }
        }

        //Calculate how much a player owes the owner of a property by the index (space) they land on and the roll that got them there (for utilities)
        static int getRent(int index, int roll)
        {
            BoardSpace current = boardSpaces[index];
            int rent = 0;

            //If space landed on is a railroad
            if (index == 5 || index == 15 || index == 25 || index == 35)
            {
                rent = railsFee(index);
            }
            //If space landed on is utility
            else if (index == 12 || index == 28)
            {
                if (hasMonopoly(index))
                {
                    rent = 10 * roll;
                }
                else
                {
                    rent = 4 * roll;
                }
            }
            //If space landed on is standard property
            else
            {
                if (hasMonopoly(index) && !current.hasHouses())
                {
                    rent = 2 * current.getRent();
                }
                else
                {
                    rent = current.getRent();
                }
            }

            if (boardSpaces[index].getMortgageStatus())
            {
                rent = 0;
            }

            return rent;
        }

        //Check ownership status of each property required for monopoly by index
        static bool hasMonopoly(int index)
        {
            BoardSpace current = boardSpaces[index];
            //Brown Properties
            if (current.getSpaceNumber() == 1 || current.getSpaceNumber() == 3)
            {
                if (boardSpaces[1].getOwner() == boardSpaces[3].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Light Blue Properties
            else if (current.getSpaceNumber() == 6 || current.getSpaceNumber() == 8 || current.getSpaceNumber() == 9)
            {
                if (boardSpaces[6].getOwner() == boardSpaces[8].getOwner() && boardSpaces[8].getOwner() == boardSpaces[9].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Purple Properties
            else if (current.getSpaceNumber() == 11 || current.getSpaceNumber() == 13 || current.getSpaceNumber() == 14)
            {
                if (boardSpaces[11].getOwner() == boardSpaces[13].getOwner() && boardSpaces[13].getOwner() == boardSpaces[14].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Utilities
            else if (current.getSpaceNumber() == 12 || current.getSpaceNumber() == 28)
            {
                if (boardSpaces[12].getOwner() == boardSpaces[28].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Orange Properties
            else if (current.getSpaceNumber() == 16 || current.getSpaceNumber() == 18 || current.getSpaceNumber() == 19)
            {
                if (boardSpaces[16].getOwner() == boardSpaces[18].getOwner() && boardSpaces[18].getOwner() == boardSpaces[19].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Red Properties
            else if (current.getSpaceNumber() == 21 || current.getSpaceNumber() == 23 || current.getSpaceNumber() == 24)
            {
                if (boardSpaces[21].getOwner() == boardSpaces[23].getOwner() && boardSpaces[23].getOwner() == boardSpaces[24].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Yellow Properties
            else if (current.getSpaceNumber() == 26 || current.getSpaceNumber() == 27 || current.getSpaceNumber() == 29)
            {
                if (boardSpaces[26].getOwner() == boardSpaces[27].getOwner() && boardSpaces[27].getOwner() == boardSpaces[29].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Green Properties
            else if (current.getSpaceNumber() == 31 || current.getSpaceNumber() == 32 || current.getSpaceNumber() == 34)
            {
                if (boardSpaces[31].getOwner() == boardSpaces[32].getOwner() && boardSpaces[32].getOwner() == boardSpaces[34].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Dark Blue Properties
            else if (current.getSpaceNumber() == 37 || current.getSpaceNumber() == 39)
            {
                if (boardSpaces[37].getOwner() == boardSpaces[39].getOwner())
                {
                    return true;
                }
                return false;
            }


            return false;
        }

        //Check which rails are owned by the owner of the rail at index to get total cost
        static int railsFee(int index)
        {
            int fee = 0;
            int railCount = 0;
            List<BoardSpace> railroads = new List<BoardSpace>();
            railroads.Add(boardSpaces[5]);
            railroads.Add(boardSpaces[15]);
            railroads.Add(boardSpaces[25]);
            railroads.Add(boardSpaces[35]);

            foreach (BoardSpace property in railroads)
            {
                if (boardSpaces[index].getOwner() == property.getOwner())
                {
                    railCount++;
                }
            }

            switch (railCount)
            {
                case 1:
                    fee = 25;
                    break;
                case 2:
                    fee = 50;
                    break;
                case 3:
                    fee = 100;
                    break;
                case 4:
                    fee = 200;
                    break;
            }

            return fee;
        }

        //Roll a single 6-sided die
        static int roll()
        {
            int die = rand.Next(1, 6);

            return die;
        }

        static void showPropertyInfo(int index, int roll)
        {
            Console.WriteLine("\nProperty Name: " + boardSpaces[index].getName());
            string owner = "Nobody";
            if(boardSpaces[index].getOwner() != null)
            {
                owner = boardSpaces[index].getOwner().getName();
                Console.WriteLine("Owned By: " + owner);
                if (hasMonopoly(index))
                {
                    Console.WriteLine(owner + "has a monopoly containing this property");
                }
            }            
            if(owner == "Nobody")
            {
                Console.WriteLine("Mortgage: " + boardSpaces[index].getMortgage());
                Console.WriteLine("Price to Buy: " + boardSpaces[index].getCost());

            }
            else
            {
                if(boardSpaces[index].getNumHouses() > 0 && boardSpaces[index].getNumHouses() < 5)
                {
                    Console.WriteLine("Houses: " + boardSpaces[index].getNumHouses());
                }else if(boardSpaces[index].getNumHouses() == 5)
                {
                    Console.WriteLine("1 Hotel");
                }
                Console.WriteLine("Rent Amount: " + getRent(index, roll));
            }
        }

        static void drawChanceCard(Player currentPlayer, int roll)
        {
            ModifierCard card = chanceCards[0];
            Console.WriteLine("\nChance: \n" + card.getDescription());

            if (card.getModifier().Contains("moveTo"))
            {
                string spaceString1 = card.getModifier()[6].ToString();
                string spaceString2 = card.getModifier()[7].ToString();
                string spaceString = spaceString1 + spaceString2;
                //Move to nearest railroad
                if (spaceString == "RR")
                {
                    int index = 0;
                    //Reading Railroad
                    if(currentPlayer.getSpace() < 5 || currentPlayer.getSpace() > 35)
                    {
                        index = 5;
                    }
                    //Pennsylvania Railroad
                    else if (currentPlayer.getSpace() < 15 && currentPlayer.getSpace() > 5)
                    {
                        index = 15;
                    }
                    //BO Railroad
                    else if (currentPlayer.getSpace() < 25 && currentPlayer.getSpace() > 15)
                    {
                        index = 25;
                    }
                    //Shortline Railroad
                    else if (currentPlayer.getSpace() < 35 && currentPlayer.getSpace() > 25)
                    {
                        index = 35;
                    }

                    //Move Player to index
                    int currentSpace = currentPlayer.getSpace();

                    while (currentSpace != index)
                    {
                        currentSpace++;
                        currentPlayer.setCurrentSpace(currentSpace);
                        //Reset from 40 to 0 (player gets to 'GO')
                        if (currentPlayer.getSpace() == 40)
                        {
                            Console.WriteLine(currentPlayer.getName() + " passed GO! Collect $200");
                            currentPlayer.setCurrentSpace(0);
                            currentSpace = 0;
                            currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                        }
                    }

                    if (boardSpaces[index].getOwner() == null)
                    {
                        buyProperty(currentPlayer, roll);
                    }
                    else
                    {
                        BoardSpace space = boardSpaces[currentPlayer.getSpace()];
                        int rent = getRent(space.getSpaceNumber(), roll);
                        rent *= 2;
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "! Pay them $" + rent + "!");
                        //Pay owner if enough money is owned by current player
                        if ((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner

                            //Player is bankrupt and out of the game
                            space.getOwner().setMoney(space.getOwner().getMoney() + currentPlayer.getMoney());
                            currentPlayer.setMoney(0);
                            Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");

                            //TODO - give all money to owner and set all properties of player to be owned by owner
                        }
                    }
                }
                //Move to nearest utility
                else if(spaceString == "UT")
                {
                    int index = 0;

                    if(currentPlayer.getSpace() < 12 || currentPlayer.getSpace() > 28)
                    {
                        index = 12;
                    }
                    else
                    {
                        index = 28;
                    }

                    int currentSpace = currentPlayer.getSpace();
                    while (currentSpace != index)
                    {
                        currentSpace++;
                        currentPlayer.setCurrentSpace(currentSpace);
                        //Reset from 40 to 0 (player gets to 'GO')
                        if (currentPlayer.getSpace() == 40)
                        {
                            Console.WriteLine(currentPlayer.getName() + " passed GO! Collect $200");
                            currentPlayer.setCurrentSpace(0);
                            currentSpace = 0;
                            currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                        }
                    }
                    if (boardSpaces[index].getOwner() == null)
                    {
                        buyProperty(currentPlayer, roll);
                    }
                    else
                    {
                        BoardSpace space = boardSpaces[currentPlayer.getSpace()];
                        int rent = 10 * roll;
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "! Pay them $" + rent + "!");
                        //Pay owner if enough money is owned by current player
                        if ((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner

                            //Player is bankrupt and out of the game
                            space.getOwner().setMoney(space.getOwner().getMoney() + currentPlayer.getMoney());
                            currentPlayer.setMoney(0);
                            Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");

                            //TODO - give all money to owner and set all properties of player to be owned by owner
                        }
                    }
                }
                else
                {
                    int index = Convert.ToInt32(spaceString);

                    //Move Player to index
                    int currentSpace = currentPlayer.getSpace();

                    while (currentSpace != index)
                    {
                        currentSpace++;
                        currentPlayer.setCurrentSpace(currentSpace);
                        //Reset from 40 to 0 (player gets to 'GO')
                        if (currentPlayer.getSpace() == 40)
                        {
                            Console.WriteLine(currentPlayer.getName() + " passed GO! Collect $200");
                            currentPlayer.setCurrentSpace(0);
                            currentSpace = 0;
                            currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                        }
                    }

                    if (boardSpaces[index].getOwner() == null)
                    {
                        buyProperty(currentPlayer, roll);
                    }
                    else
                    {
                        BoardSpace space = boardSpaces[currentPlayer.getSpace()];
                        int rent = getRent(space.getSpaceNumber(), roll);
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "! Pay them $" + rent + "!");
                        //Pay owner if enough money is owned by current player
                        if ((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner

                            //Player is bankrupt and out of the game
                            space.getOwner().setMoney(space.getOwner().getMoney() + currentPlayer.getMoney());
                            currentPlayer.setMoney(0);
                            Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");

                            //TODO - give all money to owner and set all properties of player to be owned by owner
                        }
                    }
                }
                
            }
            else if (card.getModifier().Contains("add"))
            {
                if (card.getModifier().Contains("+"))
                {
                    char digit1 = card.getModifier()[4];
                    char digit2 = card.getModifier()[5];
                    char digit3 = card.getModifier()[6];
                    string amountString = digit1 + digit2 + digit3 + "";
                    int amount = Convert.ToInt32(amountString);
                    currentPlayer.setMoney(currentPlayer.getMoney() + amount);
                }
                else
                {
                    char digit1 = card.getModifier()[4];
                    char digit2 = card.getModifier()[5];
                    char digit3 = card.getModifier()[6];
                    string amountString = digit1 + digit2 + digit3 + "";
                    int amount = Convert.ToInt32(amountString);
                    currentPlayer.setMoney(currentPlayer.getMoney() - amount);
                }
            }
            else if (card.getModifier().Contains("gooj"))
            {
                currentPlayer.setGOOJ(currentPlayer.getGOOJ() + 1);
            }
            else if (card.getModifier().Contains("index-3"))
            {
                int index = currentPlayer.getSpace();
                if(index <= 2)
                {
                    index += 40;                   
                }
                currentPlayer.setCurrentSpace(index - 3);
                //Player lands on space
                BoardSpace space = boardSpaces[currentPlayer.getSpace()];

                //Space is a property
                if (space.getCost() > 0)
                {
                    //If space is unowned
                    if (space.getOwner() == null)
                    {
                        if (space.getCost() > currentPlayer.getMoney())
                        {
                            Console.WriteLine(currentPlayer.getName() + " landed on " + space.getName() + ", but does not have enough money to buy it!");
                            //TODO - Player mortgages, sells houses to afford property (unlikely - but possible)
                        }
                        else
                        {
                            buyProperty(currentPlayer, roll);
                        }

                    }
                    //If space is owned (not by current player)
                    else if (space.getOwner() != currentPlayer)
                    {
                        int rent = getRent(space.getSpaceNumber(), roll);
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "! Pay them $" + rent + "!");
                        //Pay owner if enough money is owned by current player
                        if ((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner

                            //Player is bankrupt and out of the game
                            space.getOwner().setMoney(space.getOwner().getMoney() + currentPlayer.getMoney());
                            currentPlayer.setMoney(0);
                            Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");

                            //TODO - give all money to owner and set all properties of player to be owned by owner
                        }

                    }
                }
                //Space is Chance, Community Chest, Tax Spot, or Corner
                else
                {
                    //Chance
                    if (space.getSpaceNumber() == 7 || space.getSpaceNumber() == 22 || space.getSpaceNumber() == 36)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has landed on Chance!");
                    }
                    //Community Chest
                    else if (space.getSpaceNumber() == 2 || space.getSpaceNumber() == 17 || space.getSpaceNumber() == 33)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has landed on Community Chest!");
                    }
                    //Income Tax
                    else if (space.getSpaceNumber() == 4)
                    {
                        //10% or 200
                        int percent = System.Convert.ToInt32(currentPlayer.getMoney() * 0.1);
                        int tax = 200;
                        if (percent < 200)
                        {
                            tax = percent;
                        }
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ". Pay $" + tax + "!");
                        currentPlayer.setMoney(currentPlayer.getMoney() - tax);
                    }
                    //Luxury Tax
                    else if (space.getSpaceNumber() == 38)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ". Pay $75!");
                        currentPlayer.setMoney(currentPlayer.getMoney() - 75);
                    }
                    //Else if Go To Jail
                    else if (space.getSpaceNumber() == 30)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + "! Go directly to Jail!");
                        currentPlayer.setCurrentSpace(10);
                        currentPlayer.setJailStatus(true);
                    }
                    else
                    {
                        Console.Write(currentPlayer.getName() + " has landed on " + space.getName() + "!");
                        if (space.getSpaceNumber() == 0)
                        {
                            Console.Write(" Right on the Money!");
                        }
                        if (space.getSpaceNumber() == 10)
                        {
                            Console.Write(" Luckily they're just visiting!");
                        }
                        if (space.getSpaceNumber() == 20)
                        {
                            Console.Write(" What a value!");
                        }
                    }
                }
            }
            else if (card.getModifier().Contains("jail"))
            {
                currentPlayer.setJailStatus(true);
                currentPlayer.setCurrentSpace(10);
            }
            else if (card.getModifier().Contains("generalRepair"))
            {
                int total = 0;
                foreach(BoardSpace property in currentPlayer.getProperties())
                {
                    if(property.getNumHouses() == 5)
                    {
                        total += 100;
                    }
                    else
                    {
                        total += (25 * property.getNumHouses());
                    }
                }
                Console.WriteLine("(Lose a total of $" + total + ")");
                currentPlayer.setMoney(currentPlayer.getMoney() - total);
            }
            else if (card.getModifier().Contains("payPlayers"))
            {
                int totalPaid = (playerList.Count() - 1) * 50;
                foreach(Player player in playerList)
                {
                    if(player.getName() != currentPlayer.getName())
                    {
                        player.setMoney(player.getMoney() + 50);
                    }
                }
                currentPlayer.setMoney(currentPlayer.getMoney() - totalPaid);
            }



            ModifierCard[] tmpList = new ModifierCard[chanceCards.Length];

            for(int i=0; i < chanceCards.Length - 1; i++)
            {
                if(i == 0)
                {
                    tmpList[chanceCards.Length - 1] = chanceCards[i];
                }
                else
                {
                    tmpList[i-1] = chanceCards[i];
                }
            }

            chanceCards = tmpList;
        }

        static void drawCommunityChestCard(Player currentPlayer, int roll)
        {
            ModifierCard card = communityChestCards[0];
            Console.WriteLine("\nCommunity Chest: \n" + card.getDescription());

            if (card.getModifier().Contains("moveTo"))
            {
                string spaceString1 = card.getModifier()[6].ToString();
                string spaceString2 = card.getModifier()[7].ToString();
                string spaceString = spaceString1 + spaceString2;
                //Move to nearest railroad
                if (spaceString == "RR")
                {
                    int index = 0;
                    //Reading Railroad
                    if (currentPlayer.getSpace() < 5 || currentPlayer.getSpace() > 35)
                    {
                        index = 5;
                    }
                    //Pennsylvania Railroad
                    else if (currentPlayer.getSpace() < 15 && currentPlayer.getSpace() > 5)
                    {
                        index = 15;
                    }
                    //BO Railroad
                    else if (currentPlayer.getSpace() < 25 && currentPlayer.getSpace() > 15)
                    {
                        index = 25;
                    }
                    //Shortline Railroad
                    else if (currentPlayer.getSpace() < 35 && currentPlayer.getSpace() > 25)
                    {
                        index = 35;
                    }

                    //Move Player to index
                    int currentSpace = currentPlayer.getSpace();

                    while (currentSpace != index)
                    {
                        currentSpace++;
                        currentPlayer.setCurrentSpace(currentSpace);
                        //Reset from 40 to 0 (player gets to 'GO')
                        if (currentPlayer.getSpace() == 40)
                        {
                            Console.WriteLine(currentPlayer.getName() + " passed GO! Collect $200");
                            currentPlayer.setCurrentSpace(0);
                            currentSpace = 0;
                            currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                        }
                    }

                    if (boardSpaces[index].getOwner() == null)
                    {
                        buyProperty(currentPlayer, roll);
                    }
                    else
                    {
                        BoardSpace space = boardSpaces[currentPlayer.getSpace()];
                        int rent = getRent(space.getSpaceNumber(), roll);
                        rent *= 2;
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "! Pay them $" + rent + "!");
                        //Pay owner if enough money is owned by current player
                        if ((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner

                            //Player is bankrupt and out of the game
                            space.getOwner().setMoney(space.getOwner().getMoney() + currentPlayer.getMoney());
                            currentPlayer.setMoney(0);
                            Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");

                            //TODO - give all money to owner and set all properties of player to be owned by owner
                        }
                    }
                }
                //Move to nearest utility
                else if (spaceString == "UT")
                {
                    int index = 0;

                    if (currentPlayer.getSpace() < 12 || currentPlayer.getSpace() > 28)
                    {
                        index = 12;
                    }
                    else
                    {
                        index = 28;
                    }

                    int currentSpace = currentPlayer.getSpace();
                    while (currentSpace != index)
                    {
                        currentSpace++;
                        currentPlayer.setCurrentSpace(currentSpace);
                        //Reset from 40 to 0 (player gets to 'GO')
                        if (currentPlayer.getSpace() == 40)
                        {
                            Console.WriteLine(currentPlayer.getName() + " passed GO! Collect $200");
                            currentPlayer.setCurrentSpace(0);
                            currentSpace = 0;
                            currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                        }
                    }
                    if (boardSpaces[index].getOwner() == null)
                    {
                        buyProperty(currentPlayer, roll);
                    }
                    else
                    {
                        BoardSpace space = boardSpaces[currentPlayer.getSpace()];
                        int rent = 10 * roll;
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "! Pay them $" + rent + "!");
                        //Pay owner if enough money is owned by current player
                        if ((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner

                            //Player is bankrupt and out of the game
                            space.getOwner().setMoney(space.getOwner().getMoney() + currentPlayer.getMoney());
                            currentPlayer.setMoney(0);
                            Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");

                            //TODO - give all money to owner and set all properties of player to be owned by owner
                        }
                    }
                }
                else
                {
                    int index = Convert.ToInt32(spaceString);

                    //Move Player to index
                    int currentSpace = currentPlayer.getSpace();

                    while (currentSpace != index)
                    {
                        currentSpace++;
                        currentPlayer.setCurrentSpace(currentSpace);
                        //Reset from 40 to 0 (player gets to 'GO')
                        if (currentPlayer.getSpace() == 40)
                        {
                            Console.WriteLine(currentPlayer.getName() + " passed GO! Collect $200");
                            currentPlayer.setCurrentSpace(0);
                            currentSpace = 0;
                            currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                        }
                    }

                    if (boardSpaces[index].getOwner() == null)
                    {
                        buyProperty(currentPlayer, roll);
                    }
                    else
                    {
                        BoardSpace space = boardSpaces[currentPlayer.getSpace()];
                        int rent = getRent(space.getSpaceNumber(), roll);
                        Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "! Pay them $" + rent + "!");
                        //Pay owner if enough money is owned by current player
                        if ((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner

                            //Player is bankrupt and out of the game
                            space.getOwner().setMoney(space.getOwner().getMoney() + currentPlayer.getMoney());
                            currentPlayer.setMoney(0);
                            Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");

                            //TODO - give all money to owner and set all properties of player to be owned by owner
                        }
                    }
                }

            }
            else if (card.getModifier().Contains("add"))
            {
                if (card.getModifier().Contains("+"))
                {
                    char digit1 = card.getModifier()[4];
                    char digit2 = card.getModifier()[5];
                    char digit3 = card.getModifier()[6];
                    string amountString = digit1 + digit2 + digit3 + "";
                    int amount = Convert.ToInt32(amountString);
                    currentPlayer.setMoney(currentPlayer.getMoney() + amount);
                }
                else
                {
                    char digit1 = card.getModifier()[4];
                    char digit2 = card.getModifier()[5];
                    char digit3 = card.getModifier()[6];
                    string amountString = digit1 + digit2 + digit3 + "";
                    int amount = Convert.ToInt32(amountString);
                    currentPlayer.setMoney(currentPlayer.getMoney() - amount);
                }
            }
            else if (card.getModifier().Contains("gooj"))
            {
                currentPlayer.setGOOJ(currentPlayer.getGOOJ() + 1);
            }
            else if (card.getModifier().Contains("jail"))
            {
                currentPlayer.setJailStatus(true);
                currentPlayer.setCurrentSpace(10);
            }
            else if (card.getModifier().Contains("streetRepair"))
            {
                int total = 0;
                foreach (BoardSpace property in currentPlayer.getProperties())
                {
                    if (property.getNumHouses() == 5)
                    {
                        total += 115;
                    }
                    else
                    {
                        total += (40 * property.getNumHouses());
                    }
                }
                Console.WriteLine("(Lose a total of $" + total + ")");
                currentPlayer.setMoney(currentPlayer.getMoney() - total);
            }
            else if (card.getModifier().Contains("playersPay50"))
            {
                int totalPaid = (playerList.Count() - 1) * 50;
                foreach (Player player in playerList)
                {
                    if (player.getName() != currentPlayer.getName())
                    {
                        player.setMoney(player.getMoney() - 50);
                    }
                }
                currentPlayer.setMoney(currentPlayer.getMoney() + totalPaid);
            }



            ModifierCard[] tmpList = new ModifierCard[communityChestCards.Length];

            for (int i = 0; i < communityChestCards.Length - 1; i++)
            {
                if (i == 0)
                {
                    tmpList[communityChestCards.Length - 1] = communityChestCards[i];
                }
                else
                {
                    tmpList[i - 1] = communityChestCards[i];
                }
            }

            communityChestCards = tmpList;
        }

        //Prompt a player to buy a property
        static void buyProperty(Player currentPlayer, int roll)
        {
            while (true)
            {
                Console.WriteLine(currentPlayer.getName() + " has landed on...");
                showPropertyInfo(currentPlayer.getSpace(), roll);
                Console.Write("\n\nYou have $" + currentPlayer.getMoney() + ". Would you like to purchase this property for $" + boardSpaces[currentPlayer.getSpace()].getCost() + "? Enter y/n: ");
                string choice = Console.ReadLine();

                //Player spends money and acquires property
                if(choice == "y")
                {
                    int currentTotal = currentPlayer.getMoney();
                    currentTotal -= boardSpaces[currentPlayer.getSpace()].getCost();
                    currentPlayer.setMoney(currentTotal);
                    boardSpaces[currentPlayer.getSpace()].setOwner(currentPlayer);
                    currentPlayer.addProperty(boardSpaces[currentPlayer.getSpace()]);
                    break;
                }
                //Player chooses not to spend money to buy property
                else if(choice == "n")
                {
                    break;
                }
                //Player did not enter y/n
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your decision must be either 'y' for yes or 'n' for no!\n");
                }
            }
            
            
        }

        static void transferOwnership(Player bankruptPlayer, Player owner)
        {
            List<BoardSpace> bankruptList = bankruptPlayer.getProperties();

            foreach(BoardSpace property in bankruptList)
            {
                property.setOwner(owner);
            }

            owner.setMoney(owner.getMoney() + bankruptPlayer.getMoney());
            bankruptPlayer.setMoney(0);
        }

        static void resetOwnership(Player bankruptPlayer)
        {
            List<BoardSpace> bankruptList = bankruptPlayer.getProperties();

            foreach (BoardSpace property in bankruptList)
            {
                property.setOwner(null);
                property.setMortgageStatus(false);
                property.setNumHouses(0);
            }

            bankruptPlayer.setMoney(0);
        }

        static void trade(Player currentPlayer)
        {
            List<Player> otherPlayers = new List<Player>();

            foreach(Player player in playerList)
            {
                if(player.getName() != currentPlayer.getName())
                {
                    otherPlayers.Add(player);
                }
            }

            Console.Clear();

            //Select which player you want to trade with
            while (true)
            {
                Console.WriteLine("Which player would you like to trade with?\n");
                foreach (Player player in otherPlayers)
                {
                    Console.WriteLine(player.getName());
                }
                Console.Write("\n\nEnter name of player or type 'exit' to quit trading: ");
                string choice = Console.ReadLine();

                Player foundPlayer = null;
                foreach (Player player in otherPlayers)
                {
                    if (player.getName() == choice)
                    {
                        foundPlayer = player;
                    }
                }

                if (choice == "exit")
                {
                    Console.Clear();
                    break;
                }
                else if (foundPlayer == null)
                {
                    Console.Clear();
                    Console.WriteLine("Must enter valid player name or 'exit'!");
                    continue;
                }

                //Display Both player's properties and cash
                Console.Clear();
                List<BoardSpace> propertyOffer = new List<BoardSpace>();
                int cashOffer = 0;
                bool accepted = false;
                while (true)
                {
                    Console.WriteLine(currentPlayer.getName() + " has $" + currentPlayer.getMoney() + " and the following properties:");
                    List<BoardSpace> orderedProperties1 = new List<BoardSpace>();
                    for (int i = 0; i < currentPlayer.getProperties().Count; i++)
                    {
                        orderedProperties1.Add(currentPlayer.getProperties()[i]);
                    }
                    foreach (BoardSpace property in orderedProperties1)
                    {
                        string mortgaged = "";
                        if (property.getMortgageStatus())
                        {
                            mortgaged = " (Mortgaged)";
                        }
                        else
                        {
                            mortgaged = " (Un-Mortgaged)";
                        }
                        Console.WriteLine(property.getName() + mortgaged);
                    }

                    Console.WriteLine("\n" + foundPlayer.getName() + " has $" + foundPlayer.getMoney() + " and the following properties:");
                    List<BoardSpace> orderedProperties2 = new List<BoardSpace>();
                    for (int i = 0; i < foundPlayer.getProperties().Count; i++)
                    {
                        orderedProperties2.Add(foundPlayer.getProperties()[i]);
                    }
                    foreach (BoardSpace property in orderedProperties2)
                    {
                        string mortgaged = "";
                        if (property.getMortgageStatus())
                        {
                            mortgaged = " (Mortgaged)";
                        }
                        else
                        {
                            mortgaged = " (Un-Mortgaged)";
                        }
                        Console.WriteLine(property.getName() + mortgaged);
                    }

                    //Print current offer (if one exists)
                    if (cashOffer != 0 || propertyOffer.Count > 0)
                    {
                        string propertyOfferString = "";
                        for (int i = 0; i < propertyOffer.Count; i++)
                        {
                            if (i != (propertyOffer.Count - 1))
                            {
                                propertyOfferString += propertyOffer[i].getName() + ", ";
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    propertyOfferString += propertyOffer[i].getName();
                                }
                                else
                                {
                                    propertyOfferString += "and " + propertyOffer[i].getName();
                                }

                            }
                        }

                        Console.WriteLine("\nCurrent offer is $" + cashOffer + " and the following properties: " + propertyOfferString);
                    }

                    Console.WriteLine("\n" + currentPlayer.getName() + ": type in a cash value, or property name you would like to trade to " + foundPlayer.getName());
                    Console.WriteLine("Enter a cash offer, property name to offer, type 'done' to confirm offer, or type 'back' to return to trade menu: ");
                    choice = Console.ReadLine();

                    //Return to initial trade menu
                    if (choice == "back")
                    {
                        Console.Clear();
                        break;
                    }
                    //Move on to select properties/cash to receive in exchange
                    else if (choice == "done")
                    {
                        //Show Properties again for current player to choose what they get in return for their offer
                        Console.Clear();
                        List<BoardSpace> exchangeProperties = new List<BoardSpace>();
                        int exchangeOffer = 0;                       
                        while (true)
                        {
                            Console.WriteLine(currentPlayer.getName() + " has $" + currentPlayer.getMoney() + " and the following properties:");
                            foreach (BoardSpace property in orderedProperties1)
                            {
                                string mortgaged = "";
                                if (property.getMortgageStatus())
                                {
                                    mortgaged = " (Mortgaged)";
                                }
                                else
                                {
                                    mortgaged = " (Un-Mortgaged)";
                                }
                                Console.WriteLine(property.getName() + mortgaged);
                            }
                            Console.WriteLine("\n" + foundPlayer.getName() + " has $" + foundPlayer.getMoney() + " and the following properties:");
                            foreach (BoardSpace property in orderedProperties2)
                            {
                                string mortgaged = "";
                                if (property.getMortgageStatus())
                                {
                                    mortgaged = " (Mortgaged)";
                                }
                                else
                                {
                                    mortgaged = " (Un-Mortgaged)";
                                }
                                Console.WriteLine(property.getName() + mortgaged);
                            }

                            //Print offer
                            string currentOfferString = "";
                            for (int i = 0; i < propertyOffer.Count; i++)
                            {
                                if (i != (propertyOffer.Count - 1))
                                {
                                    currentOfferString += propertyOffer[i].getName() + ", ";
                                }
                                else
                                {
                                    if (i == 0)
                                    {
                                        currentOfferString += propertyOffer[i].getName();
                                    }
                                    else
                                    {
                                        currentOfferString += "and " + propertyOffer[i].getName();
                                    }

                                }
                            }

                            Console.WriteLine("\nCurrent offer is $" + cashOffer + " and the following properties: " + currentOfferString);

                            //Print Exchange offer (if one exists)
                            string exchangeOfferString = "";
                            if (exchangeOffer != 0 || exchangeProperties.Count > 0)
                            {
                                exchangeOfferString = "";
                                for (int i = 0; i < exchangeProperties.Count; i++)
                                {
                                    if (i != (propertyOffer.Count - 1))
                                    {
                                        exchangeOfferString += exchangeProperties[i].getName() + ", ";
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            exchangeOfferString += exchangeProperties[i].getName();
                                        }
                                        else
                                        {
                                            exchangeOfferString += "and " + exchangeProperties[i].getName();
                                        }

                                    }
                                }

                                Console.WriteLine("\nExchange offer is $" + exchangeOffer + " and the following properties: " + exchangeOfferString);
                            }

                            Console.WriteLine("\n" + currentPlayer.getName() + ": type in a cash amount, or property name you would like to receive in exchange from " + foundPlayer.getName());
                            Console.WriteLine("Enter a cash amount, property name desired, type 'done' to confirm trade, or type 'back' to change offer: ");
                            choice = Console.ReadLine();

                            if (choice == "back")
                            {
                                Console.Clear();
                                break;
                            }
                            else if (choice == "done")
                            {
                                //Show screen for foundPlayer to accept or deny offer
                                Console.Clear();
                                while (true)
                                {
                                    Console.WriteLine("Current offer is $" + cashOffer + " and the following properties: " + currentOfferString);
                                    Console.WriteLine("\nExchange offer is $" + exchangeOffer + " and the following properties: " + exchangeOfferString);

                                    Console.WriteLine("\n" + foundPlayer.getName() + ", would you like to accept this trade?");
                                    Console.WriteLine("Enter 'y' to accept, or 'n' to return " + currentPlayer.getName() + " to change the exchange: ");
                                    choice = Console.ReadLine();

                                    if (choice == "y")
                                    {
                                        currentPlayer.setMoney(currentPlayer.getMoney() - cashOffer + exchangeOffer);
                                        foundPlayer.setMoney(foundPlayer.getMoney() + cashOffer - exchangeOffer);

                                        foreach (BoardSpace property in propertyOffer)
                                        {
                                            currentPlayer.removeProperty(property);
                                            property.setOwner(foundPlayer);
                                            foundPlayer.getProperties().Add(property);
                                        }

                                        foreach (BoardSpace property in exchangeProperties)
                                        {
                                            foundPlayer.removeProperty(property);
                                            property.setOwner(currentPlayer);
                                            currentPlayer.getProperties().Add(property);
                                        }

                                        accepted = true;
                                        Console.Clear();
                                        break;
                                    }
                                    else if (choice == "n")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(foundPlayer.getName() + " has rejected the offer!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine(foundPlayer.getName() + ", you must choose 'y' to accept or 'n' to decline!");
                                        continue;
                                    }
                                }

                            }
                            else
                            {
                                try
                                {
                                    int offer = Convert.ToInt32(choice);
                                    //TODO - Check if player has enough money
                                    exchangeOffer = offer;
                                    Console.Clear();
                                    Console.WriteLine("$" + exchangeOffer + " was added to the exchange.\n");
                                    continue;
                                }
                                catch
                                {
                                    BoardSpace foundProperty = null;
                                    foreach (BoardSpace property in foundPlayer.getProperties())
                                    {
                                        if (property.getName() == choice)
                                        {
                                            foundProperty = property;
                                        }
                                    }

                                    if (foundProperty == null)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("No owned property of that name was found!\n");
                                        continue;
                                    }
                                    else
                                    {
                                        exchangeProperties.Add(foundProperty);
                                        Console.Clear();
                                        Console.WriteLine(foundProperty.getName() + " was added to the exchange.\n");
                                        continue;
                                    }
                                }
                            }

                            //If offer was accepted, break from trading. Else continue loop
                            if (accepted)
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (accepted)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    //Add cash/property to current offerings
                    else
                    {
                        try
                        {
                            int offer = Convert.ToInt32(choice);
                            //TODO - Check if player has enough money
                            cashOffer = offer;
                            Console.Clear();
                            Console.WriteLine("$" + cashOffer + " was added to the offerings.\n");
                            continue;
                        }
                        catch
                        {
                            BoardSpace foundProperty = null;
                            foreach (BoardSpace property in currentPlayer.getProperties())
                            {
                                if (property.getName() == choice)
                                {
                                    foundProperty = property;
                                }
                            }

                            if (foundProperty == null)
                            {
                                Console.Clear();
                                Console.WriteLine("No owned property of that name was found!\n");
                                continue;
                            }
                            else
                            {
                                propertyOffer.Add(foundProperty);
                                Console.Clear();
                                Console.WriteLine(foundProperty.getName() + " was added to the offerings.\n");
                                continue;
                            }
                        }
                    }

                }



            }

        }

        //List player money, properties, houses, mortgages
        static void manageProperties(Player currentPlayer, Player owedPlayer, int amountOwed)
        {
            

            //List player properties + stats
            Console.Clear();
            //Print Player property Info
            while (true)
            {
                List<BoardSpace> playerProperties = new List<BoardSpace>();
                //Get ordered list of player properties
                foreach (BoardSpace property in boardSpaces)
                {
                    if (currentPlayer.getProperties().Contains(property))
                    {
                        playerProperties.Add(property);
                    }
                }

                if (amountOwed > 0)
                {
                    Console.WriteLine("You need $" + amountOwed + " to stay in the game!");
                }
                Console.WriteLine("You have $" + currentPlayer.getMoney());
                Console.WriteLine("\nYour Properties:\n");
                foreach (BoardSpace property in playerProperties)
                {
                    string monopoly = "";
                    if (hasMonopoly(property.getSpaceNumber()))
                    {
                        monopoly = "[Monopoly]";
                    }
                    string houseString = "";
                    if (property.getNumHouses() == 5)
                    {
                        houseString = "Hotels: 1";
                    }
                    else
                    {
                        houseString = "Houses: " + property.getNumHouses();
                    }
                    string mortgageStatus = "";
                    if (property.getMortgageStatus())
                    {
                        mortgageStatus = "Mortgaged";
                    }
                    else
                    {
                        mortgageStatus = "Un-Mortgaged";
                    }
                    Console.WriteLine(monopoly + property.getName() + " (" + mortgageStatus + ")" + " | " + houseString + " | " + "Mortgage: " + property.getMortgage());
                }

                Console.WriteLine("\nType the name of the property (match-case) you wish to modify, 'trade' to trade properties with players, or type 'exit' to quit property management");
                if(owedPlayer != null)
                {
                    Console.WriteLine("\nWARNING: If you type 'exit' while owing money you will automatically forfeit!");
                }
                Console.Write("\nEnter property name/trade/exit: ");
                string choice = Console.ReadLine();
                if (choice == "exit")
                {
                    if(currentPlayer.getMoney() < amountOwed)
                    {
                        if(owedPlayer != null)
                        {
                            transferOwnership(currentPlayer, owedPlayer);
                        }
                        else
                        {
                            resetOwnership(currentPlayer);
                        }
                        
                    }
                    else
                    {
                        if(owedPlayer != null)
                        {
                            owedPlayer.setMoney(owedPlayer.getMoney() + amountOwed);
                        }
                        currentPlayer.setMoney(currentPlayer.getMoney() - amountOwed);
                    }
                    break;
                }
                else if (choice == "trade")
                {
                    trade(currentPlayer);
                    continue;
                }
                else
                {
                    BoardSpace foundProperty = null;
                    foreach (BoardSpace property in playerProperties)
                    {
                        if (property.getName() == choice)
                        {
                            foundProperty = property;
                            break;
                        }
                    }

                    if (foundProperty == null)
                    {
                        Console.Clear();
                        Console.WriteLine("No owned property called '" + choice + "' was found.\n");
                        continue;
                    }

                    //Show property info
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("You have $" + currentPlayer.getMoney());
                        string monopoly = "";
                        if (hasMonopoly(foundProperty.getSpaceNumber()))
                        {
                            monopoly = "[Monopoly]";
                        }
                        Console.WriteLine("\n" + foundProperty.getName() + monopoly);
                        if (monopoly != "" && foundProperty.getHousePrice() != 0)
                        {
                            if (foundProperty.getNumHouses() == 4)
                            {
                                Console.WriteLine("Buy a hotel for $" + foundProperty.getHousePrice() + "(Enter 'buy')");
                            }
                            else
                            {
                                Console.WriteLine("Buy a house for $" + foundProperty.getHousePrice() + "(Enter 'buy')");
                            }
                            if (foundProperty.getNumHouses() == 4)
                            {
                                Console.WriteLine("Sell a hotel for $" + foundProperty.getHousePrice() + "(Enter 'sell')");
                            }
                            else
                            {
                                Console.WriteLine("Sell a house for $" + foundProperty.getHousePrice() + "(Enter 'sell')");
                            }
                        }
                        if (foundProperty.getMortgageStatus())
                        {
                            Console.WriteLine("Un-mortgage for $" + foundProperty.getMortgage() + "(Enter 'mortgage')");
                        }
                        else
                        {
                            Console.WriteLine("Mortgage for $" + foundProperty.getMortgage() + "(Enter 'mortgage')");
                        }
                        Console.WriteLine("\nOR return to property management menu by typing 'back'.");

                        Console.Write("\nEnter your decision: ");
                        string pick = Console.ReadLine();

                        if (pick == "back")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (pick == "buy")
                        {
                            if (currentPlayer.getMoney() < foundProperty.getHousePrice())
                            {
                                Console.Clear();
                                Console.WriteLine("You do not have enough money to buy additional buildings!\n");
                                continue;
                            }
                            else if (foundProperty.getNumHouses() == 5)
                            {
                                Console.Clear();
                                Console.WriteLine("You already have a hotel on this property! No more buildings\n");
                                continue;
                            }
                            else
                            {
                                foundProperty.setNumHouses(foundProperty.getNumHouses() + 1);
                                currentPlayer.setMoney(currentPlayer.getMoney() - foundProperty.getHousePrice());
                                Console.Clear();
                                Console.WriteLine("You purchased a new building for $" + foundProperty.getHousePrice() + "\n");
                                break;
                            }
                        }
                        else if (pick == "sell")
                        {
                            if (foundProperty.getNumHouses() == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("You have no houses to sell!\n");
                                continue;
                            }
                            else
                            {
                                foundProperty.setNumHouses(foundProperty.getNumHouses() - 1);
                                currentPlayer.setMoney(currentPlayer.getMoney() + foundProperty.getHousePrice());
                                Console.Clear();
                                Console.WriteLine("You sold a building for $" + foundProperty.getHousePrice() + "\n");
                                continue;
                            }
                        }
                        else if (pick == "mortgage")
                        {
                            if (foundProperty.getMortgageStatus())
                            {
                                if (currentPlayer.getMoney() < foundProperty.getMortgage())
                                {
                                    Console.Clear();
                                    Console.WriteLine("You do not have the funds to pay off the mortgage!\n");
                                    continue;
                                }
                                foundProperty.setMortgageStatus(false);
                                currentPlayer.setMoney(currentPlayer.getMoney() - foundProperty.getMortgage());
                                Console.Clear();
                                Console.WriteLine("You un-mortgaged " + foundProperty.getName() + " for $" + foundProperty.getMortgage());
                            }
                            else
                            {
                                foundProperty.setMortgageStatus(true);
                                currentPlayer.setMoney(currentPlayer.getMoney() + foundProperty.getMortgage());
                                Console.Clear();
                                Console.WriteLine("You mortgaged " + foundProperty.getName() + " for $" + foundProperty.getMortgage());
                            }
                            continue;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Must pick an option listed...\n");
                            continue;
                        }
                    }
                }
            }

        }

        static void playerRoll(Player currentPlayer)
        {
            bool rolledDouble = true;
            int doubleCount = 0;            
            //turn
            while (rolledDouble)
            {
                //Check if player is in jail - prompt to spend $50 or use GOOJ card. Max 3 turns in jail
                if (currentPlayer.playerJailed())
                {
                    Console.WriteLine("\n" + currentPlayer.getName() + " is in Jail!");
                    currentPlayer.addJailTime();
                    if(currentPlayer.getTimeInJail() < 3)
                    {
                        if(currentPlayer.getMoney() > 50 || currentPlayer.getGOOJ() > 0)
                        {
                            while (true)
                            {
                                Console.WriteLine("You have $" + currentPlayer.getMoney() + " and " + currentPlayer.getGOOJ() + " get out of jail free cards.");
                                Console.Write("To pay $50 to get out of jail, type 'pay'. \nTo use a get out of jail free card, if you've got one, type 'card'. \nTo instead roll for doubles, type roll. \nEnter pay/card/roll: ");
                                string choice = Console.ReadLine();
                                if(choice == "pay")
                                {
                                    if(currentPlayer.getMoney() < 50)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You must have at least $50 to use 'pay'!");
                                    }
                                    else
                                    {
                                        currentPlayer.setMoney(currentPlayer.getMoney() - 50);
                                        currentPlayer.resetJailTime();
                                        currentPlayer.setJailStatus(false);
                                        Console.WriteLine(currentPlayer.getName() + " paid $50 to get out of Jail!");
                                        break;
                                    }
                                    
                                }else if(choice == "card")
                                {
                                    if (currentPlayer.getGOOJ() < 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You must have at least one get out of jail free card to use 'card'!");
                                    }
                                    else
                                    {
                                        currentPlayer.setGOOJ(currentPlayer.getGOOJ() - 1);
                                        currentPlayer.resetJailTime();
                                        currentPlayer.setJailStatus(false);
                                        Console.WriteLine(currentPlayer.getName() + " used a get out of jail free cards to get out of Jail!");
                                        break;
                                    }
                                }
                                else if(choice == "roll")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Must choose either 'pay', 'card', or 'roll'!");
                                    continue;
                                }

                            }
                        }

                    }                   
                }

                //Rolls               
                int die1 = roll();
                System.Threading.Thread.Sleep(250);
                int die2 = roll();
                int total = die1 + die2;
                if (die1 != die2)
                {
                    rolledDouble = false;
                    Console.WriteLine("\n" + currentPlayer.getName() + " rolled " + die1 + " and " + die2 + " for a total " + total);

                    if (currentPlayer.getTimeInJail() == 3)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has spent 3 turns in jail; that's long enough! Pay $50 and get outta here!");
                        manageProperties(currentPlayer, null, 50);
                        currentPlayer.resetJailTime();
                        currentPlayer.setJailStatus(false);
                        currentPlayer.setMoney(currentPlayer.getMoney() - 50);
                    }
                    else if(currentPlayer.playerJailed() && currentPlayer.getTimeInJail() < 3)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has failed to roll doubles and must remain in Jail!");
                    }
                }
                else
                {
                    Console.WriteLine("\n" + currentPlayer.getName() + " rolled " + die1 + " and " + die2 + " for a total " + total);
                    doubleCount++;
                    //Player gets out of jail on double roll
                    if(currentPlayer.playerJailed() && currentPlayer.getTimeInJail() <= 3)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has rolled doubles and gets to leave Jail!");
                        currentPlayer.resetJailTime();
                        currentPlayer.setJailStatus(false);
                    }
                    //Go to jail on third double in a row
                    if (doubleCount == 3)
                    {
                        Console.WriteLine(currentPlayer.getName() + " has rolled 3 doubles in a row! Go directly to Jail for speeding!");
                        currentPlayer.setCurrentSpace(10);
                        currentPlayer.setJailStatus(true);
                        break;
                    }
                }

                //In jail player rolled double or out of jail player rolls
                if (!currentPlayer.playerJailed())
                {
                    //Move Player
                    int spacesMoved = 0;
                    int currentSpace = currentPlayer.getSpace();
                    while (spacesMoved < total)
                    {
                        spacesMoved++;//Move forward one space
                        currentSpace++;
                        currentPlayer.setCurrentSpace(currentSpace);
                        //Reset from 40 to 0 (player gets to 'GO')
                        if (currentPlayer.getSpace() == 40)
                        {
                            Console.WriteLine(currentPlayer.getName() + " passed GO! Collect $200");
                            currentPlayer.setCurrentSpace(0);
                            currentSpace = 0;
                            currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                        }
                    }

                    //Player lands on space
                    BoardSpace space = boardSpaces[currentPlayer.getSpace()];

                    //Space is a property
                    if (space.getCost() > 0)
                    {
                        //If space is unowned
                        if (space.getOwner() == null)
                        {
                            if (space.getCost() > currentPlayer.getMoney())
                            {
                                Console.WriteLine(currentPlayer.getName() + " landed on " + space.getName() + ", but does not have enough money to buy it!");
                                while (true)
                                {
                                    Console.WriteLine("\nWould you like to mananage your properties to get the money for this property?");
                                    Console.WriteLine("Enter 'y' for yes or 'n' for no. y/n: ");
                                    string choice = Console.ReadLine();
                                    if(choice == "y")
                                    {
                                        manageProperties(currentPlayer, null, 0);
                                        buyProperty(currentPlayer, total);
                                        break;
                                    }else if(choice == "n")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Choice to manage properties must be 'y' or 'n'!");
                                    }
                                }
                                if(currentPlayer.getMoney() >= space.getCost())
                                {
                                    buyProperty(currentPlayer, total);
                                }
                                break;
                            }
                            else
                            {
                                buyProperty(currentPlayer, total);
                            }

                        }
                        //If space is owned (not by current player)
                        else if (space.getOwner() != currentPlayer)
                        {
                            int rent = getRent(space.getSpaceNumber(), total);
                            string mortgageMessage = "";
                            if(rent == 0)
                            {
                                mortgageMessage = " But this property is mortgaged!";
                            }
                            Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ", owned by " + space.getOwner().getName() + "!" + mortgageMessage + " Pay them $" + rent + "!");
                            //Pay owner if enough money is owned by current player
                            if ((currentPlayer.getMoney() - rent) >= 0)
                            {
                                currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                                space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                            }
                            else
                            {
                                manageProperties(currentPlayer, space.getOwner(), rent);
                                Console.WriteLine(currentPlayer.getName() + "is bankrupt! Forfeit all money and properties to " + space.getOwner().getName() + "!");
                            }

                        }
                    }
                    //Space is Chance, Community Chest, Tax Spot, or Corner
                    else
                    {
                        //Chance
                        if (space.getSpaceNumber() == 7 || space.getSpaceNumber() == 22 || space.getSpaceNumber() == 36)
                        {
                            Console.WriteLine(currentPlayer.getName() + " has landed on Chance!");
                            drawChanceCard(currentPlayer, total);
                        }
                        //Community Chest
                        else if (space.getSpaceNumber() == 2 || space.getSpaceNumber() == 17 || space.getSpaceNumber() == 33)
                        {
                            Console.WriteLine(currentPlayer.getName() + " has landed on Community Chest!");
                            drawCommunityChestCard(currentPlayer, total);
                        }
                        //Income Tax
                        else if (space.getSpaceNumber() == 4)
                        {
                            //10% or 200
                            int percent = System.Convert.ToInt32(currentPlayer.getMoney() * 0.1);
                            int tax = 200;
                            if (percent < 200)
                            {
                                tax = percent;
                            }
                            Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ". Pay $" + tax + "!");
                            if(currentPlayer.getMoney() < tax)
                            {
                                manageProperties(currentPlayer, null, tax);
                            }
                            else
                            {
                                currentPlayer.setMoney(currentPlayer.getMoney() - tax);
                            }                           
                        }
                        //Luxury Tax
                        else if (space.getSpaceNumber() == 38)
                        {
                            Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + ". Pay $75!");
                            if (currentPlayer.getMoney() < 75)
                            {
                                manageProperties(currentPlayer, null, 75);
                            }
                            else
                            {
                                currentPlayer.setMoney(currentPlayer.getMoney() - 75);
                            }
                        }
                        //Else if Go To Jail
                        else if (space.getSpaceNumber() == 30)
                        {
                            Console.WriteLine(currentPlayer.getName() + " has landed on " + space.getName() + "! Go directly to Jail!");
                            currentPlayer.setCurrentSpace(10);
                            currentPlayer.setJailStatus(true);
                            break;
                        }
                        else
                        {
                            Console.Write(currentPlayer.getName() + " has landed on " + space.getName() + "!");
                            if (space.getSpaceNumber() == 0)
                            {
                                Console.Write(" Right on the Money!\n");
                            }
                            if (space.getSpaceNumber() == 10)
                            {
                                Console.Write(" Luckily they're just visiting!\n");
                            }
                            if (space.getSpaceNumber() == 20)
                            {
                                Console.Write(" What a value!\n");
                            }
                        }
                    }
                }
          
            }

            while (true)
            {
                Console.WriteLine("\nYour turn is completed, would you like to manage your properties?");
                Console.Write("Type 'y' to manage properties, or 'n' to end your turn: ");
                string choice = Console.ReadLine();
                if(choice == "y")
                {
                    manageProperties(currentPlayer, null, 0);
                    break;
                }else if(choice == "n")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your selection must be either 'y' or 'n'!");
                    continue;
                }
            }
            


        }

        static void openGame()
        {
            Console.WriteLine("Welcome to Monopoly!");
            int numPlayers = 0;
            //Get Player Count
            while(numPlayers == 0)
            {
                Console.Write("How many players? Enter 2-4: ");
                try
                {
                    numPlayers = Convert.ToInt32(Console.ReadLine());
                    if (numPlayers < 2 || numPlayers > 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Number of players must be between 2-4!");
                        numPlayers = 0;
                        continue;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Must enter a NUMBER between 2-4!");
                    continue;
                }
                Console.Clear();
            }
            int count = 1;
            while(count <= numPlayers)
            {
                Player newPlayer = new Player("Player " + count);
                playerList.Add(newPlayer);
                count++;
            }            
        }

        static void gameLoop()
        {
            while (true)
            {
                foreach(Player currentPlayer in playerList)
                {
                    if(currentPlayer.getMoney() != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("It is " + currentPlayer.getName() + "'s Turn! You have $" + currentPlayer.getMoney());
                        System.Threading.Thread.Sleep(1500);
                        playerRoll(currentPlayer);
                    }
                    
                }
            }
        }

        static void Main(string[] args)
        {
            openGame();

            populateBoard();
            setIndexes();
            setChance();
            setCommunityChest();

            gameLoop();
        }
    }
}
