using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TR.Projectiles
{
	public class IgnitionThrown : ModProjectile
    {
        public override void SetDefaults()
        {	
			projectile.width = 36;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.ignoreWater = true;
			projectile.timeLeft = 420;
			projectile.scale = 1f;
        }
		float biggering = 1;
		public override void AI()
		{	
			projectile.velocity *= 0.95f;
			if(projectile.width <= 74)
			{
				projectile.width++;
			}
			else projectile.width = 74;
			
			if(projectile.height <= 74)
			{
				projectile.height++;
			}
			else projectile.height = 74;
			biggering += 0.025f;
			if(biggering >= 1.95f)
			{
				biggering = 1.95f;
			}
			for(int i = 0; i < 1; i++)
			{
				int fireDust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[fireDust].noGravity = true;
				Main.dust[fireDust].scale = biggering;
			}
			
			for(int i = 0; i < Main.projectile.Length - 1; i++)
			{
				Projectile proj = Main.projectile[i];
				if(proj.active && proj.Hitbox.Intersects(projectile.Hitbox))
				{
					
					if(proj.type == mod.ProjectileType("AquaThrown"))
					{
						projectile.Kill();
						proj.Kill();
					}
				}
			}
		}
    }
}