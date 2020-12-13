using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TR.Items
{
	public class Ignition : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A portable way to create reactions");

		}
		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 12;
			item.useTime = 12;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shootSpeed = 14f;
			item.rare = 4;
			item.shoot = mod.ProjectileType("IgnitionThrown");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{		
			float numberProjectiles = 6;
			float rotation = MathHelper.ToRadians(46);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 46f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * (float)2.95f, perturbedSpeed.Y * (float)2.95f, type, 0, 0, player.whoAmI);
			}
			return false;
		}
	}
}
