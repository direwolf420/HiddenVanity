using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;

namespace HiddenVanity
{
	public class HiddenVanity : Mod
	{
		public override void Load()
		{
			On_Player.UpdateVisibleAccessory += Player_UpdateVisibleAccessory; //accessories (check vanity inside)

			//boneArmor/frostArmor doesn't need fixing
			On_Player.PlayerFrame += Player_PlayerFrame; //Armor vanity slots 1
			On_Main.DoUpdate_WhilePaused += Main_DoUpdate_WhilePaused; //Armor vanity slots 2
			On_Player.ApplyArmorSoundAndDustChanges += Player_ApplyArmorSoundAndDustChanges; //Armor vanity slots 3
			On_Player.ApplyEquipVanity_Item += Player_ApplyEquipVanity_Item; //Wings, werewolf/merman, modded
		}

		private void Player_UpdateVisibleAccessory(On_Player.orig_UpdateVisibleAccessory orig, Player self, int itemSlot, Item item, bool modded)
		{
			var stringColor = self.stringColor;
			var handon = self.handon;
			var handoff = self.handoff;
			var backpack = self.backpack;
			var tail = self.tail;
			var back = self.back;
			var front = self.front;
			var shoe = self.shoe;
			var waist = self.waist;
			var shield = self.shield;
			var neck = self.neck;
			var faceHead = self.faceHead;
			var faceFlower = self.faceFlower;
			var face = self.face;
			var beard = self.beard;
			var balloonFront = self.balloonFront;
			var balloon = self.balloon;
			var wings = self.wings;

			var yoraiz0rEye = self.yoraiz0rEye;
			var yoraiz0rDarkness = self.yoraiz0rDarkness;
			var leinforsHair = self.leinforsHair;
			var hasFloatingTube = self.hasFloatingTube;
			var hasUnicornHorn = self.hasUnicornHorn;
			var hasAngelHalo = self.hasAngelHalo;
			var hasRainbowCursor = self.hasRainbowCursor;

			orig(self, itemSlot, item, modded);

			if (!modded && (itemSlot < 13 || itemSlot > 20))
			{
				//If vanilla and not a vanity slot, don't hide equips
				return;
			}

			if (modded && itemSlot < self.GetModPlayer<ModAccessorySlotPlayer>().SlotCount)
			{
				//If modded and not a vanity slot, don't hide equips
				//(vanity slots occupy the second half of the item array, the first half corresponds to functional items)
				return;
			}

			//Revert
			HideEquips(self, stringColor, handon, handoff, backpack, tail, back, front, shoe, waist, shield, neck, faceHead, faceFlower, face, beard, balloonFront, balloon, wings, yoraiz0rEye, yoraiz0rDarkness, leinforsHair, hasFloatingTube, hasUnicornHorn, hasAngelHalo, hasRainbowCursor);
		}

		private static void HideEquips(Player self, int stringColor, int handon, int handoff, int backpack, int tail, int back, int front, int shoe, int waist, int shield, int neck, int faceHead, int faceFlower, int face, int beard, int balloonFront, int balloon, int wings, int yoraiz0rEye, bool yoraiz0rDarkness, bool leinforsHair, bool hasFloatingTube, bool hasUnicornHorn, bool hasAngelHalo, bool hasRainbowCursor)
		{
			Config cfg = Config.Instance;

			if (!cfg.HiddenVanity(self))
			{
				return;
			}

			if (cfg.HideAllEquips)
			{
				self.stringColor = stringColor;
				self.handon = handon;
				self.handoff = handoff;
				self.backpack = backpack;
				self.tail = tail;
				self.back = back;
				self.front = front;
				self.shoe = shoe;
				self.waist = waist;
				self.shield = shield;
				self.neck = neck;
				self.faceHead = faceHead;
				self.faceFlower = faceFlower;
				self.face = face;
				self.beard = beard;
				self.balloonFront = balloonFront;
				self.balloon = balloon;
				self.wings = wings;

				self.yoraiz0rEye = yoraiz0rEye;
				self.yoraiz0rDarkness = yoraiz0rDarkness;
				self.leinforsHair = leinforsHair;
				self.hasFloatingTube = hasFloatingTube;
				self.hasUnicornHorn = hasUnicornHorn;
				self.hasAngelHalo = hasAngelHalo;
				self.hasRainbowCursor = hasRainbowCursor;

				return;
			}

			if (cfg.HideStringColor)
			{
				self.stringColor = stringColor;
			}
			if (cfg.HideHandOn)
			{
				self.handon = handon;
			}
			if (cfg.HideHandOff)
			{
				self.handoff = handoff;
			}
			if (cfg.HideBackpack)
			{
				self.backpack = backpack;
			}
			if (cfg.HideTail)
			{
				self.tail = tail;
			}
			if (cfg.HideBack)
			{
				self.back = back;
			}
			if (cfg.HideFront)
			{
				self.front = front;
			}
			if (cfg.HideShoe)
			{
				self.shoe = shoe;
			}
			if (cfg.HideWaist)
			{
				self.waist = waist;
			}
			if (cfg.HideShield)
			{
				self.shield = shield;
			}
			if (cfg.HideNeck)
			{
				self.neck = neck;
			}
			if (cfg.HideFaceHead)
			{
				self.faceHead = faceHead;
			}
			if (cfg.HideFaceFlower)
			{
				self.faceFlower = faceFlower;
			}
			if (cfg.HideFace)
			{
				self.face = face;
			}
			if (cfg.HideBeard)
			{
				self.beard = beard;
			}
			if (cfg.HideBalloonFront)
			{
				self.balloonFront = balloonFront;
			}
			if (cfg.HideBalloon)
			{
				self.balloon = balloon;
			}
			if (cfg.HideWings)
			{
				self.wings = wings;
			}

			/*
				self.yoraiz0rEye = yoraiz0rEye;
				self.yoraiz0rDarkness = yoraiz0rDarkness;
				self.leinforsHair = leinforsHair;
				self.hasFloatingTube = hasFloatingTube;
				self.hasUnicornHorn = hasUnicornHorn;
				self.hasAngelHalo = hasAngelHalo;
				self.hasGingerBeard = hasGingerBeard;
				self.hasRainbowCursor = hasRainbowCursor;
			 */

			if (cfg.HideYoraiz0rEye)
			{
				self.yoraiz0rEye = yoraiz0rEye;
			}
			if (cfg.HideYoraiz0rDarkness)
			{
				self.yoraiz0rDarkness = yoraiz0rDarkness;
			}
			if (cfg.HideLeinforsHair)
			{
				self.leinforsHair = leinforsHair;
			}
			if (cfg.HideFloatingTube)
			{
				self.hasFloatingTube = hasFloatingTube;
			}
			if (cfg.HideUnicornHorn)
			{
				self.hasUnicornHorn = hasUnicornHorn;
			}
			if (cfg.HideAngelHalo)
			{
				self.hasAngelHalo = hasAngelHalo;
			}
			if (cfg.HideRainbowCursor)
			{
				self.hasRainbowCursor = hasRainbowCursor;
			}
		}

		//Based on this:
		/*
		private void UpdateVisibleAccessory(int itemSlot, Item item)
		{
			if (item.stringColor > 0)
				stringColor = item.stringColor;

			if (item.handOnSlot > 0)
				handon = item.handOnSlot;

			if (item.handOffSlot > 0)
				handoff = item.handOffSlot;

			if (item.backSlot > 0)
			{
				if (ArmorIDs.Back.Sets.DrawInBackpackLayer[item.backSlot])
				{
					backpack = item.backSlot;
				}
				else if (ArmorIDs.Back.Sets.DrawInTailLayer[item.backSlot])
				{
					tail = item.backSlot;
				}
				else
				{
					back = item.backSlot;
					front = -1;
				}
			}

			if (item.frontSlot > 0)
				front = item.frontSlot;

			if (sitting.isSitting)
				back = -1;

			if (item.shoeSlot > 0)
			{
				shoe = item.shoeSlot;
				if (!Male && ArmorIDs.Shoe.Sets.MaleToFemaleID[shoe] > 0)
					shoe = ArmorIDs.Shoe.Sets.MaleToFemaleID[shoe];
			}

			if (item.waistSlot > 0)
				waist = item.waistSlot;

			if (item.shieldSlot > 0)
				shield = item.shieldSlot;

			if (item.neckSlot > 0)
				neck = item.neckSlot;

			if (item.faceSlot > 0)
			{
				if (ArmorIDs.Face.Sets.DrawInFaceHeadLayer[item.faceSlot])
					faceHead = item.faceSlot;
				else if (ArmorIDs.Face.Sets.DrawInFaceFlowerLayer[item.faceSlot])
					faceFlower = item.faceSlot;
				else
					face = item.faceSlot;
			}

			if (item.balloonSlot > 0)
			{
				if (ArmorIDs.Balloon.Sets.DrawInFrontOfBackArmLayer[item.balloonSlot])
					balloonFront = item.balloonSlot;
				else
					balloon = item.balloonSlot;
			}

			if (item.wingSlot > 0)
				wings = item.wingSlot;

			if (item.type == 3580)
				yoraiz0rEye = itemSlot - 2;

			if (item.type == 3581)
				yoraiz0rDarkness = true;

			if (item.type == 3929)
				leinforsHair = true;

			if (item.type == 4404)
				hasFloatingTube = true;

			if (item.type == 4563)
				hasUnicornHorn = true;

			if (item.type == 1987)
				hasAngelHalo = true;

			if (item.type == 5075)
				hasRainbowCursor = true;
		}
		*/

		private void Player_PlayerFrame(On_Player.orig_PlayerFrame orig, Player self)
		{
			orig(self);

			HideVanityArmor(self);
		}

		private void Main_DoUpdate_WhilePaused(On_Main.orig_DoUpdate_WhilePaused orig)
		{
			orig();

			Player player = Main.LocalPlayer;
			if (!player.hostile)
			{
				HideVanityArmor(player);
			}
			/*
			 * Main.player[myPlayer].head = Main.player[myPlayer].armor[0].headSlot;
				Main.player[myPlayer].body = Main.player[myPlayer].armor[1].bodySlot;
				Main.player[myPlayer].legs = Main.player[myPlayer].armor[2].legSlot;
				if (!Main.player[myPlayer].hostile) {
					if (Main.player[myPlayer].armor[10].headSlot >= 0)
						Main.player[myPlayer].head = Main.player[myPlayer].armor[10].headSlot;

					if (Main.player[myPlayer].armor[11].bodySlot >= 0)
						Main.player[myPlayer].body = Main.player[myPlayer].armor[11].bodySlot;

					if (Main.player[myPlayer].armor[12].legSlot >= 0)
						Main.player[myPlayer].legs = Main.player[myPlayer].armor[12].legSlot;
				}
			 */
		}

		private void Player_ApplyArmorSoundAndDustChanges(On_Player.orig_ApplyArmorSoundAndDustChanges orig, Player self)
		{
			orig(self);

			HideVanityArmor(self);
		}

		private void Player_ApplyEquipVanity_Item(On_Player.orig_ApplyEquipVanity_Item orig, Player self, Item currentItem)
		{
			//Only called on vanity slots (on vanilla and modded slots)
			var stringColor = self.stringColor;
			var handon = self.handon;
			var handoff = self.handoff;
			var backpack = self.backpack;
			var tail = self.tail;
			var back = self.back;
			var front = self.front;
			var shoe = self.shoe;
			var waist = self.waist;
			var shield = self.shield;
			var neck = self.neck;
			var faceHead = self.faceHead;
			var faceFlower = self.faceFlower;
			var face = self.face;
			var beard = self.beard;
			var balloonFront = self.balloonFront;
			var balloon = self.balloon;
			var wings = self.wings;

			var yoraiz0rEye = self.yoraiz0rEye;
			var yoraiz0rDarkness = self.yoraiz0rDarkness;
			var leinforsHair = self.leinforsHair;
			var hasFloatingTube = self.hasFloatingTube;
			var hasUnicornHorn = self.hasUnicornHorn;
			var hasAngelHalo = self.hasAngelHalo;
			var hasRainbowCursor = self.hasRainbowCursor;

			orig(self, currentItem);

			HideEquips(self, stringColor, handon, handoff, backpack, tail, back, front, shoe, waist, shield, neck, faceHead, faceFlower, face, beard, balloonFront, balloon, wings, yoraiz0rEye, yoraiz0rDarkness, leinforsHair, hasFloatingTube, hasUnicornHorn, hasAngelHalo, hasRainbowCursor);
		}

		private static void HideVanityArmor(Player player)
		{
			Config cfg = Config.Instance;
			if (!cfg.HiddenVanity(player))
			{
				return;
			}

			Item[] armor = player.armor;
			if (cfg.HideAllEquips)
			{
				player.head = player.hideVisibleAccessory[0] ? -1 : armor[0].headSlot;
				player.body = player.hideVisibleAccessory[1] ? -1 : armor[1].bodySlot;
				player.legs = player.hideVisibleAccessory[2] ? -1 : armor[2].legSlot;
				return;
			}

			if (cfg.HideHead)
			{
				player.head = armor[0].headSlot;
			}
			if (cfg.HideBody)
			{
				player.body = armor[1].bodySlot;
			}
			if (cfg.HideLegs)
			{
				player.legs = armor[2].legSlot;
			}
		}
	}
}
