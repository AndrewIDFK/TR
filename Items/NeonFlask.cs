using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TR.Alchemy;

namespace TR.Items
{
	public class NeonFlask : AlchemyClass
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Creates Neon released from the Flask");

		}
		public override void SafeSetDefaults()
		{
			item.damage = 45;
			item.shootSpeed = 17f;
			item.knockBack = 7f;
			item.useStyle = 1;
			item.useAnimation = 24;
			item.useTime = 24;
			item.width = 32;
			item.height = 32;
			item.rare = 10;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 2);
			item.shoot = mod.ProjectileType("NeonFlaskThrown");
		}
	}
}
