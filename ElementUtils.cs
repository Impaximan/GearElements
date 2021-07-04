using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.Map;
using Terraria.GameContent.UI;
using Terraria.ModLoader.IO;

namespace GearElements
{
    class ElementUtils
    {
        public static Element getRandomElement()
        {
            int elementChosen = Main.rand.Next(1, 13);
            if (elementChosen == 1)
            {
                return Element.Fire;
            }
            else if (elementChosen == 2)
            {
                return Element.Cold;
            }
            else if (elementChosen == 3)
            {
                return Element.Water;
            }
            else if (elementChosen == 4)
            {
                return Element.Toxic;
            }
            else if (elementChosen == 5)
            {
                return Element.Electric;
            }
            else if (elementChosen == 6)
            {
                return Element.Wind;
            }
            else if (elementChosen == 7)
            {
                return Element.Earth;
            }
            else if (elementChosen == 8)
            {
                return Element.Metal;
            }
            else if (elementChosen == 9)
            {
                return Element.Radiation;
            }
            else if (elementChosen == 10)
            {
                return Element.Light;
            }
            else if (elementChosen == 11)
            {
                return Element.Shadow;
            }
            else if (elementChosen == 12)
            {
                return Element.Blood;
            }
            else
            {
                return Element.None;
            }
        }

        public static Element elementFromString(string String)
        {
            if (String == "Fire")
            {
                return Element.Fire;
            }
            else if (String == "Cold")
            {
                return Element.Cold;
            }
            else if (String == "Water")
            {
                return Element.Water;
            }
            else if (String == "Toxic")
            {
                return Element.Toxic;
            }
            else if (String == "Electric")
            {
                return Element.Electric;
            }
            else if (String == "Wind")
            {
                return Element.Wind;
            }
            else if (String == "Earth")
            {
                return Element.Earth;
            }
            else if (String == "Metal")
            {
                return Element.Metal;
            }
            else if (String == "Radiation")
            {
                return Element.Radiation;
            }
            else if (String == "Light")
            {
                return Element.Light;
            }
            else if (String == "Shadow")
            {
                return Element.Shadow;
            }
            else if (String == "Blood")
            {
                return Element.Blood;
            }
            else
            {
                return Element.None;
            }
        }

        public static Color getElementColor(Element element)
        {
            if (element == Element.Fire)
            {
                return Color.FromNonPremultiplied(255, 84, 27, 255);
            }
            else if (element == Element.Cold)
            {
                return Color.FromNonPremultiplied(121, 231, 231, 255);
            }
            else if (element == Element.Water)
            {
                return Color.FromNonPremultiplied(58, 91, 208, 255);
            }
            else if (element == Element.Toxic)
            {
                return Color.FromNonPremultiplied(110, 197, 111, 255);
            }
            else if (element == Element.Electric)
            {
                return Color.FromNonPremultiplied(202, 177, 255, 255);
            }
            else if (element == Element.Wind)
            {
                return Color.FromNonPremultiplied(178, 178, 178, 255);
            }
            else if (element == Element.Earth)
            {
                return Color.FromNonPremultiplied(165, 144, 111, 255);
            }
            else if (element == Element.Metal)
            {
                return Color.FromNonPremultiplied(190, 210, 214, 255);
            }
            else if (element == Element.Radiation)
            {
                return Color.FromNonPremultiplied(212, 131, 63, 255);
            }
            else if (element == Element.Light)
            {
                return Color.FromNonPremultiplied(168, 240, 255, 255);
            }
            else if (element == Element.Shadow)
            {
                return Color.FromNonPremultiplied(88, 0, 128, 255);
            }
            else if (element == Element.Blood)
            {
                return Color.FromNonPremultiplied(118, 0, 0, 255);
            }
            else
            {
                return Color.Gray;
            }
        }

        public static string getWeaponElementalEffectString(Element element, int effectType)
        {
            if (element == Element.Fire)
            {
                switch (effectType)
                {
                    case 1: 
                        return "Ignites hit enemies";
                    case 2:
                        return "Creates a flame cloud on critical hits";
                    case 3:
                        return "Releases sparks from hit enemies";
                    case 4:
                        return "Creates an explosion upon killing enemies";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Cold)
            {
                switch (effectType)
                {
                    case 1:
                        return "Chills hit enemies";
                    case 2:
                        return "Rains icy shards from the sky on critical hits";
                    case 3:
                        return "Creates icy mist around you while held";
                    case 4:
                        return "Freezes nearby enemies upon killing a target";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Water)
            {
                switch (effectType)
                {
                    case 1:
                        return "Drenches hit enemies in water";
                    case 2:
                        return "Critical hits cause damaging water to be released from your body";
                    case 3:
                        return "30% increased damage when used during rain";
                    case 4:
                        return "Creates a high knockback wave upon killing enemies";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Toxic)
            {
                switch (effectType)
                {
                    case 1:
                        return "Poisons hit enemies";
                    case 2:
                        return "Inflicts hit enemies with venom on critical hits";
                    case 3:
                        return "Hitting enemies will occasionally create a toxic spore cloud";
                    case 4:
                        return "Killing enemies creates a toxic spore cloud at their position";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Electric)
            {
                switch (effectType)
                {
                    case 1:
                        return "Electrocutes hit enemies";
                    case 2:
                        return "Chains lightning to nearby enemies on critical hits";
                    case 3:
                        return "Does 75% increased damage but electrocutes you when held"; //Done
                    case 4:
                        return "Killing an enemy will spread the debuffs they had to other nearby enemies";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Wind)
            {
                switch (effectType)
                {
                    case 1:
                        return "Does increased knockback to hit enemies";
                    case 2:
                        return "Critical hits have significantly higher knockback";
                    case 3:
                        return "30% increased damage but using this weapon will blow you towards your cursor";
                    case 4:
                        return "Killing an enemy will pull other nearby enemies to their position";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Earth)
            {
                switch (effectType)
                {
                    case 1:
                        return "Does 30% increased damage to enemies that are moving slowly";
                    case 2:
                        return "Critical hits will cause the enemy to temporarily have much higher gravity";
                    case 3:
                        return "Does 50% increased damage while standing still"; //Done
                    case 4:
                        return "Killing an enemy will create damaging, bouncing stones where they were";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Metal)
            {
                switch (effectType)
                {
                    case 1:
                        return "Temporarily decreases hit enemy defense";
                    case 2:
                        return "Critical hits deal 50% more damage than normal";
                    case 3:
                        return "You gain an additional 10 defense while holding this item"; //Done
                    case 4:
                        return "Killing an enemy increases your defense by 15 for 10 seconds";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Radiation)
            {
                switch (effectType)
                {
                    case 1:
                        return "";
                    case 2:
                        return "";
                    case 3:
                        return "";
                    case 4:
                        return "";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Light)
            {
                switch (effectType)
                {
                    case 1:
                        return "Causes hit enemies to glow";
                    case 2:
                        return "Critical hits will cause multiple damaging beams of light to erupt from you";
                    case 3:
                        return "You will emit light while holding this item"; //Done
                    case 4:
                        return "Killing an enemy creates a light wisp that emits a large amount of light";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Shadow)
            {
                switch (effectType)
                {
                    case 1:
                        return "";
                    case 2:
                        return "";
                    case 3:
                        return "";
                    case 4:
                        return "";
                    default:
                        return "None";
                }
            }
            else if (element == Element.Blood)
            {
                switch (effectType)
                {
                    case 1:
                        return "";
                    case 2:
                        return "";
                    case 3:
                        return "";
                    case 4:
                        return "";
                    default:
                        return "None";
                }
            }
            else
            {
                return "None";
            }
        }
    }
}
