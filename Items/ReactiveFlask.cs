using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TR.Alchemy;

namespace TR.Items
{
	public class ReactiveFlask : AlchemyClass
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Reacts to different elements in the world");

		}
		public override void SafeSetDefaults()
		{
			item.crit = 4;
			item.damage = 30;
			item.shootSpeed = 17f;
			item.knockBack = 7f;
			item.useStyle = 1;
			item.useAnimation = 24;
			item.useTime = 24;
			item.width = 32;
			item.height = 32;
			item.rare = 9;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 50);
			item.shoot = mod.ProjectileType("ReactiveFlaskThrown");
		}
	}
}
