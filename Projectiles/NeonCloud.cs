using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace TR.Projectiles
{
	public class NeonCloud : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ToxicCloud);
			this.aiType = 511;
			projectile.aiStyle = 511;
        }
    }
}