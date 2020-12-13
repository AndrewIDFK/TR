using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TR.Projectiles
{
	public class ReactiveFlaskThrown : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.thrown = true;
		}
		
		public bool typeLava = false;
		public bool typeWater = false;
		public bool typeNeon = false;
		public override void AI()
		{
			projectile.rotation += Math.Abs(projectile.velocity.X) * 0.04f * projectile.direction;
			ref float reference = ref projectile.ai[0];
			reference += 1f;
			if (projectile.ai[0] >= 20f)
			{
				projectile.velocity.Y = projectile.velocity.Y + 0.4f;
				projectile.velocity.X = projectile.velocity.X * 0.97f;
			}
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			
			if (Collision.LavaCollision(projectile.position, projectile.width, projectile.height))
			{
				typeLava = true;
				typeNeon = false;
				typeWater = false;
			}
			
			if (Collision.DrownCollision(projectile.position, projectile.width, projectile.height))
			{
				typeWater = true;
				typeLava = false;
				typeNeon = false;
			}
			
			for(int i = 0; i < Main.projectile.Length - 1; i++)
			{
				Projectile proj = Main.projectile[i];
				if(proj.active && proj.Hitbox.Intersects(projectile.Hitbox))
				{
					if(proj.type == 513)
					{
						typeNeon = true;
						typeLava = false;
						typeWater = false;
					}
					
					if(proj.type == mod.ProjectileType("IgnitionThrown"))
					{
						typeLava = true;
						typeNeon = false;
						typeWater = false;
					}
					
					if(proj.type == mod.ProjectileType("AquaThrown"))
					{
						typeWater = true;
						typeLava = false;
						typeNeon = false;
					}
					if(proj.type == mod.ProjectileType("NeonThrown"))
					{
						typeWater = false;
						typeLava = false;
						typeNeon = true;
					}
				}
			}
			
			if(typeLava)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[num].scale = 0.8f;
				Main.dust[num].noGravity = true;
			}
			else if(typeWater)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[num].scale = 0.8f;
				Main.dust[num].noGravity = true;
			}
			else if(typeNeon)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 100, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[num].scale = 0.8f;
				Main.dust[num].noGravity = true;
			}
			else
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 140, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[num].scale = 0.8f;
				Main.dust[num].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			if(typeLava)
			{
				Main.PlaySound(SoundID.Item74, projectile.position);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 296, projectile.damage * 3, projectile.knockBack, projectile.owner, 0f, 0f);
			}
			else if (typeWater)
			{
				for (int i = 0; i < 8; i++)
				{
					int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 33, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].velocity *= 3f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale = 0.8f;
						Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
					}
				}
				
				Main.PlaySound(SoundID.Item21, projectile.position);
				for (int i = 0; i < 7; i++)
				{
					//Main.PlaySound(SoundID.Item74, projectile.position);
					Vector2 vel = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-12, 4));
					Projectile.NewProjectile(projectile.Center, vel, 22, projectile.damage * 2, projectile.knockBack / 2, projectile.owner, 0, 1);
				}
			}
			else if (typeNeon)
			{
				Main.PlaySound(SoundID.Item92, projectile.position);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 443, projectile.damage * 2, projectile.knockBack, projectile.owner, 0f, 0f);
			}
			else
			{
				Main.PlaySound(SoundID.Item107, projectile.position);
				int type = mod.ProjectileType("ReactiveCloud");
				int num318 = Main.rand.Next(12, 15);
				for (int num319 = 0; num319 < num318; num319++)
				{
					Vector2 value16 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value16.Normalize();
					value16 *= Main.rand.Next(180, 341) * 0.00101f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value16.X, value16.Y, type, projectile.damage, projectile.owner, 0, Main.rand.Next(-45, 1));
				}
			}
		}
	}
}
