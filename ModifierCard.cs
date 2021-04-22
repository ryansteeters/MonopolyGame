using System.Collections;
using System.Collections.Generic;

namespace Monopoly
{
    public class ModifierCard
    {
        private string cardType;
        private string description;
        private string modString;

        public ModifierCard(string type, string message, string modifier)
        {
            cardType = type;
            description = message;
            modString = modifier;
        }

        public string getCardType()
        {
            return cardType;
        }

        public string getDescription()
        {
            return description;
        }

        public string getModifier()
        {
            return modString;
        }
    }
}
