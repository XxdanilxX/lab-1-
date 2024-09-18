using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab_1
{
    public partial class Form1 : Form
    {
        private int comparisonCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Метод для виконання двофазного простого злиття
        private void TwoPhaseMergeSort(string inputFilePath, string outputFilePath)
        {
            // Перевірка на наявність вхідного файлу
            if (!File.Exists(inputFilePath))
            {
                CreateRandomFile(inputFilePath);
            }

            string tempFile1 = "temp1.txt";
            string tempFile2 = "temp2.txt";

            // Розділення файлу на дві частини
            SplitFile(inputFilePath, tempFile1, tempFile2);

            // Сортування кожної частини
            SortFile(tempFile1);
            SortFile(tempFile2);

            // Об'єднання двох файлів у результаті злиття
            MergeFiles(tempFile1, tempFile2, outputFilePath);

            // Видалення тимчасових файлів
            File.Delete(tempFile1);
            File.Delete(tempFile2);

            // Відображення кінцевого результату
            DisplayFile(inputFilePath, outputFilePath);
        }

        // Метод для створення файлу, якщо файл відсутній
        private void CreateRandomFile(string filePath)
        {
            Random rand = new Random();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < 20; i++)  // Генерація 20 випадкових чисел
                {
                    writer.WriteLine(rand.Next(1, 101));  // Числа від 1 до 100
                }
            }
            MessageBox.Show($"Файл {filePath} не існував, тому був створений зі випадковими даними.");
        }

        private void SplitFile(string inputFilePath, string tempFile1, string tempFile2)
        {
            // Логіка розбиття файлу на дві частини
            using (var reader = new StreamReader(inputFilePath))
            using (var writer1 = new StreamWriter(tempFile1))
            using (var writer2 = new StreamWriter(tempFile2))
            {
                bool writeToFirst = true;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (writeToFirst)
                    {
                        writer1.WriteLine(line);
                    }
                    else
                    {
                        writer2.WriteLine(line);
                    }
                    writeToFirst = !writeToFirst;
                }
            }
        }

        private void SortFile(string filePath)
        {
            // Сортування файлу
            var lines = File.ReadAllLines(filePath);
            var sortedLines = lines.OrderBy(line => int.Parse(line)).ToArray();
            File.WriteAllLines(filePath, sortedLines);
        }

        private void MergeFiles(string tempFile1, string tempFile2, string outputFilePath)
        {
            // Логіка злиття двох частин файлу
            using (var writer = new StreamWriter(outputFilePath))
            using (var reader1 = new StreamReader(tempFile1))
            using (var reader2 = new StreamReader(tempFile2))
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();

                while (line1 != null && line2 != null)
                {
                    comparisonCount++;
                    if (int.Parse(line1) < int.Parse(line2))
                    {
                        writer.WriteLine(line1);
                        line1 = reader1.ReadLine();
                    }
                    else
                    {
                        writer.WriteLine(line2);
                        line2 = reader2.ReadLine();
                    }
                }

                // Дописуємо залишки з першого або другого файлу
                while (line1 != null)
                {
                    writer.WriteLine(line1);
                    line1 = reader1.ReadLine();
                }

                while (line2 != null)
                {
                    writer.WriteLine(line2);
                    line2 = reader2.ReadLine();
                }
            }
        }

        private void DisplayFile(string inputFilePath, string outputFilePath)
        {
            // Очищаємо DataGridView перед відображенням нових даних
            dataGridView1.Rows.Clear();

            // Якщо колонки ще не створені, додаємо дві колонки для "Як було" і "Як стало"
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("InitialColumn", "Як було");
                dataGridView1.Columns.Add("SortedColumn", "Як стало");
            }

            // Зчитуємо початкові та відсортовані дані
            var initialLines = File.ReadAllLines(inputFilePath);
            var sortedLines = File.ReadAllLines(outputFilePath);

            // Відображаємо дані у DataGridView
            for (int i = 0; i < Math.Max(initialLines.Length, sortedLines.Length); i++)
            {
                string initial = (i < initialLines.Length) ? initialLines[i] : string.Empty;
                string sorted = (i < sortedLines.Length) ? sortedLines[i] : string.Empty;

                // Додаємо рядок з початковим та відсортованим значенням
                dataGridView1.Rows.Add(initial, sorted);
            }

            MessageBox.Show($"Кількість порівнянь: {comparisonCount}");
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string inputFilePath = "C:\\Users\\Lenovo\\Desktop\\input.txt";  // Шлях до вхідного файлу
            string outputFilePath = "C:\\Users\\Lenovo\\Desktop\\output.txt";  // Шлях до вихідного файлу
            TwoPhaseMergeSort(inputFilePath, outputFilePath);
        }
    }
}
