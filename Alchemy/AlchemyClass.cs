using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace TR.Alchemy
{
	public abstract class AlchemyClass : ModItem
	{
		public override bool CloneNewInstances => true;

		
		public virtual void SafeSetDefaults() 
		{
		}
		public sealed override void SetDefaults() 
		{
			SafeSetDefaults();
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) 
		{
			add += AlchemyPlayer.ModPlayer(player).alchemyDamagePlus;
			mult *= AlchemyPlayer.ModPlayer(player).alchemyDamageMultiplier;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			knockback += AlchemyPlayer.ModPlayer(player).alchemyKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit) 
		{
			
			crit += AlchemyPlayer.ModPlayer(player).alchemyCrit;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) 
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null) 
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " alchemy " + damageWord;
			}
		}
	}
}