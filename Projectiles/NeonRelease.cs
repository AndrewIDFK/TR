using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TR.Projectiles
{
	public class NeonRelease : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 150;
			projectile.height = 150;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 28;
        }
		
		public override void AI()
		{
			float num468 = 25f;
			int num469 = 0;
			while ((float)num469 < num468)
			{
				float num470 = Main.rand.Next(-9, 10);
				float num471 = Main.rand.Next(-9, 10);
				float num472 = Main.rand.Next(2, 7);
				float num473 = (float)Math.Sqrt(num470 * num470 + num471 * num471);
				num473 = num472 / num473;
				num470 *= num473;
				num471 *= num473;
				int num474 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 70, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, Color.HotPink, 1f); //86
				Main.dust[num474].noGravity = true;
				Main.dust[num474].scale = 1.15f;
				Main.dust[num474].position.X = projectile.Center.X;
				Main.dust[num474].position.Y = projectile.Center.Y;
				Dust dust68 = Main.dust[num474];
				dust68.position.X = dust68.position.X + (float)Main.rand.Next(-10, 11);
				Dust dust69 = Main.dust[num474];
				dust69.position.Y = dust69.position.Y + (float)Main.rand.Next(-10, 11);
				Main.dust[num474].velocity.X = num470;
				Main.dust[num474].velocity.Y = num471;
				int num4 = num469;
				num469 = num4 + 1;
			}
		}
		
		public override void Kill(int timeLeft)
		{
		}
    }	
}