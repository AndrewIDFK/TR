using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TR.Projectiles
{
	public class AquaThrown : ModProjectile
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
			projectile.scale = 1.1f;
        }
		float biggering = 1;
		public override void AI()
		{	
			projectile.velocity *= 0.95f;
			if(projectile.width <= 80)
			{
				projectile.width++;
			}
			else projectile.width = 80;
			
			if(projectile.height <= 80)
			{
				projectile.height++;
			}
			else projectile.height = 80;
			biggering -= 0.0125f;
			if(biggering <= 1.05f)
			{
				biggering = 1.05f;
			}
			for(int i = 0; i < 1; i++)
			{
				int aquaDust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, Color.LightBlue, 1f);
				Main.dust[aquaDust].noGravity = true;
				Main.dust[aquaDust].scale = biggering;
			}
			
			for(int i = 0; i < Main.projectile.Length - 1; i++)
			{
				Projectile proj = Main.projectile[i];
				if(proj.active && proj.Hitbox.Intersects(projectile.Hitbox))
				{
					
					if(proj.type == mod.ProjectileType("IgnitionThrown"))
					{
						projectile.Kill();
						proj.Kill();
					}
				}
			}
		}
    }
}