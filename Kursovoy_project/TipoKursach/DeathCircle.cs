using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TipoKursach
{
    public class DeathCircle
    {
        private float X;
        private float Y;

        private Color _color = Color.Red;

        private int Radius;

        public int count = 0;

        public Action<Particle> OnParticleOverlap;

        public DeathCircle(float x, float y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public void OverlapParticle(Particle particle)
        {
            particle.Life = 0;
            OnParticleOverlap?.Invoke(particle);
            count += 1;
        }

        public bool OvelapsWith(Particle particle)
        {
            float gX = X - particle.GetX();
            float gY = Y - particle.GetY();
            double r = Math.Sqrt(gX * gX + gY * gY);
            return (r + particle.GetRadius() < Radius);
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }

        public float GetX()
        {
            return X;
        }

        public float GetY()
        {
            return Y;
        }

        public int GetRadius()
        {
            return Radius;
        }

        public void SetRadius(int radius)
        {
            Radius = radius;
        }



        public virtual void Draw(Graphics g)
        {
            var b = new Pen(_color, 3);
            g.DrawEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            g.DrawString(count.ToString(), new Font("Verdana", 14), // шрифт и его размер
            new SolidBrush(Color.Red), // цвет шрифта
            X,
            Y);

            b.Dispose();
        }
    }
}
