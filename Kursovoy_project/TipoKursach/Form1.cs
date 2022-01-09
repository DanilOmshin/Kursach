using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipoKursach
{
    public partial class Form1 : Form
    {

        public static Random rand = new Random(); // генерация случайных чисел

        private List<List<Particle>> Simulations = new List<List<Particle>>(); // список для работы обратной симуляции

        public static List<Particle> particles = new List<Particle>(); // список частиц

        private Particle info_particle = null; // информация о частице

        public static DeathCircle _deathCircle; // спец. точка

        public Form1()
        {
            InitializeComponent();

            PbMain.Image = new Bitmap(PbMain.Width, PbMain.Height); // привязываем к пикчербоксу изображение, чтобы можно было рисовать на нём

            Simulations.Add(particles); // добавляем список частиц в список симуляции для формирования истории


            DeathCircle(); // вызов метода спец. точки
            StartStopTimer(); // вызов метода запуска/остановки программы
        }

        // метод изменения количества частиц
        private void Count_Particles()
        {
            for (int i = 0; i < 10; i++) // генерирую не более 10 штук за тик
            {
                if (particles.Count < (int)ParticlesCounter.Value) // пока частиц меньше value
                {
                    particles.Add(GenerateParticle());
                }
                else if (particles.Count > (int)ParticlesCounter.Value)
                {
                    particles.RemoveAt(0);
                }
            }
        }

        // спец. точка
        private void DeathCircle()
        {
            int count = 0;
            //добавляем точку на форму
            _deathCircle = new DeathCircle(
                PbMain.Image.Width / 2,
                PbMain.Image.Height / 2,
                50
                );
            // реакция на пересечение точки с формой
            _deathCircle.OnParticleOverlap += (prt) =>
            {
                (prt as Particle).Life = 0;
                _deathCircle.count += 1;
            };
        }

        // метод генерации частиц
        private Particle GenerateParticle()
        {
            float angle, x, y;

            x = rand.Next(PbMain.Image.Width);
            y = 0;
            angle = 225 + rand.Next(90);

            // создаем частицу
            var particle = new Particle(
                x, y, angle,
                1 + rand.Next(10),
                2 + rand.Next(10),
                20 + rand.Next(100)
                );

            // реакция на смерть частицы
            particle.OnDeath += (prt) =>
            {
                particles.Remove(prt); // удаляем частицу
                particles.Add(GenerateParticle()); // добавляем новую
            };

            return particle;
        }

        // кнопка запуска/остановки программы
        private void StartStopButton_Click(object sender, EventArgs e)
        {
            StartStopTimer(); // вызов метода запуска/остановки программы
        }

        // запуск/остановка симуляции программы
        private void StartStopTimer()
        {
            if (GenerationBar.Value != GenerationBar.Maximum) // проверяем, если generationbar не достиг значения максимума, то выводим ошибку
            {
                MessageBox.Show("Необходимо перемотать симуляцию вперёд!");
                return;
            }

            timer1.Enabled = !timer1.Enabled; //выключаем таймер для остановки программы
            StartStopButton.Text = (timer1.Enabled) ? "Стоп" : "Старт";
        }

        // обновляем состояние частиц
        private void UpdateParticlesState()
        {
            Count_Particles(); // вызов метода изменения количества частиц

            foreach (var particle in particles.ToArray())
            {
                if (particle.IsLeftScreen(PbMain)) // если частица вышла за рамки пикчербокса, то удаляем её
                {
                    particle.Death(); // удаляем частицу
                }
                else //ругом случае продолжаем движение частицы
                {
                    particle.Move();
                }

                if (_deathCircle.OvelapsWith(particle))
                {
                    _deathCircle.OverlapParticle(particle);
                }
            }
        }

        //добавление новой генерации
        public void AddNewGeneration()
        {
            if (GenerationBar.Maximum < 100)// если максимальное значение generationbar < 100
            {
                Simulations.Add(particles); // добавляем в список симуяции, список частиц
                GenerationBar.Maximum += 1; // увеличиваем значение максимума на 1
                GenerationBar.Value = GenerationBar.Maximum; // обновляем значение генерации на максимум
            }
            else
            {
                Simulations.RemoveAt(0);
                Simulations.Add(particles);
            }
        }

        // добавление последней генерации
        private void AddLastGeneration()
        {
            var lastGeneration = new List<Particle>();

            foreach (var particle in particles)
            {
                lastGeneration.Add(new Particle(particle)); // добавляем в последнюю генерацию частицы
            }

            Simulations[GenerationBar.Maximum] = lastGeneration; // список симуляции принимает новое значение последней генерации
        }

        // обновляем фрейм
        private void UpdateFrame()
        {
            RenderObjs(); // вызов метода рендеринга объектов
        }

        // метод рендеринга объектов
        private void RenderObjs()
        {
            using (var g = Graphics.FromImage(PbMain.Image))
            {
                g.Clear(Color.Black);// делаем фон чёрным

                foreach (var particle in particles.ToArray())
                {
                    particle.Draw(g); // отрисовываем частицы
                }

                _deathCircle.Draw(g); // отрисовываем спец.точку
            }

            PbMain.Invalidate(); // обновляем пикчербокс
        }

        // обновление генерации
        public void UpdateGeneration()
        {
            AddLastGeneration(); // добавление последней генерации
            UpdateParticlesState(); // обновление состояния частиц
            AddNewGeneration(); // добавление новой генерации
        }

        // таймер
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGeneration();

            UpdateFrame();
        }

        // кнопка следующего шага выполнения программы
        private void NextStepButton_Click(object sender, EventArgs e)
        {
            if (GenerationBar.Value != GenerationBar.Maximum) // проверяем чтобы значение generationbar не было изменено
            {
                MessageBox.Show("Необходимо перемотать симуляцию вперёд!"); // выводим ошибку
                return;
            }

            UpdateGeneration(); // обновляем генерацию

            UpdateFrame(); // обновляем фрейм
        }

        // реакция на наведение курсора
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var particle in particles)
            {
                // если координаты курсора совпадают с координатами частицы
                if (Math.Pow(e.X - particle.GetX(), 2) +
                    Math.Pow(e.Y - particle.GetY(), 2) <= Math.Pow(particle.GetRadius(), 2))
                {
                    info_particle = particle;

                    InfoLabel.Text = info_particle.GetInfo(); // выводим информацию о частице
                    InfoLabel.Location = new Point((int)info_particle.GetX(), (int)info_particle.GetY()); // координаты вывода текста
                    InfoLabel.Visible = true;//отображение значения элемента

                    return;
                }
            }

            InfoLabel.Visible = false; // выключаем отображение текста при убирании курсора с частицы
            info_particle = null; // опустошаем информацию о частице
        }

        // trackbar Обратной симуляции
        private void GenerationBar_Scroll(object sender, EventArgs e)
        {
            timer1.Enabled = false; // выключаем таймер(останавливаем пограмму)

            particles = Simulations[GenerationBar.Value]; // частицы принимают свои предыдущие параметры, записанные в список Симуляции

            RenderObjs(); // рендерим объекты
        }

        // trackbar скорости движения частиц
        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 16 + (SpeedBar.Maximum - SpeedBar.Value) * 40; //задаем время в миллисекундах в зависимости от значения trackbar
        }

    }
}




