using TransmorpherNPC.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace TransmorpherNPC
{
    public class TransmorpherNPC : ModSystem
    {

        public UserInterface TransmorpherUserInterface;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                TransmorpherUserInterface = new UserInterface();
            }

        }
        public override void UpdateUI(GameTime gameTime)
        {
            TransmorpherUserInterface?.Update(gameTime);

        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Example Person UI",
                    delegate
                    {
                        // If the current UIState of the UserInterface is null, nothing will draw. We don't need to track a separate .visible value.
                        TransmorpherUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }


    }

}