using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintballGun
{
    internal class PaintballGun
    {
        // Initialize magazine size property
        public int MagazineSize { get; private set; } = 16;

        // Initialize balls field
        private int balls = 0;

        public int BallsLoaded { get; private set; }

        public bool IsEmpty() { return BallsLoaded == 0; }
        
        // Property containing balls getters and setters
        public int Balls
        {
            get { return balls; }

            set
            {
                if (value > 0)
                    balls = value;
                Reload();
            }
        }

        // Ensures gun is reloaded to correct magazine size when called in SetBalls method
        public void Reload()
        {
            if (balls > MagazineSize)
                BallsLoaded = MagazineSize;
            else
                BallsLoaded = balls;
        }

        // Decrements balls and balls loaded by one each time it is invoked, unless no balls are loaded
        public bool Shoot()
        {
            if (BallsLoaded == 0) return false;
            BallsLoaded--;
            balls--;
            return true;
        }

        public PaintballGun(int balls, int magazineSize, bool loaded)
        {
            this.balls = balls;
            MagazineSize= magazineSize;
            if (!loaded) Reload();
        }
    }
}
