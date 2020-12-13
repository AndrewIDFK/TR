using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TR.Projectiles
{
	public class ReactiveCloud : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.scale = 1.1f;
			projectile.tileCollide = false;
        }
		
		bool typeLava = false;
		bool typeWater = false;
		public override void AI()
		{
			projectile.ai[0]++;
			projectile.alpha = (int)(100.0 + (double)projectile.ai[0] * 0.75);
			if (projectile.ai[0] > 125f)
			{
				projectile.Kill();
				projectile.ai[0] = 125f;
			}
			projectile.rotation += projectile.velocity.X * 0.1f;
			projectile.rotation += (float)projectile.direction * 0.0033f;
			projectile.velocity *= 0.965f;
			Rectangle rectangle5 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
			int num4;
			for (int num893 = 0; num893 < 900; num893 = num4 + 1)
			{
				if (num893 != projectile.whoAmI && Main.projectile[num893].active)
				{
					Rectangle value57 = new Rectangle((int)Main.projectile[num893].position.X, (int)Main.projectile[num893].position.Y, Main.projectile[num893].width, Main.projectile[num893].height);
					if (rectangle5.Intersects(value57))
					{
						Vector2 vector80 = Main.projectile[num893].Center - projectile.Center;
						if (vector80.X == 0f && vector80.Y == 0f)
						{
							if (num893 < projectile.whoAmI)
							{
								vector80.X = -1f;
								vector80.Y = 1f;
							}
							else
							{
								vector80.X = 1f;
								vector80.Y = -1f;
							}
						}
						vector80.Normalize();
						vector80 *= 0.0055f;
						projectile.velocity -= vector80;
						Projectile projectile2 = Main.projectile[num893];
						projectile2.velocity += vector80;
					}
				}
				num4 = num893;
			}
			
			if (Collision.LavaCollision(projectile.position, projectile.width, projectile.height))
			{
				typeLava = true;
			}
			if (Collision.DrownCollision(projectile.position, projectile.width, projectile.height))
			{
				typeWater = true;
			}
			
			for(int i = 0; i < Main.projectile.Length - 1; i++)
			{
				Projectile proj = Main.projectile[i];
				if(proj.active && proj.Hitbox.Intersects(projectile.Hitbox))
				{
					
					if(proj.type == mod.ProjectileType("IgnitionThrown"))
					{
						typeLava = true;
					}
					
					if(proj.type == mod.ProjectileType("AquaThrown"))
					{
						typeWater = true;
					}
				}
			}
			
			if(typeLava || typeWater)
			{
				projectile.Kill();
			}
		}
		
		public override void Kill(int timeLeft)
		{
			if(typeLava)
			{
				Main.PlaySound(SoundID.Item74, projectile.position);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 296, projectile.damage * 2, projectile.knockBack, projectile.owner, 0f, 0f);
			}
			else if(typeWater)
			{
				Main.PlaySound(SoundID.Item21, projectile.position);
				for (int i = 0; i < 3; i++)
				{
					//Main.PlaySound(SoundID.Item74, projectile.position);
					Vector2 vel = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-8, -8));
					Projectile.NewProjectile(projectile.Center, vel, 22, projectile.damage / 2, projectile.knockBack / 2, projectile.owner, 0, 1);
				}
			}
		}
    }	
}