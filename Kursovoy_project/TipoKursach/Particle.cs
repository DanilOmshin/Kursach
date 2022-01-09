using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipoKursach
{
    public class Particle
    {
        private float X; // координата X частицы
        private float Y; // координата Y частицы

        private float Direction; // направление движения частицы
        private float Speed; // скорость движения частицы

        private int Radius; // радиус частицы

        public float Life; // время жизни частицы

        private bool Access_Info = false; // доступ к информации о частице в debug режиме

        private Color _color = Color.White; // цвет частицы

        public Action<Particle> OnDeath; // событие смерти частицы

        public Particle(float x, float y, float direction, float speed, int radius, float life)
        {
            X = x;
            Y = y;
            Direction = direction;
            Speed = speed;
            Radius = radius;
            Life = life;
        }

        public Particle(Particle particle)
        {
            X = particle.GetX();
            Y = particle.GetY();
            Direction = particle.GetDirection();
            Speed = particle.GetSpeed();
            Radius = particle.GetRadius();
            Life = particle.GetLife();
            _color = particle.GetColor();
            Access_Info = particle.IsLockedInfo();
        }

        // метод движения частицы (направление, скорость и координаты)
        public void Move()
        {
            var directionInRadians = Direction / 180 * Math.PI;
            X += (float)(Speed * Math.Cos(directionInRadians));
            Y -= (float)(Speed * Math.Sin(directionInRadians));

            Particle_Death();
        }

        // метод уменьшения жизни частицы
        private void Particle_Death()
        {
            Life--; // уменьшаем счётчик жизни на единицу

            if (Life <= 0) Death(); // если счётчик жизни <= 0, то частица умирает
        }

        // метод смерти частицы
        public void Death()
        {
            OnDeath?.Invoke(this);
        }

        // методы доступа к полям классов
        // установка свойства color
        public void SetColor(Color color)
        {
            _color = color;
        }

        // получение свойства color
        public Color GetColor()
        {
            return _color;
        }

        // метод, регистрирующий выход частицы за пределы окна программы
        public bool IsLeftScreen(PictureBox pictureBox)
        {
            return (X + Radius < 0
                || X > pictureBox.Image.Width
                || Y > pictureBox.Image.Height);
        }

        // метод доступа к информации о частице
        public bool IsLockedInfo()
        {
            return Access_Info;
        }

        // метод, получающий иформацию о частице
        public String GetInfo()
        {
            return $"X: {X}\n" +
                $"Y: {Y}\n" +
                $"Life: {Life}\n";
        }

        // метод получения свойства Direction
        public float GetDirection()
        {
            return Direction;
        }

        // метод получения свойства Speed
        public float GetSpeed()
        {
            return Speed;
        }

        // метод получения свойства Life
        public float GetLife()
        {
            return Life;
        }

        // метод получения свойства X
        public float GetX()
        {
            return X;
        }
        // метод получения свойства Y
        public float GetY()
        {
            return Y;
        }

        // метод получения свойства Radius
        public int GetRadius()
        {
            return Radius;
        }

        // метод открытия доступа к информации о частице
        public void Available_Info()
        {
            Access_Info = true;
        }

        // метод закрытия доступа к информации о частице
        public void Not_Available_Info()
        {
            Access_Info = false;
        }

        // метод вывода информации о частице
        public void ShowInfo(Graphics g)
        {
            using (Font font1 = new Font("Times New Romans", 12, FontStyle.Italic, GraphicsUnit.Pixel)) // задаем параметры отображения текста
            {
                Point pos = new Point((int)X, (int)Y); // точка вывода информации о частице

                g.DrawString(GetInfo(), font1, Brushes.White, pos); // отрисовка текста
            }
        }

        public void Draw(Graphics g) // метод отрисовки частиц
        {
            if (Access_Info) ShowInfo(g); // выводим информацию о частице

            float k = Math.Min(1f, Life / 100); // привязка чвета частицы к времени её жизни, чем меньше время жизни, тем более тусклый цвет у частицы
            int alpha = (int)(k * 255);
            var color = Color.FromArgb(alpha, _color);

            var b = new SolidBrush(color); // добавили кисть для рисования

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2); // рисуем частицы

            b.Dispose();
        }
    }
}


