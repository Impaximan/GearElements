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
using Terraria.Utilities;

namespace GearElements
{
    class ElementalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        Element element = Element.None;
        int elementalEffect = 0;
        Element accessoryElement = Element.None;

        public override bool NeedsSaving(Item item)
        {
            return item.damage > 0 && !item.summon && !item.accessory && item.maxStack == 1;
        }

        //public override void PostReforge(Item item)
        //{
        //    if (item.damage > 0 && !item.summon && !item.accessory)
        //    {
        //        elementalEffect = Main.rand.Next(1, GearElements.elementalEffectAmount + 1);
        //    }

        //    if (item.accessory)
        //    {
        //        newAccessoryElement();
        //    }
        //}

        public override TagCompound Save(Item item)
        {
            return new TagCompound
            {
                {"element", element.ToString()},
                {"elementalEffect", elementalEffect}
            };
        }

        public override void HoldItem(Item item, Player player)
        {
            if (element == Element.Electric && elementalEffect == 3)
            {
                player.AddBuff(BuffID.Electrified, 1);
            }
            if (element == Element.Metal && elementalEffect == 3)
            {
                player.statDefense += 10;
            }
            if (element == Element.Light && elementalEffect == 3)
            {
                Lighting.AddLight(player.Center, 255 / 50, 255 / 50, 255 / 50);
            }
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref float add, ref float mult, ref float flat)
        {
            base.ModifyWeaponDamage(item, player, ref add, ref mult, ref flat);
            if (element == Element.Electric && elementalEffect == 3)
            {
                mult *= 1.75f;
            }
            if (element == Element.Earth && elementalEffect == 3)
            {
                if (player.velocity == Vector2.Zero)
                {
                    mult *= 1.5f;
                }
            }
        }

        public override void Load(Item item, TagCompound tag)
        {
            element = ElementUtils.elementFromString(tag.GetString("element"));
            elementalEffect = tag.GetInt("elementalEffect");
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (item.damage > 0 && !item.summon && !item.accessory && item.maxStack == 1)
            {
                element = ElementUtils.getRandomElement();
                elementalEffect = Main.rand.Next(1, GearElements.elementalEffectAmount + 1);
            }

            if (item.accessory)
            {
                newAccessoryElement();
            }
            return base.ChoosePrefix(item, rand);
        }

        public void newAccessoryElement()
        {
            if (Main.rand.NextFloat() >= .333f)
            {
                accessoryElement = Element.None;
                return;
            }
            accessoryElement = ElementUtils.getRandomElement();
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine nameLine = tooltips.FirstOrDefault(x => x.Name == "ItemName" && x.mod == "Terraria");
            Player player = Main.LocalPlayer;

            //bool inInventory = false;
            //foreach (Item invItem in player.inventory)
            //{
            //    if (invItem.owner == item.owner)
            //    {
            //        inInventory = true;
            //    }
            //}
            //foreach (Item invItem in player.armor)
            //{
            //    if (invItem.owner == item.owner)
            //    {
            //        inInventory = true;
            //    }
            //}
            //if (!inInventory)
            //{
            //    return;
            //}

            if (element != Element.None)
            {
                tooltips.Insert(1, new TooltipLine(mod, "element", element.ToString()));
                tooltips.FirstOrDefault(x => x.Name == "element" && x.mod == "GearElements").overrideColor = ElementUtils.getElementColor(element);

                tooltips.Add(new TooltipLine(mod, "elementEffect", "+" + ElementUtils.getWeaponElementalEffectString(element, elementalEffect)));
                tooltips.FirstOrDefault(x => x.Name == "elementEffect" && x.mod == "GearElements").overrideColor = ElementUtils.getElementColor(element)/*Color.FromNonPremultiplied(255, 251, 168, 255)*/;
                //tooltips.FirstOrDefault(x => x.Name == "elementEffect" && x.mod == "GearElements").isModifier = true;
            }
            if (accessoryElement != Element.None && tooltips.FirstOrDefault(x => x.Name == "Social" && x.mod == "Terraria") == null)
            {
                //nameLine.text = accessoryElement.ToString() + " " + nameLine.text;
                tooltips.Add(new TooltipLine(mod, "accessoryElementBoost", "+8% damage with " + accessoryElement + " weapons"));
                tooltips.FirstOrDefault(x => x.Name == "accessoryElementBoost" && x.mod == "GearElements").overrideColor = ElementUtils.getElementColor(accessoryElement)/*Color.FromNonPremultiplied(255, 251, 168, 255)*/;
            }
        }
    }
}
