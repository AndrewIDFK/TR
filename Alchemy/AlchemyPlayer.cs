using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TR.Alchemy
{
	public class AlchemyPlayer : ModPlayer
	{
		public static AlchemyPlayer ModPlayer(Player player) 
		{
			return player.GetModPlayer<AlchemyPlayer>();
		}

		public float alchemyDamagePlus;
		public float alchemyDamageMultiplier = 1f;
		public float alchemyKnockback;
		public int alchemyCrit;

		public override void ResetEffects() 
		{
			ResetVariables();
		}

		public override void UpdateDead() 
		{
			ResetVariables();
		}

		private void ResetVariables() 
		{
			alchemyDamagePlus = 0f;
			alchemyDamageMultiplier = 1f;
			alchemyKnockback = 0f;
			alchemyCrit = 0;
		}
	}
}