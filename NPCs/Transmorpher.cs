using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TransmorpherNPC.NPCs
{
    [AutoloadHead]
    public class Transmorpher : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ezekiel");
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 250;
            NPC.lifeMax = 2500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 450;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22; //guide animation type
        }

        //TODO: change spawn condition
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
            // for (var i = 0; i < 255; i++)
            // {
            //     Player player = Main.player[i];
            //     foreach (Item item in player.inventory)
            //     {
            //         if (item.type == ItemID.WoodenArrow)
            //         {
            //             return true;
            //         }
            //     }
            // }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>(){
                "Ezekiel",
                "Elias",
                "Jeremiah"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Transmorph";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                //TODO:set up transmorph
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Zenith
            shop.item[nextSlot].SetDefaults(ItemID.Zenith, false);
            shop.item[nextSlot].value = 1;
            nextSlot++;

            //LastPrism only if eye of cathulu has been killed
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LastPrism, false);
                shop.item[nextSlot].value = 100;
            }

        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Transmorpher>());
            switch (Main.rand.Next(1))
            {
                case 0:
                    return "Suck deez nuts";
                case 1:
                    return "Suck dem nuts";
                default:
                    return "Suck el nutto";

            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 500;
            knockback = 25f;

        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 1;
            randExtraCooldown = 0;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.PaladinsHammerFriendly;
            attackDelay = 0;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 100f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.PlatinumCoin, 1000, false);
        }

    }
}